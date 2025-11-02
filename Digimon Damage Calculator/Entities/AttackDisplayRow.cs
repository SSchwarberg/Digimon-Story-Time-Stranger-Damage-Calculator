using System;

namespace Digimon_Damage_Calculator.Entities
{
    /// <summary>
    /// Represents a row in the attack display table.
    /// </summary>
    internal class AttackDisplayRow
    {
        public int AttackIndex { get; set; }
        public int Damage { get; set; }
        public int AttackCount { get; set; }
        public int CritDamage { get; set; }

        public string DamageDisplay => GetDamageText();
        public string CritDamageDisplay => GetCritDamageText();

        /// <summary>
        /// Return a text representing the dealt damage.
        /// </summary>
        /// <returns></returns>
        private string GetDamageText()
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
        private string GetCritDamageText()
        {
            if (AttackCount != 1)
                return $"{AttackCount * CritDamage} ({AttackCount}x {CritDamage})";
            else
                return CritDamage.ToString();
        }
    }
}
