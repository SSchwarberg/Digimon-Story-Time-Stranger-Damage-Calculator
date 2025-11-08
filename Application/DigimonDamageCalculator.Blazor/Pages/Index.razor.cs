using DigimonDamageCalculator.Shared.Models;
using DigimonDamageCalculator.Shared.Utils;

namespace DigimonDamageCalculator.Blazor.Pages
{
    public partial class Index
    {
        private AttackStats Inputs = new();
        private List<AttackDisplayRow> Rows = new();

        private int MinDamage => Rows.Count == 0 ? 0 : Rows.Min(r => r.Damage);
        private int MaxDamage => Rows.Count == 0 ? 0 : Rows.Max(r => r.Damage);
        private double AverageDamage => Rows.Count == 0 ? 0 : Rows.Average(r => (double)r.Damage);

        /// <summary>
        /// Resets the configured stats and damage roll list.
        /// </summary>
        private void Reset()
        {
            Inputs = new AttackStats();
            Rows.Clear();
        }

        /// <summary>
        /// Simulates damage rolls based on current inputs.
        /// </summary>
        private void Simulate()
        {
            Rows.Clear();
            SimulationResult simulationResult = DamageCalculation.SimulateAttacks(Inputs);
            int index = 1;
            foreach (int dmg in simulationResult.DamageResults)
            {
                Rows.Add(new AttackDisplayRow
                {
                    AttackIndex = index++,
                    Damage = dmg,
                    AttackCount = Inputs.AttackCount,
                    CritDamage = DamageCalculation.RoundDamage(dmg * (Inputs.CriticalDamagePercent / 100.0))
                });
            }
        }
    }
}
