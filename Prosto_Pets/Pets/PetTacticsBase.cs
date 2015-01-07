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
        public static float hp { get { return MyPets.hp(); } }
        public static float hpEnemy { get { return MyPets.hpEnemy(); } }
        public static int speed { get { return MyPets.ActivePet.Speed; } }
        public static int speedEnemy { get { return MyPets.ActivePet.Speed; } }
        public static bool buff(string spell) { return MyPets.buff(spell); }
        public static int buffLeft(string spell) { return MyPets.buffLeft(spell); }
        public static bool debuff(string spell) { return MyPets.debuff(spell); }
        public static bool weather(string name) { return MyPets.Weather == name; }
        public static bool shouldIHide { get { return MyPets.shouldIHide(); } }
    }
}
