using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> myHero;

        public HeroRepository()
        {
            myHero = new List<Hero>();
        }

        public int Count
        {
            get
            {
                return this.myHero.Count;
            }
        }
        public void Add(Hero hero)
        {
            this.myHero.Add(hero);
        }

        public void Remove(string name)
        {
            for (int i = 0; i < myHero.Count; i++)
            {
                if (this.myHero[i].Name == name)
                {
                    this.myHero.RemoveAt(i);
                    break;
                }
            }

        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero heroForGive = this.myHero[0];

            foreach (var hero in this.myHero)
            {
                var oldStrength = heroForGive.Item.Strength;
                var curentStrength = hero.Item.Strength;
                if (oldStrength < curentStrength)
                {
                    heroForGive = hero;
                }
            }

            return heroForGive;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero heroForGive = this.myHero[0];

            foreach (var hero in this.myHero)
            {
                var oldStrength = heroForGive.Item.Ability;
                var curentStrength = hero.Item.Ability;
                if (oldStrength < curentStrength)
                {
                    heroForGive = hero;
                }
            }

            return heroForGive;
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            Hero heroForGive = this.myHero[0];

            foreach (var hero in this.myHero)
            {
                var oldStrength = heroForGive.Item.Intelligence;
                var curentStrength = hero.Item.Intelligence;
                if (oldStrength < curentStrength)
                {
                    heroForGive = hero;
                }
            }

            return heroForGive;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var item in this.myHero)
            {
                sb.Append(item);
                sb.AppendLine();

            }
            return sb.ToString();
        }
    }
}
