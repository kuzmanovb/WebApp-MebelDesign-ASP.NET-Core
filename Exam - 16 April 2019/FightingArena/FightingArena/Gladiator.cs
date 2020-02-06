using System;
using System.Collections.Generic;
using System.Text;

namespace FightingArena
{
    public class Gladiator
    {
        public Gladiator(string name, Stat stat, Weapon weapon)
        {
            this.Name = name;
            this.Stat = stat;
            this.Weapon = weapon;
        }
        public string Name { get; private set; }
        public Stat Stat { get; set; }
        public Weapon Weapon { get; set; }

        public int GetTotalPower()
        {
            var statPower = GetStatPower();
            var weaponPower = GetWeaponPower();
            return statPower + weaponPower;
        }
        public int GetWeaponPower()
        {

            return this.Weapon.Sharpness + this.Weapon.Size + this.Weapon.Solidity;

        }
        public int GetStatPower()
        {
            return this.Stat.Intelligence + this.Stat.Skills + this.Stat.Strength + this.Stat.Agility + this.Stat.Flexibility;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Name} - {GetTotalPower()}");
            sb.AppendLine($"  Weapon Power: {GetWeaponPower()}");
            sb.Append($"  Stat Power: {GetStatPower()}");

            return sb.ToString();
        }

    }
}
