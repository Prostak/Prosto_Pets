/////////////
// CRITTER //
/////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Critter : PetTacticsBase
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

            List<AandC> critter_abilities;

            switch (petName) {
                case "Alpine Chipmunk": 
                case "Grizzly Squirrel": 
                case "Nuts": 
                case "Red-Tailed Chipmunk": 
                case "Squirrel":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * Abilities:
                     * Slot 1: Scratch          | Woodchipper
                     * Slot 2: Adrenaline Rush  | Crouch
                     * Slot 3: Nut Barrage      | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Adrenaline Rush",    () => ! buff("Adrenaline")),
                        new AandC("Adrenaline Rush",    () => buffLeft("Adrenaline") == 1 && speed < speedEnemy),
                        new AandC("Crouch",             () => ! buff("Crouch")),
                        new AandC("Nut Barrage",        () => ! debuff("Nut Barrage")),
                        new AandC("Woodchipper",        () => ! enemyIsBleeding),
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Scratch"),
                        new AandC("Woodchipper"),
                    };
                    break;

                case "Alpine Hare": 
                case "Arctic Hare": 
                case "Brown Rabbit": 
                case "Elfin Rabbit": 
                case "Grasslands Cottontail": 
                case "Hare": 
                case "Mountain Cottontail": 
                case "Rabbit": 
                case "Snowshoe Hare": 
                case "Snowshoe Rabbit": 
                case "Spring Rabbit": 
                case "Tolai Hare": 
                case "Tolai Hare Pup":
                    /* Changelog: 
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch          | Flurry
                     * Slot 2: Adrenaline Rush  | Dodge
                     * Slot 3: Burrow           | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Dodge",              () => shouldIHide && speed >= speedEnemy),
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Scratch"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Armadillo Pup":
                case "Stone Armadillo":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch          | Trash
                     * Slot 2: Shell Shield     | Roar
                     * Slot 3: Infected Claw    | Powerball
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Shell Shield",   () => ! buff("Shell Shield") && hp > 0.2),
                        new AandC("Shell Shield",   () => buffLeft("Shell Shield") == 1 && speed < speedEnemy && hp > 0.2),
                        new AandC("Roar",           () => ! buff("Attack Boost") && hp > 0.2),
                        new AandC("Infected Claw",  () => myPetHasAbility("Scratch") && (weak("Scratch") || strong("Infected Claw"))),
                        new AandC("Infected Claw",  () => myPetHasAbility("Thrash") && (weak("Thrash") || strong("Infected Claw") || speed < speedEnemy)),
                        new AandC("Powerball",      () => myPetHasAbility("Scratch") && (weak("Powerball") || strong("Infected Claw"))),
                        new AandC("Powerball",      () => myPetHasAbility("Thrash") && (weak("Thrash") || strong("Powerball") || speed < speedEnemy)),
                        new AandC("Scratch"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Bandicoon": 
                case "Bandicoon Kit": 
                case "Masked Tanuki": 
                case "Masked Tanuki Pup": 
                case "Shy Bandicoon":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Tongue Lash
                     * Slot 2: Survival     | Counterstrike
                     * Slot 3: Poison Fang  | Powerball
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Poison Fang",    () => ! debuff("Poisoned")),
                        new AandC("Counterstrike",  () => speed < speedEnemy),
                        new AandC("Counterstrike",  () => myPetHasAbility("Bite") && (weak("Bite") || strong("Counterstrike"))),
                        new AandC("Counterstrike",  () => myPetHasAbility("Tongue Lash") && (weak("Tongue Lash") || strong("Counterstrike"))),
                        new AandC("Powerball",      () => myPetHasAbility("Bite") && (weak("Bite") || strong("Powerball"))),
                        new AandC("Powerball",      () => myPetHasAbility("Tongue Lash") && (weak("Tongue Lash") || strong("Powerball"))),
                        new AandC("Bite"),
                        new AandC("Tongue Lash"),
                    };
                    break;

                case "Beetle":
                case "Cockroach": 
                case "Creepy Crawly": 
                case "Crystal Beetle": 
                case "Death's Head Cockroach": 
                case "Deepholm Cockroach": 
                case "Dung Beetle": 
                case "Fire-Proof Roach": 
                case "Gold Beetle": 
                case "Irradiated Roach": 
                case "Locust": 
                case "Resilient Roach": 
                case "Roach": 
                case "Sand Scarab": 
                case "Savory Beetle": 
                case "Scarab Hatchling": 
                case "Stinkbug": 
                case "Tainted Cockroach": 
                case "Tol'vir Scarab": 
                case "Twilight Beetle": 
                case "Undercity Cockroach":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch  | Flank
                     * Slot 2: Hiss     | Survival
                     * Slot 3: Swarm    | Apocalypse
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Apocalypse", () => ! buff("Apocalypse")),
                        new AandC("Survival",   () => hp < 0.3),
                        new AandC("Hiss",       () => speed < speedEnemy && ! debuff("Speed Reduction")),
                        new AandC("Hiss",       () => myPetHasAbility("Scratch") && (weak("Scratch") || strong("Hiss"))),
                        new AandC("Hiss",       () => myPetHasAbility("Flank") && (weak("Flank") || strong("Hiss"))),
                        new AandC("Swarm",      () => ! debuff("Shattered Defenses") & hp > 0.4),
                        new AandC("Scratch"),
                        new AandC("Flank"),
                    };
                    break;

                case "Black Lamb":
                case "Elwynn Lamb":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Hoof     | Chew
                     * Slot 2: Comeback | Soothe
                     * Slot 3: Bleat    | Stampede
                     * 
                     * Tactic Information:
                     * Soothe removed for now. Don't know yet how to make useful
                     * Stampede/Comeback added to the end as fallback to avoid passing turns.
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Bleat",      () => hp < 0.7),
                        new AandC("Comeback",   () => hp < hpEnemy),
                        new AandC("Stampede",   () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Hoof"),
                        new AandC("Chew"),
                        new AandC("Stampede",   () => hp > 0.4),
                        new AandC("Comeback"),
                    };
                    break;

                case "Black Rat": 
                case "Carrion Rat": 
                case "Fjord Rat": 
                case "Giant Sewer Rat": 
                case "Highlands Mouse": 
                case "Long-tailed Mole": 
                case "Mouse": 
                case "Rat": 
                case "Redridge Rat": 
                case "Prairie Mouse":
                case "Stormwind Rat": 
                case "Stowaway Rat": 
                case "Tainted Rat": 
                case "Undercity Rat": 
                case "Wharf Rat": 
                case "Yakrat":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch      | Comeback
                     * Slot 2: Flurry       | Poison Fang
                     * Slot 3: Stampede     | Survival
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Comeback",       () => hp < hpEnemy),
                        new AandC("Poison Fang",    () => ! debuff("Poisoned")),
                        new AandC("Stampede",       () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Flurry"),
                        new AandC("Scratch"),
                        new AandC("Comeback"),
                    };
                    break;

                case "Borean Marmot": 
                case "Brown Marmot": 
                case "Brown Prairie Dog": 
                case "Prairie Dog": 
                case "Yellow-Bellied Marmot":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Chomp    | Adrenaline Rush
                     * Slot 2: Leap     | Crouch
                     * Slot 3: Burrow   | Comeback
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Crouch",             () => ! buff("Crouch")),
                        new AandC("Crouch",             () => buffLeft("Crouch") == 1 && speed < speedEnemy),
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Leap",               () => myPetHasAbility("Comeback") && hp >= hpEnemy && (weak("Comeback") || strong("Leap"))),
                        new AandC("Chomp"),
                        new AandC("Comeback"),
                    };
                    break;

                case "Bush Chicken":
                    /* Changelog:
                     * 2015-01-24: Rake/Headbutt now consider type advantages
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Flock    | Savage Talon
                     * Slot 2: Squawk   | Rake
                     * Slot 3: Headbutt | Cyclone
                     *
                     * Tactic Information:
                     * Not quite sure where to go with this tactic... Flock is weird as a base attack
                     */
                    critter_abilities = new List<AandC>() {
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Squawk",         () => ! debuff("Attack Reduction")),
                        new AandC("Rake",           () => ! weak("Rake") || strong("Flock")),
                        new AandC("Headbutt",       () => ! weak("Headbutt") || strong("Flock")),
                        new AandC("Flock"),
                        new AandC("Savage Talon"),
                    };
                    break;

                case "Darkmoon Hatchling":
                    /* 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Peck     | Trample
                     * Slot 2: Screech  | Hawk Eye
                     * Slot 3: Flock    | Predatory Strike
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Screech",            () => ! buff("Speed Reduction") && speed < speedEnemy),
                        new AandC("Flock",              () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Peck"),
                        new AandC("Trample"),
                    };
                    break;

                case "Darkmoon Rabbit":
                    /* 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch          | Huge, Sharp Teeth!
                     * Slot 2: Vicious Streak   | Dodge
                     * Slot 3: Burrow           | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Dodge",              () => shouldIHide && speed >= speedEnemy),
                        new AandC("Huge, Sharp Teeth!", () => debuff("Bleeding")),
                        new AandC("Vicious Streak",     () => speed < speedEnemy && ! buff("Vicious Streak") ),
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Vicious Streak",     () => myPetHasAbility("Huge, Sharp Teeth!") && (weak("Huge, Sharp Teeth!") || strong("Vicious Streak"))),
                        new AandC("Scratch"),
                        new AandC("Huge, Sharp Teeth!"),
                    };
                    break;

                case "Egbert":
                case "Mulgore Hatchling":
                    /* Abilities:
                     * Slot 1: Bite         | Peck
                     * Slot 2: Shell Shield | Adrenaline Rush
                     * Slot 3: Trample      | Feign Death
                     * 
                     * TODO: Reintroduce Feign Death - Needs to consider team status
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Shell Shield",       () => ! buff("Shell Shield")),
                        new AandC("Shell Shield",       () => buffLeft("Shell Shield") == 1 && speed <= speedEnemy),
                        new AandC("Trample",            () => ! weak("Trample")),
                        new AandC("Bite"),
                        new AandC("Peck"),
                    };
                    break;

                case "Fawn": 
                case "Gazelle Fawn": 
                case "Little Fawn": 
                case "Winter Reindeer":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Hoof         | Stampede
                     * Slot 2: Tranquility  | Nature's Ward
                     * Slot 3: Bleat        | Headbutt
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Tranquility",    () => hp < 0.8 && ! buff("Tranquility")),
                        new AandC("Bleat",          () => hp < 0.7 ),
                        new AandC("Nature's Ward",  () => ! famEnemy(PF.Aquatic) && ! buff("Nature's Ward")),
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Fire Beetle":
                case "Lava Beetle":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Burn             | Flank
                     * Slot 2: Hiss             | Cauterize
                     * Slot 3: Scorched Earth   | Apocalypse
                     * 
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Apocalypse",     () => ! debuff("Apocalypse") && hpEnemy == 1.0),
                        new AandC("Cauterize",      () => hp < 0.7),
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth")),
                        new AandC("Hiss",           () => speed < speedEnemy && ! debuff("Speed Reduction")),
                        new AandC("Hiss",           () => myPetHasAbility("Burn") && (weak("Burn") || strong("Hiss"))),
                        new AandC("Hiss",           () => myPetHasAbility("Flank") && (weak("Flank") || strong("Hiss"))),
                        new AandC("Burn"),
                        new AandC("Flank"),
                    };
                    break;

                case "Frostfur Rat":
                    /* Changelog:
                     * 2015-01-20: Sneak Attack is now checking for all blindness effects - Studio60
                     *             Refuge is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Sneak Attack | Flurry
                     * Slot 2: Crouch       | Refuge
                     * Slot 3: Stampede     | Call Darkness
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Sneak Attack",   () => enemyIsBlinded),
                        new AandC("Crouch",         () => ! buff("Crouch")),
                        new AandC("Refuge",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Stampede",       () => ! debuff("Shattered Defenses")),
                        new AandC("Call Darkness",  () => ! weather("Darkness")),
                        new AandC("Sneak Attack"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Golden Pig": 
                case "Lucky": 
                case "Mr. Wiggles": 
                case "Silver Pig":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Hoof         | Diseased Bite
                     * Slot 2: Crouch       | Buried Treasure
                     * Slot 3: Uncanny Luck | Headbutt
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Buried Treasure",    () => hp < 0.75),
                        new AandC("Uncanny Luck",       () => ! buff("Uncanny Luck")),
                        new AandC("Crouch",             () => ! buff("Crouch")),
                        new AandC("Crouch",             () => buffLeft("Crouch") == 1 && speed < speedEnemy),
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Diseased Bite"),
                    };
                    break;

                case "Grassland Hopper": 
                case "Marsh Fiddler": 
                case "Red Cricket": 
                case "Singing Cricket":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Skitter          | Screech
                     * Slot 2: Swarm            | Cocoon Strike
                     * Slot 3: Nature's Touch   | Inspiring Song
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Cocoon Strike",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Inspiring Song", () => hp < 0.8),
                        new AandC("Nature's Touch", () => hp < 0.7),
                        new AandC("Swarm",          () => ! debuff("Shattered Defenses") && hpEnemy > 0.4),
                        new AandC("Skitter"),
                        new AandC("Screech"),
                    };
                    break;

                case "Grotto Vole":
                case "Whiskers the Rat":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch      | Flurry
                     * Slot 2: Sting        | Survival
                     * Slot 3: Stampede     | Comeback
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",   () => hp < 0.3),
                        new AandC("Sting",      () => ! debuff("Sting")),
                        new AandC("Comeback",   () => hp < hpEnemy),
                        new AandC("Stampede",   () => ! debuff("Shattered Defenses") && hpEnemy > 0.4),
                        new AandC("Scratch"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Gu'chi Swarmling":
                    /* Changelog:
                     * 2015-01-20: Burrow is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Chomp        | Swarm
                     * Slot 2: Acidic Goo   | Chew
                     * Slot 3: Consume      | Burrow
                     *
                     * Tactics Information:
                     * Burrow  used defensivey
                     */
                    critter_abilities = new List<AandC>() {
                        new AandC("Burrow",     () => shouldIHide && speed >= speedEnemy),
                        new AandC("Swarm",      () => ! debuff("Shattered Defenses")),
                        new AandC("Acidic Goo", () => ! debuff("Acidic Goo")),
                        new AandC("Chew",       () => ! buff("Chew")),
                        new AandC("Consume",    () => hp < 0.8),
                        new AandC("Chomp"),
                        new AandC("Swarm"),
                    };
                    break;

                case "Highlands Skunk": 
                case "Mountain Skunk": 
                case "Skunk": 
                case "Stinker":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch  | Flurry
                     * Slot 2: Rake     | Perk Up
                     * Slot 3: Stench   | Bleat
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Bleat",      () => hp < 0.7),
                        new AandC("Perk Up",    () => ! buff("Healthy") && hp < 0.9),
                        new AandC("Stench",     () => ! debuff("Stench") && hpEnemy > 0.2),
                        new AandC("Rake",       () => ! weak("Rake")),
                        new AandC("Scratch"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Imperial Silkworm":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Chomp        | Consume
                     * Slot 2: Sticky Goo   | Moth Balls
                     * Slot 3: Burrow       | Moth Dust
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",     () => shouldIHide && speed <= speedEnemy),
                        new AandC("Sticky Goo", () => myPetHasAbility("Consume") && weak("Consume") && hp > 0.8),
                        new AandC("Moth Balls", () => myPetIsLucky),
                        new AandC("Moth Dust"),
                        new AandC("Chomp"),
                        new AandC("Consume"),
                    };
                    break;

                case "Lovebird Hatchling":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Peck         | Alpha Strike
                     * Slot 2: Lovestruck   | Hawk Eye
                     * Slot 3: Pheromones   | Predatory Strike
                     *
                     * TODO: Pheromones need to check if more than active enemy pet is alive
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Predatory Strike",   () => hpEnemy < 0.25),
                        new AandC("Lovestruck"),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Peck"),
                        new AandC("Alpha Strike"),
                        new AandC("Pheromones",         () => ! debuff("Pheromones")),
                    };
                    break;

                case "Lucky Quilen Cub":
                case "Perky Pug":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Comeback
                     * Slot 2: Perk Up  | Buried Treasure
                     * Slot 3: Burrow   | Trample
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Buried Treasure",    () => hp < 0.7),
                        new AandC("Perk Up",            () => ! buff("Healthy") || hp < 0.8),
                        new AandC("Trample",            () => myPetHasAbility("Comeback") && weak("Comeback") && hp > hpEnemy),
                        new AandC("Bite"),
                        new AandC("Comeback"),
                    };
                    break;

                case "Malayan Quillrat": 
                case "Malayan Quillrat Pup": 
                case "Porcupette": 
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Poison Fang
                     * Slot 2: Spiked Skin  | Counterstrike
                     * Slot 3: Survival     | Powerball
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Spiked Skin",    () => ! buff("Spiked Skin")),
                        new AandC("Counterstrike",  () => ! weak("Counterstrike") && speed < speedEnemy),
                        new AandC("Powerball",      () => weak("Bite") || strong("Powerball")),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                    };
                    break;

                case "Nether Roach":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Flank    | Nether Blast
                     * Slot 2: Hiss     | Survival
                     * Slot 3: Swarm    | Apocalypse
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Apocalypse",     () => ! debuff("Apocalypse") && hpEnemy == 1.0),
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Hiss",           () => ! debuff("Speed Reduction") && speed < speedEnemy),
                        new AandC("Hiss",           () => myPetHasAbility("Flank") && (weak("Flank") || strong("Hiss"))),
                        new AandC("Hiss",           () => myPetHasAbility("Nether Blast") && (weak("Nether Blast") || strong("Hiss"))),
                        new AandC("Swarm",          () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Flank"),
                        new AandC("Nether Blast"),
                    };
                    break;

                case "Peanut":
                case "Pint-Sized Pink Pachyderm":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Smash            | Trample
                     * Slot 2: Trumpet Strike   | Survival
                     * Slot 3: Headbutt         | Stampede 
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",           () => hp < 0.3 ),
                        new AandC("Headbutt"),
                        new AandC("Stampede",           () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Trumpet Strike",     () => ! buff("Attack Boost")),
                        new AandC("Smash"),
                        new AandC("Trample"),
                    };
                    break;

                case "Pygmy Cow":
                    /* Changelog:
                     * 2015-01-20: Where's the Beef? is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Stampede             | Chew
                     * Slot 2: Mother's Milk        | Feed
                     * Slot 3: Where's the Beef?    | Udder Destruction
                     *
                     * Tactics Information:
                     * Chew: If selected, Pygmy Cow might have to pass at times
                     * 
                     * TODO: Mother's Milk needs to check if other own pets might need heal
                     */
                    critter_abilities = new List<AandC>() {
                        new AandC("Where's the Beef?",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Feed",               () => hp < 0.8),
                        new AandC("Udder Destruction"),
                        new AandC("Stampede"),
                        new AandC("Chew"),
                        new AandC("Mother's Milk"),
                    };
                    break;

                case "Rapana Whelk": 
                case "Rusty Snail": 
                case "Scooter the Snail": 
                case "Shimmershell Snail": 
                case "Silkbead Snail":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Ooze Touch   | Absorb
                     * Slot 2: Acidic Goo   | Shell Shield
                     * Slot 3: Dive         | Headbutt
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Dive",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Acidic Goo",     () => ! debuff("Acidic Goo")),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield")),
                        new AandC("Shell Shield",   () => buffLeft("Shell Shield") == 1 && speed < speedEnemy),
                        new AandC("Headbutt"),
                        new AandC("Ooze Touch"),
                        new AandC("Absorb"),
                    };
                    break;

                case "Wolpertinger":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Scratch  | Horn Attack
                     * Slot 2: Flyby    | Sleeping Gas
                     * Slot 3: Headbutt | Rampage
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Headbutt",       () => ! weak("Headbutt")),
                        new AandC("Flyby",          () => debuff("Weakened Defenses")),
                        new AandC("Sleeping Gas",   () => strong("Sleeping Gas")),
                        new AandC("Rampage",        () => myPetHasAbility("Scratch") && strong("Rampage")),
                        new AandC("Flyby",          () => strong("Flyby")),
                        new AandC("Scratch"),
                        new AandC("Horn Attack"),
                    };
                    break;
 
                default:
                    /////////////////////
                    // Unknown Critter //
                    /////////////////////
                    Logger.Alert("Unknown critter pet: " + petName);
                    critter_abilities = null;
                    break;
            }

            return critter_abilities;
        }
    }
}