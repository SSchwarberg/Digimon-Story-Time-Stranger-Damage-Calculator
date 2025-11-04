namespace Digimon_Damage_Calculator.Entities
{
    /// <summary>
    /// A collection of stats relevant to calculating attack damage.
    /// </summary>
    public class AttackStats
    {
        public int Level { get; set; }
        public int OffStat { get; set; }
        public int DefStat { get; set; }
        public int SkillPower { get; set; }
        public int AttackCount { get; set; }
        public int ResistancePercent { get; set; }
        public int BonusOffPercent { get; set; }
        public int BonusDefPercent { get; set; }
        public int CriticalDamagePercent { get; set; }
        public int EquipmentDMGRatePercent { get; set; }
        public bool HasDamageBoost { get; set; }

        public AttackStats()
        {
            Level = 1;
            OffStat = 0;
            DefStat = 0;
            SkillPower = 0;
            AttackCount = 1;
            ResistancePercent = 100;
            BonusOffPercent = 0;
            BonusDefPercent = 0;
            CriticalDamagePercent = 130;
            EquipmentDMGRatePercent = 100;
            HasDamageBoost = false;
        }
    }
}
