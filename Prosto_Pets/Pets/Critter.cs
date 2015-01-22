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
                    /* Abilities:
                     * Slot 1: Scratch          | Woodchipper
                     * Slot 2: Adrenaline Rush  | Crouch
                     * Slot 3: Nut Barrage      | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Adrenaline Rush", () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Scratch"),
                        new AandC("Woodchipper"),
                        new AandC("Crouch"),
                        new AandC("Nut Barrage"),
                        new AandC("Stampede"),
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
                    /* Abilities:
                     * Slot 1: Scratch          | Flurry
                     * Slot 2: Adrenaline Rush  | Dodge
                     * Slot 3: Burrow           | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow"),
                        new AandC("Dodge"),
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Scratch"),
                        new AandC("Flurry"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Armadillo Pup":
                case "Stone Armadillo":
                    /* Abilities:
                     * Slot 1: Scratch          | Trash
                     * Slot 2: Shell Shield     | Roar
                     * Slot 3: Infected Claw    | Powerball
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Shell Shield",  () =>  ! buff("Shell Shield")),
                        new AandC("Scratch"),
                        new AandC("Thrash"),
                        new AandC("Roar"),
                        new AandC("Infected Claw"),
                        new AandC("Powerball"),
                    };
                    break;

                case "Bandicoon": 
                case "Bandicoon Kit": 
                case "Masked Tanuki": 
                case "Masked Tanuki Pup": 
                case "Shy Bandicoon":
                    /* Abilities:
                     * Slot 1: Bite         | Tongue Lash
                     * Slot 2: Survival     | Counterstrike
                     * Slot 3: Poison Fang  | Powerball
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Poison Fang",    () => ! debuff("Poisoned")),
                        new AandC("Bite"),
                        new AandC("Tongue Lash"),
                        new AandC("Counterstrike"),
                        new AandC("Powerball"),
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
                    /* Abilities:
                     * Slot 1: Scratch  | Flank
                     * Slot 2: Hiss     | Survival
                     * Slot 3: Swarm    | Apocalypse
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",   () => hp < 0.3),
                        new AandC("Scratch"),
                        new AandC("Flank"),
                        new AandC("Hiss"),
                        new AandC("Swarm"),
                        new AandC("Apocalypse"),
                    };
                    break;

                case "Black Lamb":
                case "Elwynn Lamb":
                    /* Abilities:
                     * Slot 1: Hoof     | Chew
                     * Slot 2: Comeback | Soothe
                     * Slot 3: Bleat    | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Chew"),
                        new AandC("Comeback"),
                        new AandC("Sooth"),
                        new AandC("Rampage"),
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
                    /* Abilities:
                     * Slot 1: Scratch      | Comeback
                     * Slot 2: Flurry       | Poison Fang
                     * Slot 3: Stampede     | Survival
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival", () => hp < 0.3),
                        new AandC("Scratch"),
                        new AandC("Comeback"),
                        new AandC("Flurry"),
                        new AandC("Poison Fang"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Blighted Squirrel":
                    /* Abilities:
                     * Slot 1: Scratch          | Woodchipper
                     * Slot 2: Adrenaline Rush  | Crouch
                     * Slot 3: Rabid Strike     | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Scratch"),
                        new AandC("Woodchipper"),
                        new AandC("Crouch"),
                        new AandC("Rabid Strike"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Borean Marmot": 
                case "Brown Marmot": 
                case "Brown Prairie Dog": 
                case "Prairie Dog": 
                case "Yellow-Bellied Marmot":
                    /* Abilities:
                     * Slot 1: Chomp    | Adrenaline Rush
                     * Slot 2: Leap     | Crouch
                     * Slot 3: Burrow   | Comeback
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow"),
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Leap",               () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Chomp"),
                        new AandC("Comeback"),
                        new AandC("Crouch"),
                    };
                    break;

                case "Bush Chicken":
                    /* Changelog:
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
                        new AandC("Rake"),
                        new AandC("Headbutt"),
                        new AandC("Flock"),
                        new AandC("Savage Talon"),
                    };
                    break;

                case "Darkmoon Hatchling":
                    /* Abilities:
                     * Slot 1: Peck     | Trample
                     * Slot 2: Screech  | Hawk Eye
                     * Slot 3: Flock    | Predatory Strike
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")),
                        new AandC("Peck"),
                        new AandC("Trample"),
                        new AandC("Screech"),
                        new AandC("Flock"),
                        new AandC("Predatory Strike"),
                    };
                    break;

                case "Darkmoon Rabbit":
                    /* Abilities:
                     * Slot 1: Scratch          | Huge, Sharp Teeth!
                     * Slot 2: Vicious Streak   | Dodge
                     * Slot 3: Burrow           | Stampede
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow"),
                        new AandC("Dodge"),
                        new AandC("Vicious Streak",     () => speed < speedEnemy && ! buff("Vicious Streak") ),
                        new AandC("Scratch"),
                        new AandC("Huge, Sharp Teeth!"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Egbert":
                case "Mulgore Hatchling":
                    /* Abilities:
                     * Slot 1: Bite         | Peck
                     * Slot 2: Shell Shield | Adrenaline Rush
                     * Slot 3: Trample      | Feign Death
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Adrenaline Rush",    () => speed < speedEnemy && ! buff("Adrenaline")),
                        new AandC("Shell Shield",       () => ! buff("Shell Shield")),
                        new AandC("Bite"),
                        new AandC("Peck"),
                        new AandC("Trample"),
                        new AandC("Feign Death"),
                    };
                    break;

                case "Fawn": 
                case "Gazelle Fawn": 
                case "Little Fawn": 
                case "Winter Reindeer":
                    /* Abilities:
                     * Slot 1: Hoof         | Stampede
                     * Slot 2: Tranquility  | Nature's Ward
                     * Slot 3: Bleat        | Headbutt
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Tranquility",    () => hp < 0.7 && ! buff("Tranquility")),
                        new AandC("Bleat",          () => hp < 0.7 ),
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Stampede"),
                        new AandC("Nature's Ward"),
                    };
                    break;

                case "Fire Beetle":
                case "Lava Beetle":
                    /* Abilities:
                     * Slot 1: Burn             | Flank
                     * Slot 2: Hiss             | Cauterize
                     * Slot 3: Scorched Earth   | Apocalypse
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Apocalypse"),
                        new AandC("Cauterize",      () => hp < 0.7),
                        new AandC("Burn"),
                        new AandC("Flank"),
                        new AandC("Hiss"),
                        new AandC("Scorched Earth"),
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
                        new AandC("Sneak Attack",   () => enemyIsBlinded()),
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
                    /* Abilities:
                     * Slot 1: Hoof         | Diseased Bite
                     * Slot 2: Crouch       | Buried Treasure
                     * Slot 3: Uncanny Luck | Headbutt
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Headbutt"),
                        new AandC("Hoof"),
                        new AandC("Diseased Bite"),
                        new AandC("Crouch"),
                        new AandC("Buried Treasure"),
                        new AandC("Uncanny Luck"),
                    };
                    break;

                case "Grassland Hopper": 
                case "Marsh Fiddler": 
                case "Red Cricket": 
                case "Singing Cricket":
                    /* Abilities:
                     * Slot 1: Skitter          | Screech
                     * Slot 2: Swarm            | Cocoon Strike
                     * Slot 3: Nature's Touch   | Inspiring Song
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Nature's Touch", () => hp < 0.7),
                        new AandC("Skitter"),
                        new AandC("Screech"),
                        new AandC("Swarm"),
                        new AandC("Cocoon Strike"),
                        new AandC("Inspiring Song"),
                    };
                    break;

                case "Grotto Vole":
                case "Whiskers the Rat":
                    /* Abilities:
                     * Slot 1: Scratch      | Flurry
                     * Slot 2: Sting        | Survival
                     * Slot 3: Stampede     | Comeback
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",   () => hp < 0.3),
                        new AandC("Scratch"),
                        new AandC("Flurry"),
                        new AandC("Sting"),
                        new AandC("Stampede"),
                        new AandC("Comeback"),
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
                    /* Abilities:
                     * Slot 1: Scratch  | Flurry
                     * Slot 2: Rake     | Perk Up
                     * Slot 3: Stench   | Bleat
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Scratch"),
                        new AandC("Flurry"),
                        new AandC("Rake"),
                        new AandC("Perk Up"),
                        new AandC("Stench"),
                        new AandC("Bleat"),
                    };
                    break;

                case "Imperial Silkworm":
                    /* Abilities:
                     * Slot 1: Chomp        | Consume
                     * Slot 2: Sticky Goo   | Moth Balls
                     * Slot 3: Burrow       | Moth Dust
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow"),
                        new AandC("Chomp"),
                        new AandC("Consume"),
                        new AandC("Sticky Goo"),
                        new AandC("Moth Balls"),
                        new AandC("Moth Dust"),
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
                    /* Abilities:
                     * Slot 1: Bite     | Comeback
                     * Slot 2: Perk Up  | Buried Treasure
                     * Slot 3: Burrow   | Trample
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow"),
                        new AandC("Bite"),
                        new AandC("Comeback"),
                        new AandC("Perk Up"),
                        new AandC("Buried Treasure"),
                        new AandC("Trample"),
                    };
                    break;

                case "Malayan Quillrat": 
                case "Malayan Quillrat Pup": 
                case "Porcupette": 
                case "Silent Hedgehog":
                    /* Abilities:
                     * Slot 1: Bite         | Poison Fang
                     * Slot 2: Spiked Skin  | Counterstrike
                     * Slot 3: Survival     | Powerball
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () =>  hp < 0.3),
                        new AandC("Spiked Skin",    () =>  ! buff("Spiked Skin")),
                        new AandC("Bite"),
                        new AandC("Poison Fang"),
                        new AandC("Counterstrike"),
                        new AandC("Powerball"),
                    };
                    break;

                case "Nether Roach":
                    /* Abilities:
                     * Slot 1: Flank    | Nether Blast
                     * Slot 2: Hiss     | Survival
                     * Slot 3: Swarm    | Apocalypse
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Flank"),
                        new AandC("Nether Blast"),
                        new AandC("Hiss"),
                        new AandC("Swarm"),
                        new AandC("Apocalypse"),
                    };
                    break;

                case "Peanut":
                case "Pint-Sized Pink Pachyderm":
                    /* Abilities:
                     * Slot 1: Smash            | Trample
                     * Slot 2: Trumpet Strike   | Survival
                     * Slot 3: Headbutt         | Stampede 
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",           () => hp < 0.3 ),
                        new AandC("Headbutt"),
                        new AandC("Smash"),
                        new AandC("Trample"),
                        new AandC("Trumpet Strike"),
                        new AandC("Stampede"),
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
                    /* Abilities:
                     * Slot 1: Ooze Touch   | Absorb
                     * Slot 2: Acidic Goo   | Shell Shield
                     * Slot 3: Dive         | Headbutt
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Acidic Goo",     () => ! debuff("Acidic Goo")),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield")),
                        new AandC("Headbutt"),
                        new AandC("Dive"),
                        new AandC("Ooze Touch"),
                        new AandC("Absorb"),
                    };
                    break;

                case "Wolpertinger":
                    /* Abilities:
                     * Slot 1: Scratch  | Horn Attack
                     * Slot 2: Flyby    | Sleeping Gas
                     * Slot 3: Headbutt | Rampage
                     */
                    critter_abilities = new List<AandC>() 
                    {
                        new AandC("Headbutt"),
                        new AandC("Scratch"),
                        new AandC("Horn Attack"),
                        new AandC("Flyby"),
                        new AandC("Sleeping Gas"),
                        new AandC("Rampage"),
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