using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosto_Pets
{
    public delegate bool BoolDelegate();

    public struct AandC  // Ability and Condition: pet Ability (button) and Condition when to use it
    {
        public string A;
        public BoolDelegate C;
        public AandC(string s, BoolDelegate v)
        {
            A = s;
            C = v;
        }
        public AandC(string s)
        {
            A = s;
            C = () => true;
        }
    };

    public class PetTacticsBase
    {
        // our active pet HP % in 0-1 range (not in 0-100!)
        public static float hp { get { return MyPets.hp(); } }

        // enemy active pet HP % in 0-1 range (not in 0-100!)
        public static float hpEnemy { get { return MyPets.hpEnemy(); } }

        // our active pet speed
        public static int speed { get { return MyPets.ActivePet.Speed; } }
        // enemy active pet speed
        public static int speedEnemy { get { return MyPets.ActivePet.Speed; } }

        // is "spell" aura on our team or on our active pet?
        public static bool buff(string spell) { return MyPets.buff(spell); }
        // number of turns left for such an aura (-1 if the aura is absent)
        public static int buffLeft(string spell) { return MyPets.buffLeft(spell); }
        // is "spell" aura is on the enemy team or on the enemy active pet?
        public static bool debuff(string spell) { return MyPets.debuff(spell); }

        // current weather, "" if none.
        public static bool weather(string name) { return MyPets.Weather == name; }

        // has enemy used Burrow, Lift-off, Chew or Dive? (invulnerable now + big hit next round)
        public static bool shouldIHide { get { return MyPets.shouldIHide(); } }
    }
}
