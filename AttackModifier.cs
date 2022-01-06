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
        public AttackModifier(Character defensiveCharacter, int damage, DamageType damageType)
        {
            _damage = damage;

            switch (defensiveCharacter._characterType)
            {
                case CharacterType.TrueProgrammer:
                    TrueProgrammerModifier(damageType, damage);
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

        public void TrueProgrammerModifier(DamageType damageType, int damage)
        {
            if (damageType == DamageType.Decoding)
            {
                if (damage <= 1)
                {
                    Console.WriteLine("Object insight decreased the damage to 0!");
                    _damage = 0;
                }
                else
                {
                    Console.WriteLine("Object Insight decreased the Decoding damage by 2!");
                    _damage -= 1;
                }

            }
        }
    }
}
