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
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Poison Fang
                     * Slot 2: Hiss     | Counterstrike
                     * Slot 3: Burrow   | Vicious Fang
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Hiss",           () => ! debuff("Speed Reduction")),
                        new AandC("Counterstrike",  () => speed < speedEnemy),
                        new AandC("Counterstrike",  () => weak("Bite")),
                        new AandC("Vicious Fang"),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
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
                    /* Changelog:
                     * 2015-01-23: Revised existing tactic - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Flurry
                     * Slot 2: Crouch   | Howl
                     * Slot 3: Leap     | Dazzling Dance
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Dazzling Dance", () => ! buff("Dazzling Dance")),
                        new AandC("Howl",           () => ! debuff("Shattered Defenses")),
                        new AandC("Crouch",         () => ! buff("Crouch")),
                        new AandC("Leap",           () => myPetHasAbility("Flurry") && (weak("Flurry") || strong("Leap"))),
                        new AandC("Bite"),
                        new AandC("Flurry"),
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
                     * 
                     * TODO: Add global Webbed check
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
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw     | Quick Attack
                     * Slot 2: Screech  | Triple Snap
                     * Slot 3: Comeback | Ravage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Ravage",         () => hpEnemy < 0.2),
                        new AandC("Ravage",         () => strong("Ravage") && hpEnemy < 0.3),
                        new AandC("Comeback",       () => ! weak("Comeback") && hp < hpEnemy),
                        new AandC("Screech",        () => ! debuff("Speed Reduction")),
                        new AandC("Triple Snap",    () => myPetHasAbility("Quick Attack") && weak("Quick Attack")),
                        new AandC("Claw"),
                        new AandC("Quick Attack"),
                    };
                    break;

                case "Baby Ape":
                case "Bananas":
                case "Darkmoon Monkey":
                    /* Changelog: 
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Smash            | Rake
                     * Slot 2: Roar             | Clobber
                     * Slot 3: Banana Barrage   | Barrel Toss
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Barrel Toss",        () => ! buff("Barrel Ready") && hpEnemy > 0.4),
                        new AandC("Barrel Toss",        () => buff("Barrel Ready")),
                        new AandC("Banana Barrage",     () => ! debuff("Banana Barrage")),
                        new AandC("Roar",               () => ! buff("Attack Boost")),
                        new AandC("Clobber",            () => ! enemyIsStunned() && ! enemyIsResilient()),
                        new AandC("Smash"),
                        new AandC("Rake"),
                    };
                    break;

                case "Baby Blizzard Bear":
                case "Poley":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Bite | Roar
                     * Slot 2: Bash | Hibernate
                     * Slot 3: Maul | Call Blizzard
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Hibernate",      () => hp < 0.5),
                        new AandC("Maul",           () => enemyIsBleeding()),
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Call Blizzard",  () => ! weather("Blizzard")),
                        new AandC("Bash",           () => ! enemyIsStunned() && ! enemyIsResilient()),
                        new AandC("Maul"),
                        new AandC("Bite"),
                        new AandC("Roar"),
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
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw     | Pounce
                     * Slot 2: Rake     | Screech
                     * Slot 3: Devour   | Prowl
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",     () => hpEnemy < 0.2),
                        new AandC("Devour",     () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Screech",    () => ! debuff("Speed Reduction") && speed < speedEnemy),
                        new AandC("Prowl",      () => speed * 0.7 > speedEnemy),
                        new AandC("Prowl",      () => ! myPetHasAbility("Screech")),
                        new AandC("Rake",       () => myPetHasAbility("Pounce") && speed < speedEnemy),
                        new AandC("Claw"),
                        new AandC("Pounce"),
                    };
                    break;

                case "Bucktooth Flapper":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Tail Slap    | Gnaw
                     * Slot 2: Screech      | Survival
                     * Slot 3: Woodchipper  | Chew
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Screech",        () => ! debuff("Speed Reduction")),
                        new AandC("Chew",           () => hpEnemy > 0.25),
                        new AandC("Woodchipper",    () => ! debuff("Bleeding")),
                        new AandC("Woodchipper",    () => myPetHasAbility("Gnaw") && speed < speedEnemy),
                        new AandC("Tail Slap"),
                        new AandC("Gnaw"),
                    };
                    break;

                case "Clefthoof Runt":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Smash | Trample
                     * Slot 2: Survival | Trumpet Strike
                     * Slot 3: Horn Attack | Stampede
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Trumpet Strike", () => ! buff("Attack Boost")),
                        new AandC("Horn Attack"),
                        new AandC("Stampede",       () => ! debuff("Shattered Defenses")),
                        new AandC("Smash"),
                        new AandC("Trample"),
                    };
                    break;

                case "Clouded Hedgehog":
                    /* Changelog: 
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Bite             | Poison Fang
                     * Slot 2: Survival         | Spiked Skin
                     * Slot 3: Counterstrike    | Powerball
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Spiked Skin",    () => ! buff("Spiked Skin") && hpEnemy > 0.2),
                        new AandC("Spiked Skin",    () => buffLeft("Spiked Skin") == 1 && speed < speedEnemy && hpEnemy > 0.2),
                        new AandC("Poison Fang",    () => ! weak("Poison Fang") && ! debuff("Poisoned")),
                        new AandC("Counterstrike",  () => speed < speedEnemy),
                        new AandC("Counterstrike",  () => myPetHasAbility("Bite") && weak("Bite")),
                        new AandC("Counterstrike",  () => myPetHasAbility("Poison Fang") && weak("Poison Fang")),
                        new AandC("Counterstrike",  () => strong("Counterstrike")),
                        new AandC("Powerball",      () => weak("Bite") || strong("Powerball")),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                    };
                    break;

                case "Crunchy Scorpion":
                case "Durotar Scorpion":
                case "Leopard Scorpid":
                case "Scorpid":
                case "Scorpling":
                case "Stripe-Tailed Scorpid":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Snap     | Triple Snap
                     * Slot 2: Crouch   | Screech
                     * Slot 3: Sting    | Rampage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Screech",        () => ! debuff("Speed Reduction") && speed <= speedEnemy),
                        new AandC("Sting",          () => ! debuff("Sting")),
                        new AandC("Crouch",         () => ! debuff("Crouch")),
                        new AandC("Rampage",        () => hp > 0.5),
                        new AandC("Snap"),
                        new AandC("Triple Snap"),
                    };
                    break;

                case "Crystal Spider":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Strike | Crystal Prison
                     * Slot 2: Sticky Web | Brittle Webbing
                     * Slot 3: Leech Life | Spiderling Swarm
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Sticky Web",       () => ! debuff("Webbed")),
                        new AandC("Brittle Webbing",  () => ! debuff("Brittle Webbing")),
                        new AandC("Leech Life",       () => debuff("Webbed") || debuff("Brittle Webbing")),
                        new AandC("Spiderling Swarm", () => debuff("Webbed") || debuff("Brittle Webbing")),
                        new AandC("Strike"),
                        new AandC("Crystal Prison"),
                    };
                    break;

                case "Darkshore Cub":
                case "Dun Morogh Cub":
                case "Hyjal Bear Cub":
                case "Panda Cub":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Roar
                     * Slot 2: Hibernate    | Bash
                     * Slot 3: Maul         | Rampage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Hibernate",  () => hp < 0.5),
                        new AandC("Maul",       () => enemyIsBleeding()),
                        new AandC("Roar",       () => ! buff("Attack Boost")),
                        new AandC("Rampage",    () => hp > 0.5),
                        new AandC("Bash",       () => ! enemyIsStunned() && ! enemyIsResilient()),
                        new AandC("Maul"),
                        new AandC("Bite"),
                        new AandC("Roar"),
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
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Flank
                     * Slot 2: Leap     | Screech
                     * Slot 3: Devour   | Exposed Wounds
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",         () => hpEnemy < 0.2),
                        new AandC("Devour",         () => hpEnemy < 0.3 && strong("Devour")),
                        new AandC("Exposed Wounds", () => ! debuff("Exposed Wounds")),
                        new AandC("Screech",        () => ! debuff("Speed Reduction")),
                        new AandC("Flank",          () => ! weak("Flank") && speed > speedEnemy),
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Bite"),
                        new AandC("Flank"),
                    };
                    break;

                case "Deathwatch Hatchling":
                    /* Changelog:
                     * 2015-01-23: Takedown is now also used in case of a type advantage - Studio60
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
                        new AandC("Takedown",       () => enemyIsStunned() || weak("Bite") || strong("Takedown")),
                        new AandC("Leap"),
                        new AandC("Woodchipper"),
                        new AandC("Bite"),
                    };
                    break;

                case "Death Adder Hatchling":
                    /* Changelog: 
                     * 2015-01-23: Viable base tactic added
                     * 
                     * Abilities:
                     * Slot 1: Poison Fang      | Vicious Fang
                     * Slot 2: Puncture Wound   | Crouch
                     * Slot 3: Burrow           | Blinding Poison
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Crouch",             () => ! buff("Crouch") && hpEnemy > 0.2),
                        new AandC("Poison Fang",        () => ! enemyIsPoisoned()),
                        new AandC("Puncture Wound",     () => enemyIsPoisoned()),
                        new AandC("Blinding Poison",    () => ! debuff("Blinding Poison")),
                        new AandC("Poison Fang"),
                        new AandC("Vicious Fang"),
                    };
                    break;

                case "Devouring Maggot":
                case "Festering Maggot":
                case "Jungle Grub":
                case "Larva":
                case "Maggot":
                case "Mr. Grubbs":
                    /* Changelog:
                     * 2015-01-23: Revised existing tactic - Studio60
                     * Abilities:
                     * Slot 1: Chomp | Consume
                     * Slot 2: Acidic Goo | Sticky Goo
                     * Slot 3: Leap | Burrow
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Consume",    () => hp < 0.8),
                        new AandC("Burrow",     () => shouldIHide && speed >= speedEnemy),
                        new AandC("Leap",       () => strong("Leap")),
                        new AandC("Acidic Goo", () => ! debuff("Acidic Goo")),
                        new AandC("Sticky Goo", () => myPetHasAbility("Consume") && weak("Consume") && hp > 0.8),
                        new AandC("Chomp"),
                        new AandC("Consume"),
                        new AandC("Sticky Goo"),
                    };
                    break;

                case "Direhorn Runt":
                case "Pygmy Direhorn":
                case "Stunted Direhorn":
                    /* Changelog:
                     * 2015-24:01: Trample mechanic adapted: 10% additional damage relates to maximum health not current health - Studio60
                     * 2015-23-01: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Trihorn Charge   | Trample
                     * Slot 2: Horn Attack      | Stampede
                     * Slot 3: Primal Cry       | Trihorn Shield
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Primal Cry",     () => speed < speedEnemy && ! debuff("Speed Reduction")),
                        new AandC("Stampede",       () => ! weak("Stampede") && ! debuff("Shattered Defenses")),
                        new AandC("Horn Attack",    () => speed > speedEnemy),
                        new AandC("Trihorn Shield", () => ! buff("Trihorn Shield")),
                        new AandC("Trihorn Charge"),
                        new AandC("Trample"),
                        new AandC("Horn Attack"),
                    };
                    break;

                case "Elder Python":
                    /* Changelog: 
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Poison Fang
                     * Slot 2: Sting    | Huge Fang
                     * Slot 3: Burrow   | Slither
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Poison Fang",    () => ! debuff("Poisoned")),
                        new AandC("Sting",          () => ! debuff("Sting")),
                        new AandC("Slither",        () => ! debuff("Speed Reduction")),
                        new AandC("Huge Fang"),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                    };
                    break;

                case "Feline Familiar":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Onyx Bite    | Pounce
                     * Slot 2: Stoneskin    | Call Darkness
                     * Slot 3: Devour       | Prowl
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",         () => hpEnemy < 0.2),
                        new AandC("Devour",         () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Stoneskin",      () => ! buff("Stoneskin") && hpEnemy > 0.2),
                        new AandC("Stoneskin",      () => buffLeft("Stoneskin") == 1 && speed < speedEnemy && hpEnemy > 0.2),
                        new AandC("Call Darkness",  () => ! weather("Darkness")),
                        new AandC("Prowl",          () => speed * 0.7 > speedEnemy && hpEnemy > 0.2),
                        new AandC("Onyx Bite"),
                        new AandC("Pounce"),
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
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Hoof         | Stampede
                     * Slot 2: Tranquility  | Survival
                     * Slot 3: Headbutt     | Bleat
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Bleat",          () => hp < 0.8),
                        new AandC("Tranquility",    () => ! buff("Tranquility") && hp < 0.8),
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Icespine Hatchling":
                    /* Changelog:
                     * 2015-01-23: Revised existing tactic - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Gnaw             | Bite
                     * Slot 2: Ravage           | Body Slam
                     * Slot 3: Puncture Wound   | Takedown
                     */
                    beast_abilities = new List<AandC>() {
                        new AandC("Ravage",         () => hpEnemy < 0.2),
                        new AandC("Ravage",         () => strong("Ravage") && hpEnemy > 0.3),
                        new AandC("Body Slam",      () => hp > hpEnemy),
                        new AandC("Puncture Wound", () => enemyIsPoisoned()),
                        new AandC("Takedown",       () => myPetHasAbility("Gnaw") && speed < speedEnemy),
                        new AandC("Takedown",       () => weak("Gnaw")),
                        new AandC("Gnaw"),
                        new AandC("Bite"),
                    };
                    break;

                case "Kovok":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Poison Fang  | Body Slam
                     * Slot 2: Pheromones   | Digest Brains
                     * Slot 3: Black Claw   | Puncture Wound
                     * 
                     * TODO: Re-Add Pheromones - Need to check enemy team status
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Digest Brains",  () => hp < 0.8),
                        new AandC("Poison Fang",    () => ! enemyIsPoisoned()),
                        new AandC("Black Claw",     () => ! debuff("Black Claw")),
                        new AandC("Puncture Wound", () => enemyIsPoisoned()),
                        new AandC("Poison Fang"),
                        new AandC("Puncture Wound", () => myPetHasAbility("Body Slam") && (weak("Body Slam") || strong("Puncture Wound"))),
                        new AandC("Body Slam"),
                    };
                    break;

                case "Leatherhide Runt":
                    /* Changelog:
                     * 2015-01-23: Stampede now considers type advantages
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
                        new AandC("Stampede",       () => ! debuff("Shattered Defenses") || strong("Stampede") || weak("Smash")),
                        new AandC("Smash"),
                        new AandC("Trample"),
                    };
                    break;

                case "Little Black Ram":
                case "Summit Kid":
                    /* Changelog:
                     * 2015-23-01: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Hoof     | Chew
                     * Slot 2: Comeback | Soothe
                     * Slot 3: Headbutt | Stampede
                     * 
                     * Tactic Information:
                     * Removed Soothe (for now). Enemy is very likely to not sleep due to damage.
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Headbutt"),
                        new AandC("Stampede",   () => ! debuff("Shattered Defenses")),
                        new AandC("Chew",       () => hp > 0.2),
                        new AandC("Comeback",   () => myPetHasAbility("Hoof") && hp < hpEnemy),
                        new AandC("Hoof"),
                        new AandC("Comeback",   () => buff("Chew") || hp < 0.2),
                        new AandC("Chew"),
                    };
                    break;

                case "Meadowstomper Calf":
                    /* Changelog:
                     * 2015-01-23: Stampede now considers type advantages - Studio60
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
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses") || weak("Trample") || strong("Stampede")),
                        new AandC("Trample"),
                        new AandC("Smash"),
                    };
                    break;

                case "Molten Hatchling":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Burn         | Leech Life
                     * Slot 2: Sticky Web   | Cauterize
                     * Slot 3: Magma Wave   | Brittle Webbing
                     * 
                     * TODO: Edit to consider global Webbed status
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Leech Life",         () => buff("Webbed") || buff("Brittle Webbing")),
                        new AandC("Cauterize",          () => hp < 0.8),
                        new AandC("Magma Wave",         () => debuff("Decoy") || debuff("Turret")),
                        new AandC("Sticky Web",         () => ! debuff("Webbed")),
                        new AandC("Brittle Webbing",    () => ! debuff("Brittle Webbing")),
                        new AandC("Burn"),
                        new AandC("Leech Life"),
                    };
                    break;

                case "Moon Moon":
                    /* Changelog: 
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Moon Fang    | Bite
                     * Slot 2: Howl         | Crouch
                     * Slot 3: Moon Tears   | Moon Dance
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Howl",       () => ! debuff("Shattered Defenses")),
                        new AandC("Crouch",     () => ! buff("Crouch")),
                        new AandC("Moon Dance", () => ! buff("Moon Dance")),
                        new AandC("Moon Tears", () => ! weather("Moonlight") || hp < 0.9),
                        new AandC("Moon Fang"),
                        new AandC("Bite"),
                    };
                    break;

                case "Mossbite Skitterer":
                    /* Changelog:
                     * 2015-01-23: Refined base tactic - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Gnaw | Bite
                     * Slot 2: Ravage | Body Slam
                     * Slot 3: Puncture Wound | Takedown
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Gnaw",             () => speed > speedEnemy),
                        new AandC("Ravage",           () => hpEnemy < 0.2),
                        new AandC("Ravage",           () => strong("Ravage") && hpEnemy < 0.3),
                        new AandC("Puncture Wound",   () => enemyIsPoisoned()),
                        new AandC("Takedown",         () => enemyIsStunned()),
                        new AandC("Body Slam",        () => hp > hpEnemy || strong("Body Slam")),
                        new AandC("Takedown",         () => weak("Gnaw") || strong("Takedown")),
                        new AandC("Gnaw"),
                        new AandC("Bite"),
                    };
                    break;

                case "Mountain Panda":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Scratch
                     * Slot 2: Cute Face    | Rock Barrage
                     * Slot 3: Burrow       | Mudslide
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Mudslide",       () => ! weather("Mudslide")),
                        new AandC("Cute Face",      () => ! buff("Cute Face")),
                        new AandC("Cute Face",      () => buffLeft("Cute Face") == 1 && speed < speedEnemy),
                        new AandC("Rock Barrage",   () => ! debuff("Rock Barrage")),
                        new AandC("Bite"),
                        new AandC("Scratch"),
                    };
                    break;

                case "Parched Lizard":
                    /* Changelog:
                     * 2015-01-23: Ravage now considers type advantages
                     *             Conflagrate is now used more often
                     * 2015-01-20: Conflagrate has been added - Studio60
                     *             Screech is now used if it is not already active - Studio60
                     *             Comeback is now only used if pet health is lower than enemy health - Studio60
                     *             Ravage is now used on enemies with low health - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw     | Quick Attack
                     * Slot 2: Screech  | Conflagrate
                     * Slot 3: Comeback | Ravage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Screech",        () => ! debuff("Speed Reduction")),
                        new AandC("Screech",        () => debuffLeft("Speed Reduction") == 1 && speed <= speedEnemy),
                        new AandC("Conflagrate",    () => enemyIsBurning()),
                        new AandC("Comeback",       () => hp < hpEnemy),
                        new AandC("Ravage",         () => hpEnemy < 0.2),
                        new AandC("Ravage",         () => strong("Ravage") && hpEnemy > 0.4),
                        new AandC("Conflagrate"),
                        new AandC("Claw"),
                        new AandC("Quick Attack"),
                    };
                    break;

                case "Ravager Hatchling":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Bite     | Rend
                     * Slot 2: Screech  | Sting
                     * Slot 3: Devour   | Rampage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",     () => hpEnemy < 0.2),
                        new AandC("Devour",     () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Screech",    () => ! debuff("Speed Reduction")),
                        new AandC("Sting",      () => ! debuff("Sting")),
                        new AandC("Rend",       () => speed > speedEnemy),
                        new AandC("Rampage",    () => hp > 0.5),
                        new AandC("Bite"),
                        new AandC("Rend"),
                    };
                    break;

                case "Red Panda":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Scratch
                     * Slot 2: Crouch   | Cute Face
                     * Slot 3: Perk Up  | Hibernate
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Hibernate",  () => hp < 0.5 && hpEnemy > 0.2),
                        new AandC("Perk Up",    () => ! buff("Healthy") || hp < 0.8),
                        new AandC("Crouch",     () => ! buff("Crouch")),
                        new AandC("Cute Face",  () => ! buff("Cute Face")),
                        new AandC("Cute Face",  () => buffLeft("Cute Face") == 1 && speed < speedEnemy),
                        new AandC("Bite"),
                        new AandC("Scratch"),
                    };
                    break;

                case "Scalded Basilisk Hatchling":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Crystal Prison
                     * Slot 2: Roar     | Feign Death
                     * Slot 3: Thrash   | Screech
                     * 
                     * TODO: Reintroduce Feign Death - Needs to consider team status
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Roar",           () => ! buff("Attack Boost")),
                        new AandC("Thrash",         () => speed >= speedEnemy),
                        new AandC("Screech",        () => ! debuff("Speed Reduction")),
                        new AandC("Screech",        () => buffLeft("Speed Reduction") == 1 && speed < speedEnemy),
                        new AandC("Screech"),
                        new AandC("Bite"),
                        new AandC("Crystal Prison"),
                        new AandC("Thrash"),
                        new AandC("Screech"),
                    };
                    break;

                case "Silent Hedgehog":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Poison Fang
                     * Slot 2: Spiked Skin  | Counterstrike
                     * Slot 3: Survival     | Powerball
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Poison Fang",    () => ! debuff("Poison Fang")),
                        new AandC("Spiked Skin",    () => ! buff("Spiked Skin")),
                        new AandC("Counterstrike",  () => speed < speedEnemy || strong("Counterstrike")),
                        new AandC("Powerball",      () => weak("Bite") || strong("Powerball")),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                    };
                    break;

                case "Silithid Hatchling":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch  | Devour
                     * Slot 2: Hiss     | Survival
                     * Slot 3: Swarm    | Sandstorm
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",   () => hp < 0.3),
                        new AandC("Devour",     () => hpEnemy < 0.2),
                        new AandC("Devour",     () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Sandstorm",  () => ! weather("Sandstorm")),
                        new AandC("Hiss",       () => ! debuff("Speed Reduction") && speed <= speedEnemy),
                        new AandC("Hiss",       () => myPetHasAbility("Devour")),
                        new AandC("Swarm",      () => ! debuff("Shattered Defenses")),
                        new AandC("Scratch"),
                        new AandC("Devour"),
                    };
                    break;

                case "Snowy Panda":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Bite         | Snowball
                     * Slot 2: Cute Face    | Call Blizzard
                     * Slot 3: Crouch       | Ice Barrier
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Ice Barrier",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cute Face",      () => ! buff("Cute Face")),
                        new AandC("Cute Face",      () => buffLeft("Cute Face") == 1 && speed <= speedEnemy),
                        new AandC("Crouch",         () => ! buff("Crouch")),
                        new AandC("Crouch",         () => buffLeft("Crouch") == 1 && speed <= speedEnemy),
                        new AandC("Call Blizzard",  () => ! weather("Blizzard")),
                        new AandC("Bite"),
                        new AandC("Snowball"),
                    };
                    break;

                case "Stunted Shardhorn":
                    /* Changelog:
                     * 2015-01-24: Horn Attack is now used if the pet is faster than the enemy - Studio60
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Smash            | Survival
                     * Slot 2: Trample          | Horn Attack
                     * Slot 3: Trumpet Strike   | Stampede
                     * 
                     * TODO: Trample needs to consider absolute enemy health
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Trumpet Strike", () => ! buff("Attack Boost")),
                        new AandC("Horn Attack",    () => speed > speedEnemy),
                        new AandC("Stampede",       () => ! debuff("Shattered Defenses")),
                        new AandC("Smash"),
                        new AandC("Trumpet Strike"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Sumprush Rodent":
                    /* Changelog:
                     * 2015-01-23: Corrected ability set - Studio60
                     *             Viable base tactic designed - Studio60
                     *             
                     * Abilities:
                     * Slot 1: Gnaw     | Tail Slap
                     * Slot 2: Mudslide | Poison Fang
                     * Slot 3: Survival | Stench
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",         () => hp < 0.3),
                        new AandC("Mudslide",       () => ! weather("Mudslide")),
                        new AandC("Stench",         () => ! debuff("Stench")),
                        new AandC("Stench",         () => debuffLeft("Stench") == 1 && speed < speedEnemy),
                        new AandC("Poison Fang",    () => ! debuff("Poisoned")),
                        new AandC("Poison Fang",    () => myPetHasAbility("Gnaw") && (weak("Gnaw") || strong("Poison Fang"))),
                        new AandC("Poison Fang",    () => myPetHasAbility("Tail Slap") && (weak("Tail Slap") || strong("Poison Fang"))),
                        new AandC("Gnaw"),
                        new AandC("Tail Slap"),
                    };
                    break;

                case "Sunfur Panda":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Scratch
                     * Slot 2: Hibernate    | Cute Face
                     * Slot 3: Sunlight     | Crouch
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Hibernate",  () => hp < 0.5 && hpEnemy > 0.2),
                        new AandC("Sunlight",   () => ! weather("Sunlight")),
                        new AandC("Cute Face",  () => ! buff("Cute Face")),
                        new AandC("Cute Face",  () => buffLeft("Cute Face") == 1 && speed < speedEnemy),
                        new AandC("Crouch",     () => ! buff("Crouch")),
                        new AandC("Crouch",     () => buffLeft("Crouch") == 1 && speed < speedEnemy),
                        new AandC("Bite"),
                        new AandC("Scratch"),
                    };
                    break;

                case "Thicket Skitterer":
                    /* Changelog:
                     * 2015-01-23: Takedown now considers type advantages
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
                        new AandC("Takedown",       () => weak("Gnaw") || strong("Takedown")),
                        new AandC("Body Slam",      () => strong("Body Slam")),
                        new AandC("Gnaw"),
                        new AandC("Bite"),
                    };
                    break;

                case "Tito":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Triple Snap
                     * Slot 2: Impale   | Howl
                     * Slot 3: Cyclone  | Buried Treasure
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Buried Treasure",    () => hp < 0.75 && hpEnemy > 0.2),
                        new AandC("Impale",             () => hpEnemy < 0.25),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Howl",               () => ! debuff("Shattered Defenses")),
                        new AandC("Bite"),
                        new AandC("Triple Snap"),
                    };
                    break;

                case "Vengeful Porcupette":
                    /* Changelog:
                     * 2015-01-23: Ability set corrected - Studio60
                     *             Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite             | Powerball
                     * Slot 2: Spirit Spikes    | Survival
                     * Slot 3: Flank            | Vengeance
                     * 
                     * TODO: Reintroduce Vengeance - Needs to analyze last hit damage
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3 ),
                        new AandC("Spirit Spikes"),
                        new AandC("Flank",          () => speed > speedEnemy),
                        new AandC("Flank",          () => myPetHasAbility("Bite") && weak("Bite") || strong("Flank")),
                        new AandC("Bite"),
                        new AandC("Powerball"),
                    };
                    break;

                case "Warpstalker Hatchling":
                    /* Changelog:
                     * 2015-01-23: Viable base tactics added - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Claw     | Blinkstrike
                     * Slot 2: Screech  | Triple Snap
                     * Slot 3: Ravage   | Comeback
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Ravage",         () => hpEnemy < 0.2),
                        new AandC("Ravage",         () => strong("Ravage") && hpEnemy < 0.3),
                        new AandC("Screech",        () => ! debuff("Speed Reduction") && speed < speedEnemy),
                        new AandC("Triple Snap",    () => myPetHasAbility("Blinkstrike") && (weak("Blinkstrike") || strong("Triple Snap"))),
                        new AandC("Comeback",       () => hp < hpEnemy),
                        new AandC("Comeback",       () => myPetHasAbility("Claw") && (weak("Claw") || strong("Comeback"))),
                        new AandC("Comeback",       () => myPetHasAbility("Blinkstrike") && (weak("Blinkstrike") || strong("Comeback"))),
                        new AandC("Claw"),
                        new AandC("Blinkstrike"),
                    };
                    break;

                case "Wind Rider Cub":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Bite         | Squawk
                     * Slot 2: Slicing Wind | Adrenaline Rush
                     * Slot 3: Flock        | Lift-OFf
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline") && speed < speedEnemy),
                        new AandC("Squawk",             () => ! debuff("Attack Reduction")),
                        new AandC("Squawk",             () => debuffLeft("Attack Reduction") == 1 && speed < speedEnemy),
                        new AandC("Slicing Wind",       () => myPetHasAbility("Bite") && (weak("Bite") || strong("Slicing Wind"))),
                        new AandC("Adrenaline Rush",    () => myPetHasAbility("Squawk") && (weak("Squawk") || strong("Adrenaline Rush"))),
                        new AandC("Flock",              () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Bite"),
                        new AandC("Squawk"),
                    };
                    break;

                case "Xu-Fu, Cub of Xuen":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Spirit Claws | Bite
                     * Slot 2: Feed         | Moonfire
                     * Slot 3: Vengeance    | Prowl
                     * 
                     * TODO: Reintroduce Vengeance - Needs to know last hit taken
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Feed",           () => hp < 0.75),
                        new AandC("Moonfire",       () => ! weather("Moonlight")),
                        new AandC("Moonfire",       () => weak("Bite") || strong("Moonlight")),
                        new AandC("Prowl",          () => ! buff("Prowl") && speed * 0.7 > speedEnemy),
                        new AandC("Spirit Claws"),
                        new AandC("Bite"),
                    };
                    break;

                case "Zandalari Anklerender":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite | Hunting Party
                     * Slot 2: Leap | Primal Cry
                     * Slot 3: Devour | Black Claw
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",         () => hpEnemy < 0.2),
                        new AandC("Devour",         () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Black Claw",     () => ! debuff("Black Claw")),
                        new AandC("Primal Cry",     () => speed < speedEnemy && ! debuff("Speed Reduction")),
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Hunting Party",  () => debuff("Black Claw")),
                        new AandC("Leap"),
                        new AandC("Bite"),
                        new AandC("Hunting Party"),
                    };
                    break;

                case "Zandalari Footslasher":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Bite         | Hunting Party
                     * Slot 2: Leap         | Primal Cry
                     * Slot 3: Bloodfang    | Exposed Wounds
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bloodfang",      () => hpEnemy < 0.1),
                        new AandC("Bloodfang",      () => strong("Bloodfang") && hpEnemy < 0.15),
                        new AandC("Exposed Wounds", () => ! debuff("Exposed Wounds")),
                        new AandC("Primal Cry",     () => speed < speedEnemy && ! debuff("Speed Reduction")),
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Bite"),
                        new AandC("Hunting Party"),
                    };
                    break;

                case "Zandalari Kneebiter":
                    /* Changelog: 
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Hunting Party
                     * Slot 2: Screech  | Black Claw
                     * Slot 3: Leap     | Bloodfang
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bloodfang",      () => hpEnemy < 0.1),
                        new AandC("Bloodfang",      () => strong("Bloodfang") && hpEnemy < 0.15),
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Screech",        () => ! debuff("Speed Reduction") && speed <= speedEnemy),
                        new AandC("Black Claw",     () => ! debuff("Black Claw")),
                        new AandC("Hunting Party",  () => debuff("Black Claw")),
                        new AandC("Leap"),
                        new AandC("Bite"),
                        new AandC("Hunting Party"),
                    };
                    break;

                case "Zandalari Toenibbler":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Bite         | Flank
                     * Slot 2: Leap         | Primal Cry
                     * Slot 3: Bloodfang    | Black Claw
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Bloodfang",  () => hpEnemy < 0.1),
                        new AandC("Bloodfang",  () => strong("Bloodfang") && hpEnemy < 0.15),
                        new AandC("Black Claw", () => ! debuff("Black Claw")),
                        new AandC("Primal Cry", () => speed < speedEnemy && ! debuff("Speed Reduction")),
                        new AandC("Leap",       () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Leap",       () => myPetHasAbility("Flank") && (weak("Flank") || strong("Leap"))),
                        new AandC("Bite"),
                        new AandC("Flank"),
                    };
                    break;

                case "Zao, Calfling of Niuzao":
                    /* Changelog
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Trample          | Horn Gore
                     * Slot 2: Headbutt         | Wish
                     * Slot 3: Niuzao's Charge  | Dominance
                     */
                    beast_abilities = new List<AandC>() 
                    {
                        new AandC("Wish",               () => hp < 0.5),
                        new AandC("Dominance",          () => ! buff("Dominance") && hpEnemy > 0.2),
                        new AandC("Niuzao's Charge",    () => hpEnemy > 0.4),
                        new AandC("Headbutt"),
                        new AandC("Trample"),
                        new AandC("Horn Gore"),
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