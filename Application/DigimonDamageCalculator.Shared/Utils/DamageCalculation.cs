using DigimonDamageCalculator.Shared.Models;

namespace DigimonDamageCalculator.Shared.Utils
{
    /// <summary>
    /// Provides methods for calculating Digimon Story: Time Stranger damage.
    /// </summary>
    public static class DamageCalculation
    {
        // The default variance percentage for damage rolls
        public const double Variance = 5.0;
        private static readonly Random _rng = new Random();

        /// <summary>
        /// Calculates estimated Digimon Story: Time Stranger damage based on known community formula.
        /// </summary>
        /// <param name="atk">Attacker's ATK stat</param>
        /// <param name="def">Defender's DEF stat</param>
        /// <param name="level">Attacker's level</param>
        /// <param name="skillPower">Skill power value</param>
        /// <param name="multiplier">Type/element/attribute multiplier</param>
        /// <returns>Estimated damage value</returns>
        public static int CalculateDamage(AttackStats attackStats)
        {
            // The preset values are found by the community through data mining.
            const double presetOffModifier = 80;
            const double presetDefModifier = 35;
            const double presetLevelDivisor = 9801;
            const double presetLevelScaling = 30;

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

            return RoundDamage(result);
        }

        /// <summary>
        /// Simulates damage rolls based on user inputs.
        /// </summary>
        /// <param name="_results"></param>
        static public SimulationResult SimulateAttacks(AttackStats stats)
        {
            int numberOfAttackRolls = 8;
            SimulationResult result = new SimulationResult();

            int baseDmg = CalculateDamage(stats);

            for (int i = 0; i < numberOfAttackRolls; i++)
            {
                double variancedDamage = ApplyVariance(baseDmg);
                int roundedResult = RoundDamage(variancedDamage);
                result.DamageResults.Add(roundedResult);
            }

            return result;
        }

        /// <summary>
        /// Applies variance to a base damage value.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="variancePercent"></param>
        /// <returns></returns>
        private static double ApplyVariance(double value)
        {
            double r = _rng.NextDouble() * 2.0 - 1.0;
            double factor = 1.0 + r * (Variance / 100.0);
            return value * factor;
        }

        /// <summary>
        /// Rounds damage to the nearest integer.
        /// </summary>
        /// <param name="dmg"></param>
        /// <returns></returns>
        static public int RoundDamage(double dmg) => (int)Math.Round(dmg);
    }
}
