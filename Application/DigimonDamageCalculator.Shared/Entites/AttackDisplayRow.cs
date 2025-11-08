namespace DigimonDamageCalculator.Shared.Models
{
    /// <summary>
    /// Represents a row in the attack display table.
    /// </summary>
    public class AttackDisplayRow
    {
        public int AttackIndex { get; set; }
        public int Damage { get; set; }
        public int AttackCount { get; set; }
        public int CritDamage { get; set; }

        public string DamageDisplay => AttackCount != 1 ? $"{AttackCount * Damage} ({AttackCount}x {Damage})" : Damage.ToString();
        public string CritDamageDisplay => AttackCount != 1 ? $"{AttackCount * CritDamage} ({AttackCount}x {CritDamage})" : CritDamage.ToString();

        /// <summary>
        /// Return a text representing the dealt damage.
        /// </summary>
        /// <returns></returns>
        public string GetDamageText()
        {
            if (AttackCount != 1)
                return $"{AttackCount * Damage} ({AttackCount}x {Damage})";
            else
                return Damage.ToString();
        }

        /// <summary>
        /// Return a text representing the critical damage.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetCritDamageText()
        {
            if (AttackCount != 1)
                return $"{AttackCount * CritDamage} ({AttackCount}x {CritDamage})";
            else
                return CritDamage.ToString();
        }
    }
}