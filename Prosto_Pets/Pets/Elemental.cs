//////////////-
// ELEMENTAL //
//////////////-


using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Elemental : PetTacticsBase
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

            List<AandC> elemental_abilities;

            switch (petName)
            {
                case "Amethyst Shale Hatchling":
                case "Crimson Shale Hatchling":
                case "Emerald Shale Hatchling":
                case "Tiny Shale Spider":
                case "Topaz Shale Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Leech Life
                     * Slot 2: Sticky Web   | Poison Spit
                     * Slot 3: Stone Rush   | Stoneskin
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Stoneskin",      () => ! buff("Stoneskin")),
                        new AandC("Stoneskin",      () => buffLeft("Stoneskin") == 1 && speed < speedEnemy),
                        new AandC("Sticky Web",     () => ! debuff("Webbed")),
                        new AandC("Poison Spit",    () => ! debuff("Poisoned")),
                        new AandC("Stone Rush",     () => ! weak("Stone Rush")),
                        new AandC("Burn"),
                        new AandC("Leech Life"),
                    };
                    break;

                case "Ammen Vale Lashling":
                case "Crimson Lasher":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash             | Poison Lash
                     * Slot 2: Soothing Mists   | Plant
                     * Slot 3: Stun Seed        | Entangling Roots
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Soothing Mists",     () => ! buff("Soothing Mists")),
                        new AandC("Plant",              () => ! buff("Planted") && hp > 0.4),
                        new AandC("Plant",              () => buff("Planted") && hp < 0.4),
                        new AandC("Stun Seed",          () => ! debuff("Stun Seed") && hpEnemy > 0.4),
                        new AandC("Entangling Roots",   () => ! debuff("Entangling Roots") && hpEnemy > 0.4),
                        new AandC("Lash"),
                        new AandC("Poison Lash"),
                    };
                    break;

                case "Ashstone Core":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Feedback         | Burn
                     * Slot 2: Crystal Overload | Stoneskin
                     * Slot 3: Crystal Prison   | Instability
                     * 
                     * TODO: Reintroduce Crystal Prison with viable use case
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Crystal Overload",   () => buff("Crystal Overload") && hp > 0.50),
                        new AandC("Stoneskin",          () => ! buff("Stoneskin")),
                        new AandC("Instability",        () => buff("Uncanny Luck")),
                        new AandC("Feedback"),
                        new AandC("Burn"),
                    };
                    break;

                case "Blazing Cindercrawler":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn             | Flamethrower
                     * Slot 2: Brittle Webbing  | Heat Up
                     * Slot 3: Magma Wave       | Cauterize
                     *
                     * Tactic Information:
                     * Magma Wave is currently only used for clean up
                     * Magma Wave could be used differently if we knew how many enemies there are
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Brittle Webbing",    () => ! debuff("Brittle Webbing")),
                        new AandC("Heat Up",            () => ! buff("Heat Up")),
                        new AandC("Magma Wave",         () => debuff("Turret") || debuff("Decoy")),
                        new AandC("Cauterize",          () => hp < 0.6),
                        new AandC("Burn"),
                        new AandC("Flamethrower"),
                    };
                    break;

                case "Blossoming Ancient":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Poisoned Branch  | Ironbark
                     * Slot 2: Autumn Breeze    | Photosynthesis
                     * Slot 3: Stun Seed        | Sunlight
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Photosynthesis",     () => ! buff("Photosynthesis") && hp < 0.8),
                        new AandC("Sunlight",           () => ! buff("Sunlight")),
                        new AandC("Autumn Breeze",      () => ! buff("Autumn Breeze")),
                        new AandC("Stun Seed",          () => ! debuff("Stun Seed") && hpEnemy > 0.3),
                        new AandC("Poisoned Branch"),
                        new AandC("Ironbark"),
                    };
                    break;

                case "Cinder Kitten":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw     | Rend
                     * Slot 2: Immolate | Leap 
                     * Slot 3: Prowl    | Scorched Earth
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth")),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Prowl",          () => ! buff("Prowl") && speed * 0.7 > speedEnemy),
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Claw"),
                        new AandC("Rend"),
                    };
                    break;

                case "Core Hound Pup":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Scratch  | Trash
                     * Slot 2: Howl     | Dodge
                     * Slot 3: Burn     | Burrow
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Burrow",     () => shouldIHide && speed >= speedEnemy),
                        new AandC("Dodge",      () => shouldIHide && speed >= speedEnemy),
                        new AandC("Howl",       () => ! debuff("Shattered Defenses")),
                        new AandC("Burn",       () => myPetHasAbility("Scratch") && (weak("Scratch") || strong("Burn"))),
                        new AandC("Burn",       () => myPetHasAbility("Thrash") && (weak("Thrash") || strong("Burn"))),
                        new AandC("Scratch"),
                        new AandC("Thrash"),
                    };
                    break;

                case "Crazy Carrot":
                    /* Changelog:
                     * 2015-01-21: Blistering Cold has had its priority increased - Studio60
                     *             Ironbark has had its priority reduced - Studio60
                     * 2015-01-20: Blistering Cold is now used correctly - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Jab              | Ironbark
                     * Slot 2: Acid Rain        | Aged Yolk
                     * Slot 3: Blistering Cold  | Bash
                     *
                     * Tactic Information:
                     * Acid Rain is not cast if the enemy is aquatic
                     * 
                     * TODO: Aged Yolk needs to check for positive/negative auras
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Blistering Cold",    () => ! debuff("Blistering Cold")),
                        new AandC("Acid Rain",          () => ! weather("Cleansing Rain") && ! famEnemy(PF.Aquatic)),
                        new AandC("Bash"),
                        new AandC("Ironbark",           () => ! buff("Ironbark")),
                        new AandC("Jab"),
                        new AandC("Ironbark"),
                        new AandC("Aged Yolk"),
                    };
                    break;

                case "Crimson Geode":
                case "Elementium Geode":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Feedback         | Spark
                     * Slot 2: Crystal Overload | Amplify Magic
                     * Slot 3: Stone Rush       | Elementium Bolt
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Crystal Overload",   () => buff("Crystal Overload") && hp > 0.50),
                        new AandC("Amplify Magic",      () => ! buff("Amplify Magic") && hpEnemy > 0.2),
                        new AandC("Stone Rush",         () => ! weak("Stone Rush")),
                        new AandC("Elementium Bolt",    () => hpEnemy > 0.4),
                        new AandC("Feedback"),
                        new AandC("Spark"),
                    };
                    break;

                case "Dark Phoenix Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn | Laser
                     * Slot 2: Darkflame | Immolate
                     * Slot 3: Conflagrate | Dark Rebirth
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Dark Rebirth",   () => hp < 0.15),
                        new AandC("Conflagrate",    () => enemyIsBurning()),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Darkflame"),
                        new AandC("Burn"),
                        new AandC("Laser"),
                    };
                    break;

                case "Doom Bloom":
                    /* Changelog:
                     * 2015-01-20: Stun Seed is now only used if it is not already active - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash             | Bite
                     * Slot 2: Consume Corpse   | Healing Wave
                     * Slot 3: Stun Seed        | Entangling Roots
                     *
                     * Tactic Information:
                     * Entangling Roots is cast only if we expect more than one additional turn
                     * 
                     * TODO: Consume Corpse  needs to detect dead allies
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Healing Wave",       () => hp < 0.7),
                        new AandC("Stun Seed",          () => ! debuff("Stun Seed")),
                        new AandC("Entangling Roots",   () => hpEnemy > 0.25),
                        new AandC("Lash"),
                        new AandC("Bite"),
                        new AandC("Consume Corpse"),
                    };
                    break;

                case "Droplet of Y'Shaarj":
                    /* Changelog:
                     * 2015-01-21: Dreadful Breath is now only used when health is above 50% (up from 40%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Corrosion | Swallow You Whole
                     * Slot 2: Acid Rain | Expunge
                     * Slot 3: Dreadful Breath | Curse of Doom
                     *
                     * Tactic Information:
                     * Curse of Doom is cast early to give it time to explode
                     * Acid Rain is not used against aquatic enemies
                     * Dreadful Breath is only used during Cleansing Rain
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Curse of Doom",      () => hpEnemy > 0.8),
                        new AandC("Swallow You Whole",  () => hp < 0.25),
                        new AandC("Acid Rain",          () => ! weather("Cleansing Rain") && ! famEnemy(PF.Aquatic)),
                        new AandC("Expunge"),
                        new AandC("Dreadful Breath",    () => weather("Cleansing Rain") && hp > 0.5),
                        new AandC("Corrosion"),
                        new AandC("Swallow You Whole"),
                    };
                    break;

                case "Electrified Razortooth":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Rip              | Jolt
                     * Slot 2: Paralyzing Shock | Blood in the Water
                     * Slot 3: Devour           | Lightning Shield
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Devour",             () => hpEnemy < 0.2),
                        new AandC("Devour",             () => strong("Devour") && hpEnemy < 0.3),
                        new AandC("Paralyzing Shock"),
                        new AandC("Lightning Shield"),
                        new AandC("Blood in the Water", () => enemyIsBleeding()),
                        new AandC("Rip"),
                        new AandC("Jolt"),
                    };
                    break;

                case "Fel Flame":
                case "Searing Scorchling":
                    /* Changelog:
                     * 2015-01-24: Existing tactic revised - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Flame Breath
                     * Slot 2: Immolate     | Scorched Earth
                     * Slot 3: Conflagrate  | Immolation
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth")),
                        new AandC("Conflagrate",    () => enemyIsBurning()),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Burn"),
                        new AandC("Flame Breath"),
                    };
                    break;

                case "Forest Sproutling":
                    /* Changelog:
                     * 2015-01-20: Sons of the Root is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Refuge is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-19: Refuge is now used defensively against 2-turn-attacks (Lift-Off etc.) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash                 | Club
                     * Slot 2: Refuge               | Leech Seed
                     * Slot 3: Fist of the Forest   | Sons of the Root
                     *
                     * Tactic Information:
                     * Sons of the Root is only used defensively
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Sons of the Root",   () => shouldIHide && speed >= speedEnemy),
                        new AandC("Refuge",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Leech Seed",         () => ! debuff("Leech Seed")),
                        new AandC("Fist of the Forest"),
                        new AandC("Lash"),
                        new AandC("Club"),
                    };
                    break;

                case "Frigid Frostling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Ice Lance    | Surge
                     * Slot 2: Frost Nova   | Slippery Ice
                     * Slot 3: Ice Tomb     | Howling Blast
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Frost Nova",     () => ! enemyIsChilled()),
                        new AandC("Slippery Ice",   () => ! debuff("Slippery Ice")),
                        new AandC("Ice Tomb",       () => hpEnemy > 0.5),
                        new AandC("Howling Blast",  () => enemyIsChilled()),
                        new AandC("Ice Lance"),
                        new AandC("Surge"),

                    };
                    break;

                case "Gooey Sha-ling":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Seethe           | Creeping Ooze
                     * Slot 2: Call Darkness    | Breath of Sorrow
                     * Slot 3: Agony            | Death and Decay
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Call Darkness",      () => ! weather("Darkness")),
                        new AandC("Breath of Sorrow",   () => ! debuff("Healing Reduction")),
                        new AandC("Agony",              () => ! debuff("Agony")),
                        new AandC("Death and Decay",    () => ! debuff("Death and Decay")),
                        new AandC("Seethe"),
                        new AandC("Creeping Ooze"),
                    };
                    break;

                case "Grinder":
                case "Lumpy": 
                case "Pebble":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Stone Shot   | Stone Rush
                     * Slot 2: Sandstorm    | Rupture
                     * Slot 3: Rock Barrage | Quake
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Sandstorm",      () => ! weather("Standstorm")),
                        new AandC("Rock Barrage",   () => ! debuff("Rock Barrage")),
                        new AandC("Rupture"),
                        new AandC("Quake",          () => weak("Stone Shot") || strong("Quake")),
                        new AandC("Stone Shot"),
                        new AandC("Stone Rush"),
                    };
                    break;

                case "Hatespark the Tiny":
                    /* Changelog:
                     * 2015-01-20: Conflagrate is now checking for all burn effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Blast of Hatred  | Deep Burn
                     * Slot 2: Conflagrate      | Cauterize
                     * Slot 3: Flamethrower     | Armageddon
                     *
                     * TODO: Armageddon should check for other living team pets
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Flamethrower",       () => ! debuff("Burning")),
                        new AandC("Armageddon",         () => hp < 0.1),
                        new AandC("Conflagrate",        () => enemyIsBurning()),
                        new AandC("Cauterize",          () => hp < 0.6),
                        new AandC("Blast of Hatred"),
                        new AandC("Deep Burn"),
                    };
                    break;

                case "Jadefire Spirit":
                    /* Changelog:
                     * 2015-01-20: Fade is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Immolate is no longer used if it is already active - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Jade Breath      | Jade Claw
                     * Slot 2: Emerald Presence | Immolate
                     * Slot 3: Healing Flame    | Fade
                     * 
                     * Tactic Information:
                     * Fade - Not sure if usable without backup pets. needs testing
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Fade",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Emerald Presence",   () => ! buff("Emerald Presence")),
                        new AandC("Immolate",           () => ! debuff("Immolate")),
                        new AandC("Healing Flame",      () => hp < 0.6),
                        new AandC("Jade Breath"),	
                        new AandC("Jade Claw"),	
                    };
                    break;

                case "Jademist Dancer":
                    /* Changelog:
                     * 2015-01-19: 	Jadeskin is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     *              Rain Dance is only used if the enemy's health is above 15% (up from 0%) - Studio60
                     *              Rain Dance is only used if pet health is below 80% (down from 100%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Steam Vent   | Jade Claw
                     * Slot 2: Jadeskin     | Rain Dance
                     * Slot 3: Acid Rain    | Geyser
                     *
                     * Tactic Information:
                     * Geyser is only used if enemy is going to live long enough
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Acid Rain",      () => ! weather("Cleansing Rain")),
                        new AandC("Jadeskin",       () => ! buff("Jadeskin") && hpEnemy > 0.15),
                        new AandC("Rain Dance",     () => ! buff("Rain Dance")  && hp < 0.8 && hpEnemy > 0.15),
                        new AandC("Geyser",         () => hpEnemy > 0.4),
                        new AandC("Steam Vent"),
                        new AandC("Jade Claw"),
                    };
                    break;

                case "Jade Tentacle":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Scratch          | Poisoned Branch
                     * Slot 2: Shell Shield     | Photosynthesis
                     * Slot 3: Entangling Roots | Thorns
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Photosynthesis",     () => ! buff("Photosynthesis") && hp < 0.8),
                        new AandC("Shell Shield",       () => ! buff("Shell Shield")),
                        new AandC("Shell Shield",       () => buffLeft("Shell Shield") == 1 && speed < speedEnemy),
                        new AandC("Thorns",             () => ! buff("Thorns")),
                        new AandC("Entangling Roots",   () => hpEnemy > 0.4),
                        new AandC("Scratch"),
                        new AandC("Poisoned Branch"),
                    };
                    break;

                case "Kirin Tor Familiar":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Beam             | Arcane Blast
                     * Slot 2: Gravity          | Arcane Storm
                     * Slot 3: Arcane Explosion | Rot
                     * 
                     * TODO: Reintroduce Arcane Explosion - Needs to consider enemy team status
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Arcane Storm",       () => ! weather("Arcane Winds")),
                        new AandC("Rot",                () => ! debuff("Rot") && famEnemy(PF.Aquatic)),
                        new AandC("Gravity"),
                        new AandC("Beam"),
                        new AandC("Arcane Blast"),
                    };
                    break;

                case "Lava Crab":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Survival
                     * Slot 2: Shell Shield | Cauterize
                     * Slot 3: Conflagrate  | Magma Wave
                     * 
                     * Tactic Information:
                     * Conflagrate/Magma Wave are at the end in case Survival is picked
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Survival",       () => hp < 0.3),
                        new AandC("Cauterize",      () => hp < 0.7),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield")),
                        new AandC("Shell Shield",   () => buffLeft("Shell Shield") == 1 && speed < speedEnemy),
                        new AandC("Conflagrate"),
                        new AandC("Burn"),
                        new AandC("Magma Wave"),
                    };
                    break;

                case "Lil' Ragnaros":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Sulfuras Smash   | Magma Wave
                     * Slot 2: Magma Trap       | Conflagrate
                     * Slot 3: Flamethrower     | Sons of the Flame
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Sons of the Flame",  () => shouldIHide && speed >= speedEnemy),
                        new AandC("Conflagrate",        () => enemyIsBurning()),
                        new AandC("Flamethrower",       () => ! debuff("Flamethrower")),
                        new AandC("Magma Trap"),
                        new AandC("Sulfuras Smash"),
                        new AandC("Magma Wave"),
                    };
                    break;

                case "Living Sandling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch        | Sand Bolt
                     * Slot 2: Stoneskin    | Sandstorm
                     * Slot 3: Stone Rush   | Quicksand
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Stoneskin",      () => ! buff("Stoneskin")), 
                        new AandC("Sandstorm",      () => ! weather("Standstorm")), 
                        new AandC("Stone Rush"), 
                        new AandC("Quicksand",      () => ! debuff("Quicksand")),
                        new AandC("Punch"), 
                        new AandC("Sand Bolt"), 
                    };
                    break;

                case "Molten Corgi":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bark                 | Flamethrower
                     * Slot 2: Superbark            | Cauterize
                     * Slot 3: Puppies of the Flame | Inferno Herding
                     * 
                     * TODO: Reintroduce Inferno Herding - Needs to consider enemy team status
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Puppies of the Flame",   () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cauterize",              () => hp < 0.7),
                        new AandC("Superbark",              () => hpEnemy > 0.3),
                        new AandC("Bark"),
                        new AandC("Flamethrower"),
                    };
                    break;

                case "Nightshade Sproutling":
                    /* Changelog:
                     * 2015-01-20: Blinding Poison is now only used if the enemy does not have Blinding Poison - Studio60
                     * 2015-01-19: Nature's Ward conditions have been changed- Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash             | Poison Lash
                     * Slot 2: Nature's Ward    | Call Darkness
                     * Slot 3: Blinding Poison  | Fist of the Forest
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Poison Lash",        () => ! debuff("Poisoned")),
                        new AandC("Nature's Ward",      () => hp < 0.9 && ! famEnemy(PF.Aquatic) && ! buff("Nature's Ward")),
                        new AandC("Call Darkness"),
                        new AandC("Blinding Poison",    () => ! debuff("Blinding Poison")),
                        new AandC("Fist of the Forest"),	
                        new AandC("Lash"),
                    };
                    break;

                case "Ominous Flame":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Spiritfire Bolt
                     * Slot 2: Nimbus       | Scorched Earth
                     * Slot 3: Conflagrate  | Forboding Curse
                     * 
                     * Tactic Information:
                     * Nimbus is not really needed by this pet
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Scorched Earth",     () => ! weather("Scorched Earth")),
                        new AandC("Forboding Curse",    () => ! debuff("Forboding Curse")),
                        new AandC("Conflagrate"),
                        new AandC("Burn"),
                        new AandC("Spiritfire Bolt"),
                        new AandC("Nimbus"),
                    };
                    break;

                case "Pandaren Air Spirit":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Wild Winds
                     * Slot 2: Whirlwind    | Soothing Mists
                     * Slot 3: Cyclone      | Arcane Storm
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Soothing Mists", () => ! buff("Soothing Mists") && hp < 0.8),
                        new AandC("Arcane Storm",   () => ! weather("Arcane Winds") || ! weak("Arcane Storm")),
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Whirlwind"),
                        new AandC("Slicing Wind"),
                        new AandC("Wild Winds"),
                    };
                    break;

                case "Pandaren Earth Spirit":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Stone Shot       | Stone Rush
                     * Slot 2: Rupture          | Rock Barrage
                     * Slot 3: Crystal Prison   | Mudslide
                     * 
                     * TODO: Reintroduce Crystal Prison with viable use case
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Mudslide",       () => ! weather("Mudslide")),
                        new AandC("Rock Barrage",   () => ! debuff("Rock Barrage")),
                        new AandC("Rupture"),
                        new AandC("Stone Shot"),
                        new AandC("Stone Rush"),
                    };
                    break;

                case "Pandaren Fire Spirit":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Magma Wave
                     * Slot 2: Immolate     | Flamethrower
                     * Slot 3: Cauterize    | Conflagrate
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Cauterize",      () => hp < 0.7),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Flamethrower",   () => ! debuff("Flamethrower")),
                        new AandC("Conflagrate"),
                        new AandC("Burn"),
                        new AandC("Magma Wave"),
                    };
                    break;

                case "Pandaren Water Spirit":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Water Jet    | Tidal Wave
                     * Slot 2: Healing Wave | Whirlpool
                     * Slot 3: Dive         | Geyser
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Dive",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Healing Wave",   () => hp < 0.7),
                        new AandC("Geyser",         () => ! debuff("Geyser") && hpEnemy > 0.6),
                        new AandC("Whirlpool",      () => ! debuff("Whirlpool") && hpEnemy > 0.4),
                        new AandC("Water Jet"),
                        new AandC("Tidal Wave"),
                    };
                    break;

                case "Phoenix Hatchling":
                    /* Changelog:
                     * 2015-01-24: Conflagrate now considers global burning status changes
                     * 
                     * Abilities
                     * Slot 1: Burn         | Peck
                     * Slot 2: Cauterize    | Immolate
                     * Slot 3: Immolation   | Conflagrate
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Cauterize",      () => hp < 0.7),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Conflagrate",    () => enemyIsBurning()),
                        new AandC("Burn"),
                        new AandC("Peck"),
                    };
                    break;

                case "Ruby Droplet":
                    /* Changelog:
                     * 2015-01-20: Dive is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Bubble is now used to hide from huge attacks if it is faster or both pets have equal speed - Studio60
                     * 2015-01-19: Dreadful Breath is only used if pet health is over 40% (up from 0%) - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Acid Touch       | Absorb
                     * Slot 2: Dive             | Bubble
                     * Slot 3: Plagued Blood    | Drain Blood
                     */
                    // very defensive pet
                    elemental_abilities = new List<AandC>() {
                        new AandC("Dive",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Bubble",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Plagued Blood",  () => ! debuff("Plagued")),
                        new AandC("Drain Blood",    () => hp < 0.7),
                        new AandC("Acid Touch"),
                        new AandC("Absorb"),
                    };
                    break;

                case "Ruby Sapling":
                case "Teldrassil Sproutling":
                case "Withers":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     *             Merged Ruby Sapling/Teldrassil Sproutling/Withers tactics
                     * 
                     * Abilities
                     * Slot 1: Scratch          | Ironbark
                     * Slot 2: Thorns           | Poisoned Branch
                     * Slot 3: Photosynthesis   | Entangling Roots
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Photosynthesis",     () => ! buff("Photosynthesis") && hp < 0.8),
                        new AandC("Poisoned Branch",    () => ! debuff("Poisoned")),
                        new AandC("Thorns",             () => ! buff("Thorns")),
                        new AandC("Entangling Roots",   () => hpEnemy > 0.4),
                        new AandC("Scratch"),
                        new AandC("Ironbark"),
                    };
                    break;

                case "Sapphire Cub":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash         | Pounce
                     * Slot 2: Rake         | Screech
                     * Slot 3: Stone Rush   | Prowl
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Prowl",      () => ! buff("Prowl") && speed * 0.7 > speedEnemy),
                        new AandC("Screech",    () => ! debuff("Speed Reduction")),
                        new AandC("Stone Rush"),
                        new AandC("Rake"),
                        new AandC("Lash"),
                        new AandC("Pounce"),
                    };
                    break;

                case "Singing Sunflower":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash             | Solar Beam
                     * Slot 2: Photosynthesis   | Inspiring Song
                     * Slot 3: Early Advantage  | Sunlight
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Photosynthesis",     () => ! buff("Photosynthesis") && hp < 0.8),
                        new AandC("Early Advantage",    () => hp < hpEnemy),
                        new AandC("Inspiring Song",     () => hp < 0.9),
                        new AandC("Sunlight",           () => ! weather("Sunlight")),
                        new AandC("Lash"),
                        new AandC("Solar Beam"),
                    };
                    break;

                case "Sinister Squashling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn     | Poison Lash
                     * Slot 2: Thorns   | Stun Seed
                     * Slot 3: Plant    | Leech Seed
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Thorns",     () => ! buff("Thorns")),
                        new AandC("Stun Seed",  () => ! debuff("Stun Seed") && hpEnemy > 0.4),
                        new AandC("Plant",      () => ! buff("Planted") && hp > 0.4),
                        new AandC("Plant",      () => buff("Planted") && hp < 0.3),
                        new AandC("Leech Seed"),
                        new AandC("Burn"),
                        new AandC("Poison Lash"),
                    };
                    break;

                case "Skunky Alemental":
                    /* Changelog:
                     * 2015-01-19: Mudslide is no longer used if it is already active - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Brew Bolt    | Barrel Toss
                     * Slot 2: Mudslide     | Skunky Brew
                     * Slot 3: Inebriate    | Explosive Brew
                     *
                     * Tactic Information:
                     * Barrel Toss is prioritizes if barrel is ready.
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Explosive Brew",     () => ! debuff("Explosive Brew") && hpEnemy > 0.5),
                        new AandC("Barrel Toss",        () => buff("Barrel Ready")),
                        new AandC("Mudslide",           () => ! weather("Mudslide")),
                        new AandC("Skunky Brew"),
                        new AandC("Inebriate",          () => ! debuff("Inebriate")),
                        new AandC("Brew Bolt"),
                        new AandC("Barrel Toss"),
                    };
                    break;

                case "Soul of the Forge":
                    /* Changelog:
                     * 2015-01-20: Extra Plating is now also used if both pets have the same speed - Studio60
                     *             Stoneskin is now also used if both pets have the same speed - Studio60
                     * 2015-01-19: Flamethrower now recognizes the "Flamethrower" debuff on enemies - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Deep Burn        | Sulfuras Smash
                     * Slot 2: Extra Plating    | Stoneskin
                     * Slot 3: Flamethrower     | Reforge
                     *
                     * Tactic Information:
                     * Trying to keep defenses up 
                     * Trying to keep the enemy burning
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Flamethrower",       () => ! debuff("Flamethrower")),
                        new AandC("Extra Plating",      () => ! buff("Extra Plating") && speed >= speedEnemy),
                        new AandC("Extra Plating",      () => buffLeft("Extra Plating") == 1 && speed < speedEnemy),
                        new AandC("Stoneskin",          () => ! buff("Stoneskin") && speed >= speedEnemy),
                        new AandC("Stoneskin",          () => buffLeft("Stoneskin") == 1 && speed < speedEnemy),
                        new AandC("Reforge",            () => hp < 0.4),
                        new AandC("Deep Burn"),
                        new AandC("Sulfuras Smash"),
                    };
                    break;

                case "Spirit of Summer":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Flame Breath
                     * Slot 2: Immolate     | Scorched Earth
                     * Slot 3: Conflagrate  | Immolation
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Scorched Earth",     () => ! weather("Scorched Earth")),
                        new AandC("Immolation",         () => ! buff("Immolation")),
                        new AandC("Immolate",           () => ! debuff("Immolate")),
                        new AandC("Conflagrate",        () => enemyIsBurning()),
                        new AandC("Burn"),
                        new AandC("Flame Breath"),
                    };
                    break;

                case "Stout Alemental":
                    /* Changelog:
                     * 2015-01-20: Dive is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Brew Bolt    | Barrel Toss
                     * Slot 2: Inebriate    | Explosive Brew
                     * Slot 3: Dive         | Bubble
                     */
                    elemental_abilities = new List<AandC>() {
                        new AandC("Dive",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Explosive Brew", () => ! debuff("Explosive Brew") && hpEnemy > 0.5),
                        new AandC("Barrel Toss",    () => buff("Barrel Ready")),
                        new AandC("Bubble",         () => shouldIHide),
                        new AandC("Inebriate",      () => ! debuff("Inebriate")),
                        new AandC("Brew Bolt"),
                        new AandC("Barrel Toss"),
                    };
                    break;

                case "Sun Sproutling":
                    /* Changelog:
                     * 2015-01-18: Photosynthesis is no longer used if it is already active (Studio60)
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash                 | Club
                     * Slot 2: Photsynthesis        | Healing Wave
                     * Slot 3: Fist of the Forest   | Solar Beam
                     */
                    // solar beam: try to use as finisher because of the recovery
                    elemental_abilities = new List<AandC>() {
                        new AandC("Photosynthesis",     () => hp < 0.9 && ! buff("Photosynthesis")),
                        new AandC("Healing Wave",       () => hp < 0.7),
                        new AandC("Fist of the Forest"),
                        new AandC("Solar Beam",         () => hpEnemy < 0.2 || (weather("Sunny Day") && hpEnemy < 0.3)),
                        new AandC("Lash"),
                        new AandC("Club"),
                    };
                    break;

                case "Tainted Waveling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Ooze Touch   | Poison Spit
                     * Slot 2: Acidic Goo   | Corrosion
                     * Slot 3: Healing Wave | Creeping Ooze
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Healing Wave",   () => hp < 0.7),
                        new AandC("Creeping Ooze",  () => ! debuff("Creeping Ooze")),
                        new AandC("Acidic Goo",     () => ! debuff("Acidic Goo")),
                        new AandC("Corrosion",      () => ! debuff("Corrosion")),
                        new AandC("Ooze Touch"),
                        new AandC("Poison Spit"),
                    };
                    break;

                case "Terrible Turnip":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Weakening Blow   | Tidal Wave
                     * Slot 2: Leech Seed       | Inspiring Song
                     * Slot 3: Sunlight         | Sons of the Root
                     * 
                     * TODO: Create failsafe/switchout mechanic because of Weakening Blow
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Sons of the Root",   () => shouldIHide && speed >= speedEnemy),
                        new AandC("Sunlight",           () => ! weather("Sunlight")),
                        new AandC("Leech Seed",         () => ! debuff("Leech Seed") && hp < 0.7),
                        new AandC("Inspiring Song",     () => hp < 0.8),
                        new AandC("Weakening Blow",     () => hpEnemy > 0.05 ),
                        new AandC("Tidal Wave"),
                    };
                    break;

                case "Thundertail Flapper":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Tail Slap        | Jolt
                     * Slot 2: Buried Treasure  | Lightning Shield
                     * Slot 3: Thunderbolt      | Beaver Dam
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Beaver Dam",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Buried Treasure",    () => hp < 0.7),
                        new AandC("Lightning Shield",   () => ! buff("Lightning Shield")),
                        new AandC("Thunderbolt"),
                        new AandC("Tail Slap"),
                        new AandC("Jolt"),
                    };
                    break;

                case "Tiny Bog Beast":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Crush        | Clobber
                     * Slot 2: Lash         | Leap
                     * Slot 3: Poison Lash  | Rampage
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Leap",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Lash",           () => speed > speedEnemy),
                        new AandC("Poison Lash",    () => ! debuff("Poisoned")),
                        new AandC("Rampage",        () => hp > 0.4),
                        new AandC("Crush"),
                        new AandC("Clobber"),
                    };
                    break;

                case "Tiny Snowman":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Snowball         | Magic Hat
                     * Slot 2: Call Blizzard    | Frost Nova
                     * Slot 3: Howling Blast    | Deep Freeze
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Call Blizzard",  () => ! weather("Blizzard")),
                        new AandC("Frost Nova",     () => ! enemyIsChilled()),
                        new AandC("Howling Blast"),
                        new AandC("Deep Freeze"),
                        new AandC("Snowball"),
                        new AandC("Magic Hat"),
                    };
                    break;

                case "Tiny Twister":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Slicing Wind | Wild Winds
                     * Slot 2: Flyby        | Bash
                     * Slot 3: Cyclone      | Call Lightning
                     * 
                     * TODO: Bash needs a real use case
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Cyclone",        () => ! debuff("Cyclone")),
                        new AandC("Call Lightning", () => ! weather("Lightning Storm")),
                        new AandC("Flyby",          () => ! debuff("Weakened Defenses")),
                        new AandC("Bash",           () => hpEnemy > 0.3),
                        new AandC("Slicing Wind"),
                        new AandC("Wild Winds"),
                    };
                    break;

                case "Venus":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Lash         | Poison Lash
                     * Slot 2: Sunlight     | Plant
                     * Slot 3: Stun Seed    | Leech Seed
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Sunlight",       () => ! weather("Sunlight")),
                        new AandC("Stun Seed",      () => ! debuff("Stun Seed") && hpEnemy > 0.4),
                        new AandC("Leech Seed",     () => ! debuff("Leech Seed") && hp < 0.8),
                        new AandC("Plant",          () => ! buff("Planted") && hp > 0.5),
                        new AandC("Plant",          () => buff("Planted") && hp < 0.3),
                        new AandC("Lash"),
                        new AandC("Poison Lash"),
                    };
                    break;

                case "Water Waveling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Water Jet    | Ice Lance
                     * Slot 2: Frost Nova   | Frost Shock
                     * Slot 3: Geyser       | Tidal Wave
                     */
                    elemental_abilities = new List<AandC>() 
                    {
                        new AandC("Frost Nova",     () => ! enemyIsChilled()),
                        new AandC("Frost Shock",    () => ! debuff("Frost Shock")),
                        new AandC("Geyser",         () => ! debuff("Geyser") && hpEnemy > 0.5),
                        new AandC("Tidal Wave",     () => debuff("Decoy") || debuff("Turret")),
                        new AandC("Water Jet"),
                        new AandC("Ice Lance"),
                    };
                    break;
            
                default:
                    ///////////////////////////
                    // Unknown Elemental Pet //
                    ///////////////////////////
                    Logger.Alert("Unknown elemental pet: " + petName);
                    elemental_abilities = null;
                    break;
            }

            return elemental_abilities;
        }
    }
}
