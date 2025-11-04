using Digimon_Damage_Calculator.Entities;
using Digimon_Damage_Calculator.Utils;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DigimonDamageEstimator
{
    public partial class MainWindow : Window
    {
        // Collection to hold the results displayed in the UI.
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
        /// Simulates damage rolls based on user inputs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSimulate(object sender, RoutedEventArgs e)
        {
            try
            {
                _results.Clear();

                AttackStats stats = ReadUserInputs();
                SimulationResult simulationResult = DamageCalculation.SimulateAttacks(stats);

                int attackIndex = 0;
                foreach (int result in simulationResult.DamageResults)
                {
                    AttackDisplayRow row = new AttackDisplayRow
                    {
                        AttackIndex = attackIndex + 1,
                        Damage = result,
                        AttackCount = stats.AttackCount,
                        CritDamage = DamageCalculation.RoundDamage(result * (stats.CriticalDamagePercent / 100.0))
                    };
                    _results.Add(row);
                    attackIndex++;
                }

                SummaryText.Text = $"{simulationResult.DamageResults.Count} rolls (±{DamageCalculation.Variance}%): " +
                    $"Min. {simulationResult.MinDamage} | Max. {simulationResult.MaxDamage} | Avg. {simulationResult.AverageDamage:F1}";
            }
            catch (Exception)
            {
                MessageBox.Show("Please use numbers for each input value.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
