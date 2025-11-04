using CalculationTests.Entities;
using Digimon_Damage_Calculator.Entities;

namespace CalculationTests
{
    /// <summary>
    /// Tests cases to check if the calculation are within the expected dmg range.
    /// </summary>
    public class DamageCalculatorTests
    {
        [Fact]
        public void TestCase1()
        {
            AttackStats stats = new AttackStats
            {
                Level = 43,
                OffStat = 2581,
                DefStat = 927,
                SkillPower = 60,
                ResistancePercent = 150,
            };

            int expectedDamage = 1417;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);

            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase2()
        {
            AttackStats stats = new AttackStats
            {
                Level = 47,
                OffStat = 4002,
                DefStat = 927,
                SkillPower = 80,
                ResistancePercent = 300
            };

            int expectedDamage = 6589;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase3()
        {
            AttackStats stats = new AttackStats
            {
                Level = 44,
                OffStat = 2158,
                DefStat = 902,
                SkillPower = 60,
                ResistancePercent = 50
            };

            int expectedDamage = 393;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase4()
        {
            AttackStats stats = new AttackStats
            {
                Level = 47,
                OffStat = 4082,
                DefStat = 902,
                SkillPower = 80,
                ResistancePercent = 50
            };

            int expectedDamage = 1141;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase5()
        {
            AttackStats stats = new AttackStats
            {
                Level = 45,
                OffStat = 6460,
                DefStat = 902,
                SkillPower = 15,
                ResistancePercent = 300
            };

            int expectedDamage = 1931;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase6()
        {
            AttackStats stats = new AttackStats
            {
                Level = 47,
                OffStat = 4082,
                DefStat = 578,
                SkillPower = 80,
                ResistancePercent = 50
            };

            int expectedDamage = 1762;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase7()
        {
            AttackStats stats = new AttackStats
            {
                Level = 26,
                OffStat = 1099,
                DefStat = 578,
                SkillPower = 60,
                ResistancePercent = 50
            };

            int expectedDamage = 208;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase8()
        {
            AttackStats stats = new AttackStats
            {
                Level = 18,
                OffStat = 793,
                DefStat = 578,
                SkillPower = 40,
                ResistancePercent = 50
            };

            int expectedDamage = 86;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());        }

        [Fact]
        public void TestCase9()
        {
            AttackStats stats = new AttackStats
            {
                Level = 44,
                OffStat = 2158,
                DefStat = 902,
                SkillPower = 60,
                ResistancePercent = 50
            };

            int expectedDamage = 390;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase10()
        {
            AttackStats stats = new AttackStats
            {
                Level = 47,
                OffStat = 3402,
                DefStat = 902,
                SkillPower = 80,
                ResistancePercent = 50
            };

            int expectedDamage = 956;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase11()
        {
            AttackStats stats = new AttackStats
            {
                Level = 26,
                OffStat = 1099,
                DefStat = 902,
                SkillPower = 60,
                ResistancePercent = 50
            };

            int expectedDamage = 139;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase12()
        {
            AttackStats stats = new AttackStats
            {
                Level = 18,
                OffStat = 925,
                DefStat = 902,
                SkillPower = 40,
                ResistancePercent = 50
            };

            int expectedDamage = 63;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase13()
        {
            AttackStats stats = new AttackStats
            {
                Level = 8,
                OffStat = 550,
                DefStat = 902,
                SkillPower = 30,
                ResistancePercent = 200
            };

            int expectedDamage = 93;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase14()
        {
            AttackStats stats = new AttackStats
            {
                Level = 15,
                OffStat = 1771,
                DefStat = 902,
                SkillPower = 85,
                ResistancePercent = 50
            };

            int expectedDamage = 240;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase15()
        {
            AttackStats stats = new AttackStats
            {
                Level = 1,
                OffStat = 360,
                DefStat = 609,
                SkillPower = 60,
                ResistancePercent = 100
            };

            int expectedDamage = 78;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase16()
        {
            AttackStats stats = new AttackStats
            {
                Level = 44,
                OffStat = 1370,
                DefStat = 902,
                SkillPower = 85,
                ResistancePercent = 30
            };

            int expectedDamage = 222;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase17()
        {
            AttackStats stats = new AttackStats
            {
                Level = 46,
                OffStat = 6496,
                DefStat = 943,
                SkillPower = 20,
                ResistancePercent = 50,
                EquipmentDMGRatePercent = 150,
                HasDamageBoost = true
            };

            int expectedDamage = 950;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }

        [Fact]
        public void TestCase18()
        {
            AttackStats stats = new AttackStats
            {
                Level = 47,
                OffStat = 6556,
                DefStat = 902,
                SkillPower = 90,
                ResistancePercent = 50,
                HasDamageBoost = true
            };

            int expectedDamage = 3701;
            TestResult result = Utils.CalculationTestHelper.IsWithinExpectation(stats, expectedDamage);
            Assert.True(result.IsSuccess, result.ResultText());
        }
    }
}