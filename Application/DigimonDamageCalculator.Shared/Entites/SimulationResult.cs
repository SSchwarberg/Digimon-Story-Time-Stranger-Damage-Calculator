namespace DigimonDamageCalculator.Shared.Models
{
    /// <summary>
    /// Holds the result of a damage simulation.
    /// </summary>
    public class SimulationResult
    {
        public List<int> DamageResults { get; set; } = new();
        public int MinDamage => DamageResults.Min();
        public int MaxDamage => DamageResults.Max();
        public double AverageDamage => DamageResults.Average();
    }
}