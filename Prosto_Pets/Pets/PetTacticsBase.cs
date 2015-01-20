using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosto_Pets
{

    public enum PF
    { 
        Humanoid = 1,
        Dragonkin = 2,
        Flying = 3,
        Undead = 4,
        Critter = 5,
        Magic = 6,
        Elemental = 7,
        Beast = 8,
        Aquatic = 9,
        Mechanical = 10
    }

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
        public static int speedEnemy { get { return MyPets.EnemyActivePet.Speed; } }

        // is "spell" aura on our team or on our active pet?
        public static bool buff(string spell) { return MyPets.buff(spell); }
        // number of turns left for such an aura (-1 if the aura is absent)
        public static int buffLeft(string spell) { return MyPets.buffLeft(spell); }
        // is "spell" aura is on the enemy team or on the enemy active pet?
        public static bool debuff(string spell) { return MyPets.debuff(spell); }
        // number of turns left for such an aura (-1 if the aura is absent)
        public static int debuffLeft(string spell) { return MyPets.debuffLeft(spell); }

        // current weather, "" if none.
        public static bool weather(string name) { return MyPets.Weather == name; }

        // has enemy used Burrow, Lift-off, Chew or Dive? (invulnerable now + big hit next round)
        public static bool shouldIHide { get { return MyPets.shouldIHide(); } }

        // checking type of our active pet
        public static bool family(PF checkFamily) { return MyPets.ActivePet.PetType == (int)checkFamily; }
        // checking type of enemy active pet
        public static bool famEnemy(PF checkFamily) { return MyPets.EnemyActivePet.PetType == (int)checkFamily; }

        // checking if our ability is strong against the current enemy pet
        public static bool strong(string ability) { return MyPets.IsStrong(ability); }
        // checking if our ability is weak against the current enemy pet
        public static bool weak(string ability) { return MyPets.IsWeak(ability); }

        // checking for general conditions caused by multiple effects
        public static bool enemyIsAsleep() { return MyPets.enemyIsAsleep(); }
        public static bool enemyIsBleeding() { return MyPets.enemyIsBleeding(); }
        public static bool enemyIsBlinded() { return MyPets.enemyIsBlinded(); }
        public static bool enemyIsBurning() { return MyPets.enemyIsBurning(); }
        public static bool enemyIsChilled() { return MyPets.enemyIsChilled(); }
        public static bool enemyIsPoisoned() { return MyPets.enemyIsPoisoned(); }
        public static bool enemyIsResilient() { return MyPets.enemyIsResilient(); }
        public static bool enemyIsStunned() { return MyPets.enemyIsStunned(); }

        public static bool myPetIsAsleep() { return MyPets.myPetIsAsleep(); }
        public static bool myPetIsBurning() { return MyPets.myPetIsBurning(); }
        public static bool myPetIsBlinded() { return MyPets.myPetIsBlinded(); }
        public static bool myPetIsBleeding() { return MyPets.myPetIsBleeding(); }
        public static bool myPetIsChilled() { return MyPets.myPetIsChilled(); }
        public static bool myPetIsPoisoned() { return MyPets.myPetIsPoisoned(); }
        public static bool myPetIsResilient() { return MyPets.myPetIsResilient(); }
        public static bool myPetIsStunned() { return MyPets.myPetIsStunned(); }
        
    }
}
