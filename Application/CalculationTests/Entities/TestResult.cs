namespace CalculationTests.Entities
{
    /// <summary>
    /// Holds the result of a damage calculation test.
    /// </summary>
    internal class TestResult
    {
        /// <summary>
        /// Indicates whether the test was successful.
        /// </summary>
        public bool IsSuccess { get; set; }
        /// <summary>
        /// The expected damage value.
        /// </summary>
        public double DmgDifferenceInPercent { get; set; }

        /// <summary>
        /// The calculated damage.
        /// </summary>
        public double CalculatedDamage { get; set; }

        /// <summary>
        /// The expected damage by the user.
        /// </summary>
        public double ExpectedDamage { get; set; }

        /// <summary>
        /// Return a text representing the test result.
        /// </summary>
        /// <returns></returns>
        public string ResultText()
        {
            return $"Damage difference: {DmgDifferenceInPercent:F2}% | Calculated: ({CalculatedDamage}) | Expected: ({ExpectedDamage})";
        }
    }
}
