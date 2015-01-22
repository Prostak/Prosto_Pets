///////////////////////
// BEAST PET TACTICS //
///////////////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Beast : PetTacticsBase
    {

        public static List<AandC> GetSpellTable()
        {
            return GetSpellTable(MyPets.ActivePet.Name);
        }

        public static List<AandC> GetSpellTable(string petName)
        {
            if (string.IsNullOrEmpty(petName))
            {
                petName = MyPets.ActivePet.Name;
            }

            List<AandC> beast_abilities;

            switch (petName)
            {
                case "Adder": 
                case "Albino Snake": 
                case "Ash Viper": 
                case "Black Kingsnake": 
                case "Brown Snake": 
                case "Cobra Hatchling": 
                case "Coral Adder": 
                case "Coral Snake": 
                case "Crimson Snake": 
                case "Emerald Boa": 
                case "Grove Viper": 
                case "King Snake": 
                case "Moccasin": 
                case "Rat Snake": 
                case "Rattlesnake": 
                case "Rock Viper": 
                case "Sidewinder": 
                case "Snake": 
                case "Temple Snake": 
                case "Tree Python": 
                case "Water Snake": 
                case "Zooey Snake":
                    /* Abilities:
                     * Slot 1: Bite     | Poison Fang
                     * Slot 2: Hiss     | Counterstrike
                     * Slot 3: Burrow   | Vicious Fang
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow"),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                        new AandC("Hiss"),
                        new AandC("Counterstrike"),
                        new AandC("Vicious Fang"),
                    };
                    break;


                case "Albino River Calf":
                case "Flat-Tooth Calf":
                case "Mudback Calf":
                    /* Changelog:
                     * 2015-01-20: Clobber is now checking for all stun and resilience effects - Studio60
                     * 2015-01-19: Clobber is only used if the enemy is not Resilient - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Water Jet
                     * Slot 2: Takedown | Stoneskin
                     * Slot 3: Clobber  | Headbutt
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Takedown",   () => enemyIsStunned()),
                        new AandC("Stoneskin",  () => ! buff("Stoneskin")),
                        new AandC("Clobber",    () => ! enemyIsResilient() && ! enemyIsStunned()),
                        new AandC("Headbutt"),
                        new AandC("Bite"),
                        new AandC("Water Jet"),
                    };
                    break;

                case "Alpine Foxling":
                case "Alpine Foxling Kit":
                case "Arctic Fox Kit": 
                case "Fjord Worg Pup": 
                case "Fox Kit": 
                case "Worg Pup":
                    /* Abilities:
                     * Slot 1: Bite     | Flurry
                     * Slot 2: Crouch   | Howl
                     * Slot 3: Leap     | Dazzling Dance
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Dazzling Dance",   () => speed < speedEnemy && ! buff("Dazzling Dance")),
                        new AandC("Leap",             () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Bite"),
                        new AandC("Flurry"),
                        new AandC("Crouch"),
                        new AandC("Howl"),
                    };
                    break;

                case "Alterac Brew-Pup":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite             | Bark
                     * Slot 2: The Good Stuff   | Tough n' Cuddly
                     * Slot 3: Avalanche        | Call the Pack
                     * 
                     * TODO: The Good Stuff needs to check if own team needs heal
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Tough n' Cuddly",    () => ! buff("Tough n' Cuddly")),
                        new AandC("Avalanche"),
                        new AandC("Call the Pack"),
                        new AandC("Bite"),
                        new AandC("Bark"),
                        new AandC("The Good Stuff"),
                    };
                    break;

                case "Amethyst Spiderling": 
                case "Ash Spiderling": 
                case "Desert Spider": 
                case "Dusk Spiderling": 
                case "Feverbite Hatchling": 
                case "Forest Spiderling": 
                case "Jumping Spider": 
                case "Skittering Cavern Crawler": 
                case "Smolderweb Hatchling": 
                case "Spider": 
                case "Twilight Spider": 
                case "Venomspitter Hatchling": 
                case "Widow Spiderling":
                    /* Abilities:
                     * Slot 1: Strike       | Poison Spit
                     * Slot 2: Sticky Web   | Brittle Webbing
                     * Slot 3: Leech Life   | Spiderling Swarm
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Sticky Web",       () => ! debuff("Webbed")),
                        new AandC("Brittle Webbing",  () => ! debuff("Brittle Webbing")),
                        new AandC("Leech Life",       () => debuff("Webbed") || debuff("Brittle Webbing")),
                        new AandC("Spiderling Swarm", () => debuff("Webbed") || debuff("Brittle Webbing")),
                        new AandC("Strike"),
                        new AandC("Poison Spit"),
                    };
                    break;

                case "Argi":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Gnaw                 | Horn Gore
                     * Slot 2: Gift of the Naaru    | Chew
                     * Slot 3: Stampede             | Headbutt
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Gift of the Naaru",  () => hp < 0.7),
                        new AandC("Chew"),
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses")),
                        new AandC("Headbutt"),
                        new AandC("Gnaw"),
                        new AandC("Horn Gore"),
                    };
                    break;

                case "Ash Lizard": 
                case "Diemetradon Hatchling": 
                case "Horned Lizard": 
                case "Lizard Hatchling": 
                case "Plains Monitor": 
                case "Spiky Lizard": 
                case "Spiny Lizard": 
                case "Twilight Iguana":
                    /* Abilities:
                     * Slot 1: Claw     | Quick Attack
                     * Slot 2: Screech  | Triple Snap
                     * Slot 3: Comeback | Ravage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Claw"),
                        new AandC("Quick Attack"),
                        new AandC("Screech"),
                        new AandC("Triple Snap"),
                        new AandC("Comeback"),
                        new AandC("Ravage"),
                    };
                    break;

                case "Baby Ape": 
                case "Bananas": 
                case "Darkmoon Monkey":
                    /* Abilities:
                     * Slot 1: Smash            | Rake
                     * Slot 2: Roar             | Clobber
                     * Slot 3: Banana Barrage   | Barrel Toss
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Smash"),
                        new AandC("Rake"),
                        new AandC("Roar"),
                        new AandC("Clobber"),
                        new AandC("Banana Barrage"),
                        new AandC("Barrel Toss"),
                    };
                    break;

                case "Baby Blizzard Bear":
                case "Poley":
                    /* Abilities:
                     * Slot 1: Bite | Roar
                     * Slot 2: Bash | Hibernate
                     * Slot 3: Maul | Call Blizzard
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Roar"),
                        new AandC("Bash"),
                        new AandC("Hibernate"),
                        new AandC("Maul"),
                        new AandC("Call Blizzard"),
                    };
                    break;

                case "Black Tabby Cat": 
                case "Bombay Cat": 
                case "Calico Cat": 
                case "Cat": 
                case "Cheetah Cub": 
                case "Cornish Rex Cat": 
                case "Darkmoon Cub": 
                case "Nightsaber Cub": 
                case "Orange Tabby Cat": 
                case "Panther Cub": 
                case "Sand Kitten": 
                case "Siamese Cat": 
                case "Silver Tabby Cat": 
                case "Snow Cub": 
                case "White Kitten": 
                case "Winterspring Cub":
                    /* Abilities:
                     * Slot 1: Claw     | Pounce
                     * Slot 2: Rake     | Screech
                     * Slot 3: Devour   | Prowl
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour", () => hpEnemy < 0.20 ),
                        new AandC("Claw"),
                        new AandC("Pounce"),
                        new AandC("Rake"),
                        new AandC("Screech"),
                        new AandC("Prowl"),
                    };
                    break;

                case "Bucktooth Flapper":
                    /* Abilities:
                     * Slot 1: Tail Slap    | Gnaw
                     * Slot 2: Screech      | Survival
                     * Slot 3: Woodchipper  | Chew
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival", () => hp < 0.3 ),
                        new AandC("Tail Slap"),
                        new AandC("Gnaw"),
                        new AandC("Screech"),
                        new AandC("Woodchipper"),
                        new AandC("Chew"),
                    };
                    break;

                case "Clefthoof Runt":
                    /* Abilities:
                     * Slot 1: Smash | Trample
                     * Slot 2: Survival | Trumpet Strike
                     * Slot 3: Horn Attack | Stampede
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",         () => hp < 0.3),
                        new AandC("Smash"),
                        new AandC("Trample"),
                        new AandC("Trumpet Strike"),
                        new AandC("Horn Attack"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Clouded Hedgehog":
                    /* Abilities:
                     * Slot 1: Bite             | Poison Fang
                     * Slot 2: Survival         | Spiked Skin
                     * Slot 3: Counterstrike    | Powerball
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",         () => hp < 0.3 ),
                        new AandC("Counterstrike",    () =>  speed < speedEnemy ),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                        new AandC("Spiked Skin"),
                        new AandC("Powerball"),
                    };
                    break;

                case "Crunchy Scorpion": 
                case "Durotar Scorpion": 
                case "Leopard Scorpid": 
                case "Scorpid": 
                case "Scorpling": 
                case "Stripe-Tailed Scorpid":
                    /* Abilities:
                     * Slot 1: Snap     | Triple Snap
                     * Slot 2: Crouch   | Screech
                     * Slot 3: Sting    | Rampage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Crouch"),
                        new AandC("Sting",        () => ! debuff("Sting")),
                        new AandC("Snap"),
                        new AandC("Triple Snap"),
                        new AandC("Screech"),
                        new AandC("Rampage"),
                    };
                    break;

                case "Crystal Spider":
                    /* Abilities:
                     * Slot 1: Strike | Crystal Prison
                     * Slot 2: Sticky Web | Brittle Webbing
                     * Slot 3: Leech Life | Spiderling Swarm
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Leech Life", () => hp < 0.7),
                        new AandC("Strike"),
                        new AandC("Crystal Prison"),
                        new AandC("Sticky Web"),
                        new AandC("Brittle Webbing"),
                        new AandC("Spiderling Swarm"),
                    };
                    break;

                case "Darkshore Cub": 
                case "Dun Morogh Cub": 
                case "Hyjal Bear Cub": 
                case "Panda Cub":
                    /* Abilities:
                     * Slot 1: Bite         | Roar
                     * Slot 2: Hibernate    | Bash
                     * Slot 3: Maul         | Rampage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Roar"),
                        new AandC("Hibernate"),
                        new AandC("Bash"),
                        new AandC("Maul"),
                        new AandC("Rampage"),
                    };
                    break;

                case "Darting Hatchling": 
                case "Deviate Hatchling": 
                case "Gundrak Hatchling": 
                case "Lashtail Hatchling": 
                case "Leaping Hatchling": 
                case "Obsidian Hatchling": 
                case "Ravasaur Hatchling": 
                case "Razormaw Hatchling": 
                case "Razzashi Hatchling":
                    /* Abilities:
                     * Slot 1: Bite     | Flank
                     * Slot 2: Leap     | Screech
                     * Slot 3: Devour   | Exposed Wounds
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",           () => hpEnemy < 0.20 ),
                        new AandC("Leap",             () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Bite"),
                        new AandC("Flank"),
                        new AandC("Screech"),
                        new AandC("Exposed Wounds"),
                    };
                    break;

                case "Deathwatch Hatchling":
                    /* Changelog:
                     * 2015-01-20: Clobber is now checking for all stun and resilience effects - Studio60
                     *             Takedown is now checking for all stun effects - Studio60
                     * 2015-01-19: Clobber is only used if the enemy is not Resilient - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Woodchipper  | Bite
                     * Slot 2: Feed         | Clobber
                     * Slot 3: Takedown     | Leap
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Feed",           () => hp < 0.7),
                        new AandC("Clobber",        () => ! enemyIsStunned() && ! enemyIsResilient()),
                        new AandC("Takedown",       () => enemyIsStunned()),
                        new AandC("Leap"),
                        new AandC("Woodchipper"),
                        new AandC("Bite"),
                    };
                    break;

                case "Death Adder Hatchling":
                    /* Abilities:
                     * Slot 1: Poison Fang      | Vicious Fang
                     * Slot 2: Puncture Wound   | Crouch
                     * Slot 3: Burrow           | Blinding Poison
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow"),
                        new AandC("Poison Fang"),
                        new AandC("Vicious Fang"),
                        new AandC("Puncture Wound"),
                        new AandC("Crouch"),
                        new AandC("Blinding Poison"),
                    };
                    break;

                case "Devouring Maggot": 
                case "Festering Maggot": 
                case "Jungle Grub": 
                case "Larva": 
                case "Maggot": 
                case "Mr. Grubbs":
                    /* Abilities:
                     * Slot 1: Chomp | Consume
                     * Slot 2: Acidic Goo | Sticky Goo
                     * Slot 3: Leap | Burrow
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Leap",         () => ! buff("Speed Boost") && (speed < speedEnemy)),
                        new AandC("Acidic Goo",   () => ! debuff("Acidic Goo")),
                        new AandC("Chomp"),
                        new AandC("Consume"),
                        new AandC("Sticky Goo"),
                        new AandC("Burrow"),
                    };
                    break;

                case "Direhorn Runt": 
                case "Pygmy Direhorn": 
                case "Stunted Direhorn":
                    /* Abilities:
                     * Slot 1: Trihorn Charge   | Trample
                     * Slot 2: Horn Attack      | Stampede
                     * Slot 3: Primal Cry       | Trihorn Shield
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Trihorn Charge"),
                        new AandC("Trample"),
                        new AandC("Horn Attack"),
                        new AandC("Stampede"),
                        new AandC("Primal Cry"),
                        new AandC("Trihorn Shield"),
                    };
                    break;

                case "Elder Python":
                    /* Abilities:
                     * Slot 1: Bite     | Poison Fang
                     * Slot 2: Sting    | Huge Fang
                     * Slot 3: Burrow   | Slither
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                        new AandC("Sting"),
                        new AandC("Huge Fang"),
                        new AandC("Burrow"),
                        new AandC("Slither"),
                    };
                    break;

                case "Feline Familiar":
                    /* Abilities:
                     * Slot 1: Onyx Bite    | Pounce
                     * Slot 2: Stoneskin    | Call Darkness
                     * Slot 3: Devour       | Prowl
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",           () => hpEnemy < 0.20),
                        new AandC("Onyx Bite"),
                        new AandC("Pounce"),
                        new AandC("Stoneskin"),
                        new AandC("Call Darkness"),
                        new AandC("Prowl"),
                    };
                    break;

                case "Frostwolf Pup":
                    /* Changelog:
                     * 2015-01-20: Howl now correctly considers the "Shattered Defenses" debuff on the enemy - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Flurry
                     * Slot 2: Crouch   | Howl
                     * Slot 3: Maul     | Vengeance
                     * 
                     * TODO: Vengeance should know how large the last hit was
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Crouch",     () => ! buff("Crouch")),
                        new AandC("Howl",       () => ! debuff("Shattered Defenses")),
                        new AandC("Maul"),
                        new AandC("Bite"),
                        new AandC("Flurry"),
                        new AandC("Vengeance"),
                    };
                    break;

                case "Giraffe Calf":
                    /* Abilities:
                     * Slot 1: Hoof         | Stampede
                     * Slot 2: Tranquility  | Survival
                     * Slot 3: Headbutt     | Bleat
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",     () => hp < 0.3),
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Stampede"),
                        new AandC("Tranquility"),
                        new AandC("Bleat"),
                    };
                    break;

                case "Icespine Hatchling":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Gnaw             | Bite
                     * Slot 2: Ravage           | Body Slam
                     * Slot 3: Puncture Wound   | Takedown
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Ravage",         () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Body Slam"),
                        new AandC("Puncture Wound"),
                        new AandC("Takedown"),
                        new AandC("Gnaw"),
                        new AandC("Bite"),
                    };
                    break;

                case "Leatherhide Runt":
                    /* Changelog:
                     * 2015-01-20: Survival is now only used to hide from huge attacks if it is faster or of both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Smash        | Trample
                     * Slot 2: Survival     | Trumpet Strike
                     * Slot 3: Horn Attack  | Stampede
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Survival",       () => shouldIHide && hp < 0.3 && speed >= speedEnemy),
                        new AandC("Trumpet Strike", () => ! buff("Attack Boost")),
                        new AandC("Horn Attack"),
                        new AandC("Stampede",       () => ! debuff("Shattered Defenses")),
                        new AandC("Smash"),
                        new AandC("Trample"),
                    };
                    break;

                case "Little Black Ram":
                case "Summit Kid":
                    /* Abilities:
                     * Slot 1: Hoof     | Chew
                     * Slot 2: Comeback | Soothe
                     * Slot 3: Headbutt | Stampede
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Chew"),
                        new AandC("Comeback"),
                        new AandC("Soothe"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Kovok":
                    /* Abilities:
                     * Slot 1: Poison Fang  | Body Slam
                     * Slot 2: Pheromones   | Digest Brains
                     * Slot 3: Black Claw   | Puncture Wound
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Poison Fang"),
                        new AandC("Body Slam"),
                        new AandC("Pheromones"),
                        new AandC("Digest Brains"),
                        new AandC("Black Claw"),
                        new AandC("Puncture Wound"),
                    };
                    break;

                case "Meadowstomper Calf":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Trample      | Smash
                     * Slot 2: Primal Cry   | Tough n' Cuddly
                     * Slot 3: Headbutt     | Stampede
                     */
                    // stampede: not doing it twice in a row
                    beast_abilities = new List<AandC>() {
                        new AandC("Primal Cry",         () => ! debuff("Speed Reduction")),
                        new AandC("Tough n' Cuddly",    () => ! buff("Tough n' Cuddly")),
                        new AandC("Headbutt"),
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses")),
                        new AandC("Trample"),
                        new AandC("Smash"),
                    };
                    break;

                case "Molten Hatchling":
                    /* Abilities:
                     * Slot 1: Burn         | Leech Life
                     * Slot 2: Sticky Web   | Cauterize
                     * Slot 3: Magma Wave   | Brittle Webbing
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Burn"),
                        new AandC("Leech Life"),
                        new AandC("Sticky Web"),
                        new AandC("Cauterize"),
                        new AandC("Magma Wave"),
                        new AandC("Brittle Webbing"),
                    };
                    break;

                case "Moon Moon":
                    /* Abilities:
                     * Slot 1: Moon Fang    | Bite
                     * Slot 2: Howl         | Crouch
                     * Slot 3: Moon Tears   | Moon Dance
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Moon Fang"),
                        new AandC("Bite"),
                        new AandC("Howl"),
                        new AandC("Crouch"),
                        new AandC("Moon Tears"),
                        new AandC("Moon Dance"),
                    };
                    break;

                case "Mossbite Skitterer":
                    /* Abilities:
                     * Slot 1: Gnaw | Bite
                     * Slot 2: Ravage | Body Slam
                     * Slot 3: Puncture Wound | Takedown
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Gnaw",             () => speed > speedEnemy),
                        new AandC("Ravage",           () => hpEnemy < 0.2),
                        new AandC("Puncture Wound",   () => debuff("Poisoned")),
                        new AandC("Takedown",         () => debuff("Stunned")),
                        new AandC("Body Slam"),
                        new AandC("Gnaw"),
                        new AandC("Bite"),
                    };
                    break;

                case "Mountain Panda":
                    /* Abilities:
                     * Slot 1: Bite | Scratch
                     * Slot 2: Cute Face | Rock Barrage
                     * Slot 3: Burrow | Mudslide
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Scratch"),
                        new AandC("Cute Face"),
                        new AandC("Rock Barrage"),
                        new AandC("Burrow"),
                        new AandC("Mudslide"),
                    };
                    break;

                case "Parched Lizard":
                    /* Changelog:
                     * 2015-01-20: Conflagrate been added - Studio60
                     *             Screech is now used if it is not already active - Studio60
                     *             Comeback is now only used if pet health is lower than enemy health - Studio60
                     *             Ravage is now used on enemies with low health - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw | Quick Attack
                     * Slot 2: Screech | Conflagrate
                     * Slot 3: Comeback | Ravage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Screech",      () => ! debuff("Speed Reduction")),
                        new AandC("Conflagrate",  () => enemyIsBurning()),
                        new AandC("Comeback",     () => hp < hpEnemy),
                        new AandC("Ravage",       () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Claw"),
                        new AandC("Quick Attack"),
                    };
                    break;
                
                case "Ravager Hatchling":
                    /* Abilities:
                     * Slot 1: Bite     | Rend
                     * Slot 2: Screech  | Sting
                     * Slot 3: Devour   | Rampage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour", () => hpEnemy < 0.20),
                        new AandC("Bite"),
                        new AandC("Rend"),
                        new AandC("Screech"),
                        new AandC("Sting"),
                        new AandC("Rampage"),
                    };
                    break;

                case "Red Panda":
                    /* Abilities:
                     * Slot 1: Bite     | Scratch
                     * Slot 2: Crouch   | Cute Face
                     * Slot 3: Perk Up  | Hibernate
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Scratch"),
                        new AandC("Crouch"),
                        new AandC("Cute Face"),
                        new AandC("Perk Up"),
                        new AandC("Hibernate"),
                    };
                    break;

                case "Scalded Basilisk Hatchling":
                    /* Abilities:
                     * Slot 1: Bite     | Crystal Prison
                     * Slot 2: Roar     | Feign Death
                     * Slot 3: Thrash   | Screech
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Crystal Prison"),
                        new AandC("Roar"),
                        new AandC("Feign Death"),
                        new AandC("Thrash"),
                        new AandC("Screech"),
                    };
                    break;

                case "Silent Hedgehog":
                    /* Abilities:
                     * Slot 1: Bite         | Poison Fang
                     * Slot 2: Spiked Skin  | Counterstrike
                     * Slot 3: Survival     | Powerball
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",         () => hp < 0.3 ),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                        new AandC("Spiked Skin"),
                        new AandC("Counterstrike"),
                        new AandC("Powerball"),
                    };
                    break;

                case "Silithid Hatchling":
                    /* Abilities:
                     * Slot 1: Scratch  | Devour
                     * Slot 2: Hiss     | Survival
                     * Slot 3: Swarm    | Sandstorm
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",     () => hp < 0.3),
                        new AandC("Devour",       () => hpEnemy < 0.20 ),
                        new AandC("Scratch"),
                        new AandC("Hiss"),
                        new AandC("Swarm"),
                        new AandC("Sandstorm"),
                    };
                    break;

                case "Snowy Panda":
                    /* Abilities:
                     * Slot 1: Bite         | Snowball
                     * Slot 2: Cute Face    | Call Blizzard
                     * Slot 3: Crouch       | Ice Barrier
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Snowball"),
                        new AandC("Cute Face"),
                        new AandC("Call Blizzard"),
                        new AandC("Crouch"),
                        new AandC("Ice Barrier"),
                    };
                    break;

                case "Stunted Shardhorn":
                    /* Abilities:
                     * Slot 1: Smash            | Survival
                     * Slot 2: Trample          | Horn Attack
                     * Slot 3: Trumpet Strike   | Stampede
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival", () => hp < 0.3),
                        new AandC("Smash"),
                        new AandC("Trample"),
                        new AandC("Horn Attack"),
                        new AandC("Trumpet Strike"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Sumprush Rodent":
                    /* Abilities:
                     * Slot 1: Gnaw     | Tail Slap
                     * Slot 2: Mudslide | Poison Fang
                     * Slot 3: Survival | Stench
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",         () => hp < 0.3),
                        new AandC("Bite"),
                        new AandC("Powerball"),
                        new AandC("Spirit Spikes"),
                        new AandC("Flank"),
                        new AandC("Vengeance"),
                    };
                    break;

                case "Sunfur Panda":
                    /* Abilities:
                     * Slot 1: Bite         | Scratch
                     * Slot 2: Hibernate    | Cute Face
                     * Slot 3: Sunlight     | Crouch
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bite"),
                        new AandC("Scratch"),
                        new AandC("Hibernate"),
                        new AandC("Cute Face"),
                        new AandC("Sunlight"),
                        new AandC("Crouch"),
                    };
                    break;

                case "Thicket Skitterer":
                    /* Changelog:
                     * 2015-01-20: Ravage is now used on enemies with low health - Studio60
                     *             Puncture Wound is now checking for all poison effects - Studio60
                     *             Takedown is now checking for all stun effects - Studio60
                     *             Body Slam is now only used if it is effective - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Gnaw             | Bite
                     * Slot 2: Ravage           | Body Slam
                     * Slot 3: Puncture Wound   | Takedown
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Gnaw",           () => speed > speedEnemy ),
                        new AandC("Ravage",         () => hpEnemy < 0.25 || (famEnemy(PF.Critter) && hpEnemy > 0.4)),
                        new AandC("Puncture Wound", () => enemyIsPoisoned()),
                        new AandC("Takedown",       () => enemyIsStunned()),
                        new AandC("Body Slam",      () => strong("Body Slam")),
                        new AandC("Gnaw"),
                        new AandC("Bite"),
                    };
                    break;

                case "Tito":
                    /* Abilities:
                     * Slot 1: Bite     | Triple Snap
                     * Slot 2: Impale   | Howl
                     * Slot 3: Cyclone  | Buried Treasure
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Bite"),
                        new AandC("Triple Snap"),
                        new AandC("Impale"),
                        new AandC("Howl"),
                        new AandC("Buried Treasure"),
                    };
                    break;

                case "Vengeful Porcupette":
                    /* Abilities:
                     * Slot 1: Bite             | Powerball
                     * Slot 2: Spirit Spikes    | Survival
                     * Slot 3: Flank            | Vengeance
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival", () => hp < 0.3 ),
                        new AandC("Gnaw"),
                        new AandC("Tail Slap"),
                        new AandC("Mudslide"),
                        new AandC("Poison Fang"),
                        new AandC("Stench"),
                    };
                    break;

                case "Warpstalker Hatchling":
                    /* Abilities:
                     * Slot 1: Claw     | Blinkstrike
                     * Slot 2: Screech  | Triple Snap
                     * Slot 3: Ravage   | Comeback
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Claw"),
                        new AandC("Blinkstrike"),
                        new AandC("Screech"),
                        new AandC("Triple Snap"),
                        new AandC("Ravage"),
                        new AandC("Comeback"),
                    };
                    break;

                case "Wind Rider Cub":
                    /* Abilities:
                     * Slot 1: Bite         | Squawk
                     * Slot 2: Slicing Wind | Adrenaline Rush
                     * Slot 3: Flock        | Lift-OFf
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off"),
                        new AandC("Bite"),
                        new AandC("Squawk"),
                        new AandC("Slicing Wind"),
                        new AandC("Adrenaline Rush"),
                        new AandC("Flock"),
                    };
                    break;

                case "Xu-Fu, Cub of Xuen":
                    /* Abilities:
                     * Slot 1: Spirit Claws | Bite
                     * Slot 2: Feed         | Moonfire
                     * Slot 3: Vengeance    | Prowl
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Spirit Claws"),
                        new AandC("Bite"),
                        new AandC("Feed"),
                        new AandC("Moonfire"),
                        new AandC("Vengeance"),
                        new AandC("Prowl"),
                    };
                    break;

                case "Zandalari Anklerender":
                    /* Abilities:
                     * Slot 1: Bite | Hunting Party
                     * Slot 2: Leap | Primal Cry
                     * Slot 3: Devour | Black Claw
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",         () => hpEnemy < 0.20 ),
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Black Claw",     () => ! debuff("Black Claw")),
                        new AandC("Bite"),
                        new AandC("Hunting Party"),
                        new AandC("Primal Cry"),
                        new AandC("Leap"),
                    };
                    break;

                case "Zandalari Footslasher":
                    /* Abilities:
                     * Slot 1: Bite         | Hunting Party
                     * Slot 2: Leap         | Primal Cry
                     * Slot 3: Bloodfang    | Exposed Wounds
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Bite"),
                        new AandC("Hunting Party"),
                        new AandC("Primal Cry"),
                        new AandC("Bloodfang"),
                        new AandC("Exposed Wounds"),
                    };
                    break;

                case "Zandalari Kneebiter":
                    /* Abilities:
                     * Slot 1: Bite     | Hunting Party
                     * Slot 2: Screech  | Black Claw
                     * Slot 3: Leap     | Bloodfang
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Leap", () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Black Claw", () => !debuff("Black Claw")),
                        new AandC("Bite"),
                        new AandC("Hunting Party"),
                        new AandC("Screech"),
                        new AandC("Bloodfang"),
                        new AandC("Leap"),
                    };
                    break;

                case "Zandalari Toenibbler":
                    /* Abilities:
                     * Slot 1: Bite         | Flank
                     * Slot 2: Leap         | Primal Cry
                     * Slot 3: Bloodfang    | Black Claw
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Leap",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Black Claw", () => !debuff("Black Claw")),
                        new AandC("Bite"),
                        new AandC("Flank"),
                        new AandC("Primal Cry"),
                        new AandC("Bloodfang"),
                        new AandC("Leap"),
                    };
                    break;

                case "Zao, Calfling of Niuzao":
                    /* Abilities:
                     * Slot 1: Trample          | Horn Gore
                     * Slot 2: Headbutt         | Wish
                     * Slot 3: Niuzao's Charge  | Dominance
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Headbutt"),
                        new AandC("Trample"),
                        new AandC("Horn Gore"),
                        new AandC("Wish"),
                        new AandC("Niuzao's Charge"),
                        new AandC("Dominance"),
                    };
                    break;

                default:
                    ///////////////////////
                    // Unknown Beast Pet //
                    ///////////////////////
                    Logger.Alert("Unknown beast pet: " + petName);
                    beast_abilities = null;
                    break;
            }

            return beast_abilities;
        }
    }
}