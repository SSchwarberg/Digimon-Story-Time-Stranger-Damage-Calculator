using CalculationTests.Entities;
using Digimon_Damage_Calculator.Entities;
using Digimon_Damage_Calculator.Utils;

namespace CalculationTests.Utils
{
    /// <summary>
    /// A helper class for helping with calculation tests.
    /// </summary>
    static internal class CalculationTestHelper
    {
        /// <summary>
        /// Checks if the calculated damage for the given stats is within an acceptable range of the expected damage.
        /// </summary>
        /// <param name="stats"></param>
        /// <param name="expectedDMG"></param>
        /// <returns></returns>
        static internal TestResult IsWithinExpectation(AttackStats stats, int expectedDMG)
        {
            int toleranceInPercent = 10;
            TestResult result = new TestResult();

            result.ExpectedDamage = expectedDMG;
            result.CalculatedDamage = DamageCalculation.CalculateDamage(stats);
            result.DmgDifferenceInPercent = ((double)Math.Abs(result.CalculatedDamage - expectedDMG)) / expectedDMG * 100.0;

            if (result.DmgDifferenceInPercent <= toleranceInPercent)
                result.IsSuccess = true;

            return result;
        }
    }
}
