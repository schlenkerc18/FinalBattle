using FinalBattle.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBattle.Enums;

namespace FinalBattle
{
    public class AttackModifier
    {
        public int _damage { get; set; }
        public AttackModifier(Character defensiveCharacter, int damage)
        {
            _damage = damage;

            switch (defensiveCharacter._characterType)
            {
                case CharacterType.TrueProgrammer:
                    break;
                case CharacterType.Skeleton:
                    break;
                case CharacterType.HeroCompanion:
                    break;
                case CharacterType.UncodedOne:
                    break;
                case CharacterType.StoneAmarok:
                    StoneAmarokModifier();
                    break;
            }
        }

        public void StoneAmarokModifier()
        {
            Console.WriteLine("STONE ARMOR reduced the attack by 1 point!");
            _damage -= 1;
        }
    }
}
