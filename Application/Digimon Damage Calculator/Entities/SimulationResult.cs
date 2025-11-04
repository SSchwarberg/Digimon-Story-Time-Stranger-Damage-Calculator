using System.Collections.Generic;
using System.Linq;

namespace Digimon_Damage_Calculator.Entities
{
    /// <summary>
    /// Holds the result of a damage simulation.
    /// </summary>
    internal class SimulationResult
    {
        public List<int> DamageResults { get; set; }

        public int MinDamage => DamageResults.Min();
        public int MaxDamage => DamageResults.Max();
        public double AverageDamage => DamageResults.Average();

        public SimulationResult()
        {
            DamageResults = new List<int>();
        }
    }
}
