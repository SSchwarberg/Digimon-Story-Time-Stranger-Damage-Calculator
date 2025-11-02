using Digimon_Damage_Calculator.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DigimonDamageEstimator
{
    public partial class MainWindow : Window
    {
        // The default variance percentage for damage rolls
        private const double _variance = 5.0;

        private readonly Random _rng = new Random();
        private readonly ObservableCollection<AttackDisplayRow> _results = new();

        public MainWindow()
        {
            InitializeComponent();
            ResultsList.ItemsSource = _results;
        }


        /// <summary>
        /// Enables window dragging when clicking on the title bar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left) 
                return;

            // Double-click: toggle maximize/restore
            if (e.ClickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
                return;
            }

            // Single-click: allow dragging the window
            if (e.ButtonState == MouseButtonState.Pressed)
                DragMove();
        }

        /// <summary>
        /// Minimizes the window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Min_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

        /// <summary>
        /// Toggles between maximized and normal window state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Max_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, RoutedEventArgs e) => Close();

        /// <summary>
        /// Calculates estimated Digimon Story: Time Stranger damage based on known community formula.
        /// </summary>
        /// <param name="atk">Attacker's ATK stat</param>
        /// <param name="def">Defender's DEF stat</param>
        /// <param name="level">Attacker's level</param>
        /// <param name="skillPower">Skill power value</param>
        /// <param name="multiplier">Type/element/attribute multiplier</param>
        /// <returns>Estimated damage value</returns>
        static double CalculateDamage(AttackStats attackStats)
        {
            // The preset values are found by the community through data mining.
            int presetOffModifier = 85;
            int presetDefModifier = 35;
            int presetLevelDivisor = 9801;
            int presetLevelScaling = 30;

            // Add in Bonus % Stats
            int finalOffStat = attackStats.OffStat
                * (100 + attackStats.BonusOffPercent) / 100;
            int finalDefStat = attackStats.DefStat
                * (100 + attackStats.BonusDefPercent) / 100;

            // Step 1: Base power component
            double basePower = 
                finalOffStat
                * presetOffModifier 
                * (1 + Math.Pow(attackStats.Level, 2) / presetLevelDivisor);

            // Step 2: Apply skill power and defense
            double result = (basePower * attackStats.SkillPower) / (finalDefStat * presetDefModifier);

            // Step 3: Apply level scaling
            result *= (1 + attackStats.Level * (1 + attackStats.Level / presetLevelScaling) / 100.0);

            // Step 4: Apply Multipliers
            result *= (attackStats.ResistancePercent / 100.0);

            double extraDMGFromEquipRate = (result * (attackStats.EquipmentDMGRatePercent / 100.0) - result);
            if (attackStats.HasDamageBoost)
                result *= 2.0;
            result += extraDMGFromEquipRate;

            return result;
        }

        /**
         * Reads user inputs from the UI and constructs an AttackStats object.
         **/
        private AttackStats ReadUserInputs()
        {
            var c = CultureInfo.InvariantCulture;
            AttackStats stats = new AttackStats();

            stats.Level = int.Parse(LvlBox.Text, c);
            stats.OffStat = int.Parse(OffBox.Text, c);
            stats.DefStat = int.Parse(DefBox.Text, c);
            stats.SkillPower = int.Parse(SkillPowerBox.Text, c);
            stats.ResistancePercent = int.Parse(ResistanceBox.Text, c);
            stats.AttackCount = int.Parse(AttackCountBox.Text, c);
            stats.EquipmentDMGRatePercent = int.Parse(EquipmentDMGMultiplierBox.Text, c);
            stats.BonusOffPercent = int.Parse(BonusOffBox.Text, c);
            stats.BonusDefPercent = int.Parse(BonusDefBox.Text, c);
            stats.CriticalDamagePercent = int.Parse(CritMultiplierBox.Text, c);
            stats.HasDamageBoost = DamageBoostBox.IsChecked == true;

            return stats;
        }

        /// <summary>
        /// Rounds damage to the nearest integer.
        /// </summary>
        /// <param name="dmg"></param>
        /// <returns></returns>
        private static int RoundDamage(double dmg) => (int)Math.Round(dmg);

        /// <summary>
        /// Simulates damage rolls based on user inputs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSimulate(object sender, RoutedEventArgs e)
        {
            try
            {
                int numberOfAttackRolls = 10;
                _results.Clear();
                AttackStats attackStats = ReadUserInputs();

                double baseDmg = CalculateDamage(attackStats);
                var values = new List<int>(numberOfAttackRolls);

                for (int i = 0; i < numberOfAttackRolls; i++)
                {
                    double variancedDamage = ApplyVariance(baseDmg);
                    values.Add(RoundDamage(variancedDamage));
                    AttackDisplayRow row = new AttackDisplayRow
                    {
                        AttackIndex = i + 1,
                        Damage = RoundDamage(variancedDamage),
                        AttackCount = attackStats.AttackCount,
                        CritDamage = RoundDamage(variancedDamage * (attackStats.CriticalDamagePercent / 100.0))                        
                    };
                    _results.Add(row);
                }

                int min = values.Min();
                int max = values.Max();
                double avg = values.Average();

                SummaryText.Text = $"{numberOfAttackRolls} rolls (±{_variance}%): Min. {min} | Max. {max} | Avg. {avg:F1}";
            }
            catch (Exception)
            {
                MessageBox.Show("Please use numbers for each input value.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Applies variance to a base damage value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="variancePercent"></param>
        /// <returns></returns>
        private double ApplyVariance(double value)
        {
            double r = _rng.NextDouble() * 2.0 - 1.0;
            double factor = 1.0 + r * (_variance / 100.0);
            return value * factor;
        }
    }
}
