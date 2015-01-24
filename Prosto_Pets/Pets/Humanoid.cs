//////////////
// HUMANOID //
//////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Humanoid : PetTacticsBase
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

            List<AandC> humanoid_abilities;

            switch (petName)
            {
                case "Anubisath Idol":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Crush        | Demolish
                     * Slot 2: Sandstorm    | Stoneskin
                     * Slot 3: Deflection   | Rupture
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Deflection", () => shouldIHide),
                        new AandC("Sandstorm",  () => ! weather("Sandstorm")),
                        new AandC("Demolish",   () => myPetIsLucky),
                        new AandC("Stoneskin",  () => ! buff("Stoneskin")),
                        new AandC("Stoneskin",  () => buffLeft("Stoneskin") == 1 && speed <= speedEnemy),
                        new AandC("Rupture"),
                        new AandC("Crush"),
                        new AandC("Demolish"),
                    };
                    break;

                case "Ashleaf Spriteling":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Poisoned Branch  | Punch
                     * Slot 2: Solar Beam       | Wild Magic
                     * Slot 3: Entangling Roots | Thorns
                     * 
                     * Tactic Information:
                     * Solar Beam results in stun which is risky. Use only with enough health
                     * Entangling Roots should only be used if the match lasts at least 2 more turns
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Solar Beam",         () => weather("Sunny Day") && hp > 0.4),  
                        new AandC("Wild Magic",         () => ! debuff("Wild Magic")),
                        new AandC("Thorns",             () => ! buff("Thorns")),  
                        new AandC("Entangling Roots",   () => hpEnemy > 0.25),  
                        new AandC("Poisoned Branch"), 
                        new AandC("Punch"),
                        new AandC("Solar Beam"),
                    };
                    break;

                case "Bonkers":
                    /* Changelog:
                     * 2015-01-20: Dodge is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Jab              | Bite
                     * Slot 2: Going Bonkers!   | Dodge
                     * Slot 3: Haymaker         | Tornado Punch
                     * 
                     * Tactic Information:
                     * Dodge is used to avoid big hits
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Going Bonkers!",     () => ! buff("Bonkers!")),
                        new AandC("Dodge",              () => shouldIHide && speed >= speedEnemy), 
                        new AandC("Haymaker",           () => myPetIsLucky),
                        new AandC("Tornado Punch"),
                        new AandC("Jab"), 
                        new AandC("Bite"),
                    };
                    break;

                case "Corefire Imp":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Rush
                     * Slot 2: Immolation   | Flamethrower
                     * Slot 3: Cauterize    | Wild Magic
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Cauterize",      () => hp < 0.7),
                        new AandC("Wild Magic",     () => ! debuff("Wild Magic")),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Flamethrower",   () => ! debuff("Flamethrower")),
                        new AandC("Burn"),
                        new AandC("Rush"),
                    };
                    break;

                case "Curious Oracle Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch            | Water Jet
                     * Slot 2: Super Sticky Goo | Aged Yolk
                     * Slot 3: Backflip         | Dreadful Breath
                     * 
                     * TODO: Reintroduce Aged Yolk - Needs to consider pet auras
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Super Sticky Goo",   () => strong("Super Sticky Goo")),
                        new AandC("Backflip"),
                        new AandC("Dreadful Breath",    () => hp > 0.5),
                        new AandC("Punch"),
                        new AandC("Water Jet"),
                    };
                    break;

                case "Curious Wolvar Pup":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch        | Bite
                     * Slot 2: Snap Trap    | Frenzyheart Brew
                     * Slot 3: Whirlwind    | Maul
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Maul",               () => enemyIsBleeding),
                        new AandC("Snap Trap",          () => hpEnemy > 0.6),
                        new AandC("Frenzyheart Brew",   () => ! buff("Frenzyheart Brew")),
                        new AandC("Whirlwind"),
                        new AandC("Maul"),
                        new AandC("Punch"),
                        new AandC("Bite"),
                    };
                    break;

                case "Dandelion Frolicker":
                    /* Changelog:
                     * 2015-01-20: Frolicking is now used more regularly - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Scratch  | Bite
                     * Slot 2: Frolick  | Barkskin
                     * Slot 3: Kick     | Dazzling Dance
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Frolick",        () => ! buff("Frolicking")), 
                        new AandC("Dazzling Dance", () => ! buff("Dazzling Dance")),  
                        new AandC("Barkskin",       () => ! buff("Barkskin")),  
                        new AandC("Kick",           () => speed > speedEnemy),  
                        new AandC("Scratch"), 
                        new AandC("Bite"),
                    };
                    break;

                case "Deathy":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch            | Deep Breath
                     * Slot 2: Scorched Earth   | Call Darkness
                     * Slot 3: Clobber          | Roar
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Scorched Earth", () => ! weather("Scorched Earth")),
                        new AandC("Call Darkness",  () => ! weather("Darkness")),
                        new AandC("Roar",           () => ! buff ("Attack Boost")),
                        new AandC("Clobber",        () => ! enemyIsStunned && ! enemyIsResilient),
                        new AandC("Punch"),
                        new AandC("Deep Breath"),
                    };
                    break;

                case "Father Winter's Helper":
                case "Winter's Little Helper":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Snowball         | Ice Lance
                     * Slot 2: Call Blizzard    | Eggnog
                     * Slot 3: Ice Tomb         | Gift of Winter's Veil
                     * 
                     * TODO: Reintroduce Eggnog - Needs to consider pet auras
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Call Blizzard",          () => ! weather("Blizzard")),
                        new AandC("Ice Tomb",               () => ! debuff("Ice Tomb") && hpEnemy > 0.5),
                        new AandC("Gift of Winter's Veil"),  
                        new AandC("Snowball"),
                        new AandC("Ice Lance"),
                    };
                    break;

                case "Feral Vermling":
                case "Hopling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Crush        | Tongue Lash
                     * Slot 2: Sticky Goo   | Poison Lash
                     * Slot 3: Backflip     | Dreadful Breath
                     * 
                     * TODO: Reintroduce Sticky Goo for PvP
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Poison Lash",        () => ! debuff("Poisoned")),
                        new AandC("Backflip"),
                        new AandC("Dreadful Breath",    () => hp > 0.4 && hpEnemy > 0.4),
                        new AandC("Crush"),
                        new AandC("Tongue Lash"),
                    };
                    break;

                case "Fiendish Imp":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn         | Sear Magic
                     * Slot 2: Immolation   | Flamethrower
                     * Slot 3: Rush         | Nether Gate
                     * 
                     * Tactic Information:
                     * Immolation/Flamethrower added at the end to avoid passing turns
                     * 
                     * TODO: Reintroduce Sear Magic - Needs to consider pet auras
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Rush",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Flamethrower",   () => ! debuff("Flamethrower")),
                        new AandC("Nether Gate"),
                        new AandC("Burn"),
                        new AandC("Immolation"),
                        new AandC("Flamethrower"),
                    };
                    break;

                case "Flayer Youngling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Blitz    | Triple Snap
                     * Slot 2: Focus    | Deflection
                     * Slot 3: Kick     | Rampage
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Deflection",     () => shouldIHide),
                        new AandC("Focus",          () => ! buff("Focused")),
                        new AandC("Kick"),
                        new AandC("Rampage",        () => hp > 0.5 && ! weak("Rampage")),
                        new AandC("Blitz"),
                        new AandC("Triple Snap"),
                    };
                    break;

                case "Gregarious Grell":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch        | Burn
                     * Slot 2: Immolate     | Phase Shift
                     * Slot 3: Cauterize    | Sear Magic
                     * 
                     * TODO: Reintroduce Sear Magic - Needs to consider pet auras
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Phase Shift",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Cauterize",      () => hp < 0.7),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Punch"),
                        new AandC("Burn"),
                    };
                    break;

                case "Grommloc":
                    /* Changelog
                     * 2015-01-24: Takedown is only used if the enemy is stunned - Studio60
                     *             Clobber won't activate if enemy is stunned or resilient - Studio60
                     * 2015-01-12: Initial Tactic by Misanthrope
                     * 
                     * Abilities
                     * Slot 1: Vicious Slice    | Smash
                     * Slot 2: Clobber          | Mighty Charge
                     * Slot 3: Giant's Blood    | Takedown
                     */
                    humanoid_abilities = new List<AandC>() 
                    {           
                        new AandC("Giant's Blood",  () => ! buff("Attack Boost") || hp < 0.6),
                        new AandC("Takedown",       () => enemyIsStunned),
                        new AandC("Clobber",        () => ! enemyIsResilient && ! enemyIsStunned),
                        new AandC("Mighty Charge"),
                        new AandC("Vicious Slice"),
                        new AandC("Smash"),
                    };
                    break;

                case "Grunty":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Gauss Rifle  | U-238 Rounds
                     * Slot 2: Stimpack     | Shield Block
                     * Slot 3: Launch       | Lock-On
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Launch",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Shield Block",   () => shouldIHide && speed >= speedEnemy),
                        new AandC("Stimpack",       () => ! buff("Stimpack")),
                        new AandC("Lock-On",        () => buff("Locked On")),
                        new AandC("Lock-On",        () => hpEnemy > 0.4 && ! weak("Lock-On")),
                        new AandC("Gauss Rifle"),
                        new AandC("U-238 Rounds"),
                    };
                    break;

                case "Gurky":
                case "Lurky":
                case "Murki":
                case "Murky":
                case "Terky":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch        | Flank
                     * Slot 2: Acid Touch   | Lucky Dance
                     * Slot 3: Clobber      | Stampede
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Clobber",        () => ! enemyIsStunned && ! enemyIsResilient),
                        new AandC("Lucky Dance",    () => ! ! buff("Lucky Dnce")),
                        new AandC("Acid Touch",     () => ! debuff("Acid Touch")),
                        new AandC("Stampede",       () => ! debuff("Shattered Defenses") && hp > 0.4),
                        new AandC("Punch"),
                        new AandC("Flank"),
                    };
                    break;

                case "Harbinger of Flame":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Jab          | Burn
                     * Slot 2: Magma Wave   | Immolate
                     * Slot 3: Impale       | Conflagrate
                     * 
                     * TODO: Magma Wave needs to consider battlefield objects
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Impale",         () => hpEnemy < 0.25),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Conflagrate",    () => enemyIsBurning),
                        new AandC("Jab"),
                        new AandC("Burn"),
                        new AandC("Magma Wave"),
                    };
                    break;

                case "Harpy Youngling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Quills   | Slicing Wind
                     * Slot 2: Flyby    | Counterstrike
                     * Slot 3: Squawk   | Lift-Off
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Flyby",          () => ! debuff("Weakened Defenses")),
                        new AandC("Counterstrike",  () => speed < speedEnemy),
                        new AandC("Squawk",         () => ! debuff("Attack Reduction")),
                        new AandC("Quills"),
                        new AandC("Slicing Wind"),
                    };
                    break;

                case "Kun-Lai Runt":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Thrash   | Takedown
                     * Slot 2: Mangle   | Frost Shock
                     * Slot 3: Rampage  | Deep Freeze
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Mangle",         () => ! debuff("Mangle")),
                        new AandC("Frost Shock",    () => ! debuff("Frost Shock")),
                        new AandC("Rampage",        () => ! weak("Rampage") && hp > 0.4 && hpEnemy > 0.4),
                        new AandC("Deep Freeze"),
                        new AandC("Thrash"),
                        new AandC("Takedown"),
                    };
                    break;

                case "Lil' Bad Wolf":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Claw     | Counterstrike
                     * Slot 2: Mangle   | Dodge
                     * Slot 3: Howl     | Pounce
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Dodge",          () => shouldIHide && speed >= speedEnemy),
                        new AandC("Mangle",         () => debuff("Mangle")),
                        new AandC("Howl",           () => ! debuff("Shattered Defenses")),
                        new AandC("Pounce",         () => strong("Pounce") || speed > speedEnemy),
                        new AandC("Claw"),
                        new AandC("Counterstrike"),
                    };
                    break;

                case "Mini Tyrael":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Holy Sword   | Omnislash
                     * Slot 2: Holy Justice | Surge of Light
                     * Slot 3: Holy Charge  | Restoration
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Restoration",    () => hp < 0.75),
                        new AandC("Holy Justice",   () => ! enemyIsResilient && ! enemyIsStunned),
                        new AandC("Surge of Light"),
                        new AandC("Holy Charge",    () => hpEnemy > 0.4),
                        new AandC("Holy Sword"),
                        new AandC("Omnislash"),
                    };
                    break;

                case "Moonkin Hatchling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch            | Solar Beam
                     * Slot 2: Entangling Roots | Clobber
                     * Slot 3: Cyclone          | Moonfire
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Moonfire",           () => ! weather("Sunlight") && ! weather("Moonlight")),
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Entangling Roots",   () => ! debuff("Entangling Roots") && hpEnemy > 0.4),
                        new AandC("Clobber",            () => ! enemyIsStunned && ! enemyIsResilient),
                        new AandC("Punch"),
                        new AandC("Solar Beam"),
                    };
                    break;

                case "Murkablo":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Burn             | Bone Prison 
                     * Slot 2: Agony            | Drain Power
                     * Slot 3: Blast of Hatred  | Scorched Earth
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Scorched Earth",     () => ! weather("Scorched Earth")),
                        new AandC("Agony",              () => ! debuff("Agony")),
                        new AandC("Drain Power",        () => ! debuff("Attack Reduction")),
                        new AandC("Blast of Hatred",    () => strong("Blast of Hatred") || speed > speedEnemy),
                        new AandC("Burn"),
                        new AandC("Bone Prison"),
                    };
                    break;

                case "Murkalot":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punish                   | Blessed Hammer
                     * Slot 2: Falling Murloc           | Reflective Shield
                     * Slot 3: Righteous Inspiration    | Shieldstorm
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Shieldstorm",            () => shouldIHide && speed >= speedEnemy),
                        new AandC("Reflective Shield",      () => ! debuff("Reflective Shield")),
                        new AandC("Righteous Inspiration"),
                        new AandC("Falling Murloc"),
                        new AandC("Punish"),
                        new AandC("Blessed Hammer"),
                    };
                    break;

                case "Murkimus the Gladiator":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Punch        | Flurry
                     * Slot 2: Shield Block | Counterstrike
                     * Slot 3: Heroic Leap  | Haymaker
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Heroic Leap",    () => shouldIHide && speed >= speedEnemy),
                        new AandC("Shield Block",   () => shouldIHide && speed >= speedEnemy),
                        new AandC("Haymaker",       () => myPetIsLucky),
                        new AandC("Counterstrike",  () => speed < speedEnemy),
                        new AandC("Punch"),
                        new AandC("Flurry"),
                    };
                    break;

                case "Pandaren Monk":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Jab                  | Takedown
                     * Slot 2: Focus Chi            | Staggered Steps
                     * Slot 3: Fury of 1,000 Fists  | Blackout Kick
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Takedown",               () => enemyIsStunned),
                        new AandC("Focus Chi",              () => ! buff("Focus Chi")),
                        new AandC("Fury of 1,000 Fists",    () => buff("Focus Chi")),
                        new AandC("Blackout Kick",          () => ! enemyIsStunned && ! enemyIsResilient),
                        new AandC("Staggered Steps",        () => ! buff("Staggered Steps")),
                        new AandC("Fury of 1,000 Fists"),
                        new AandC("Jab"),
                        new AandC("Takedown"),
                    };
                    break;

                case "Peddlefeet":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Bow Shot                 | Rapid Fire
                     * Slot 2: Lovestruck               | Perfumed Arrow
                     * Slot 3: Shot Through The Heart   | Love Potion
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Love Potion",            () => hp < 0.7),
                        new AandC("Lovestruck",             () => ! enemyIsStunned && ! enemyIsResilient),
                        new AandC("Perfumed Arrow"),
                        new AandC("Shot Through The Heart", () => hpEnemy > 0.4), 
                        new AandC("Bow Shot"),
                        new AandC("Rapid Fire"),
                    };
                    break;

                case "Qiraji Guardling":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Crush            | Whirlwind
                     * Slot 2: Hawk Eye         | Sandstorm
                     * Slot 3: Reckless Strike  | Blackout Kick
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Sandstorm",          () => ! weather("Sandstorm")),
                        new AandC("Blackout Kick",      () => speed > speedEnemy && ! enemyIsResilient && ! enemyIsStunned),
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")), 
                        new AandC("Reckless Strike",    () => hp > hpEnemy),
                        new AandC("Crush"),
                        new AandC("Whirlwind"),
                    };
                    break;

                case "Rotten Little Helper":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Club | Ice Lance
                     * Slot 2: Booby-Trapped Presents | Ice Tomb
                     * Slot 3: Greench's Gift | Call Blizzard
                     * 
                     * Tactic Information:
                     * Ice Tomb needs 3 turns to hit so it is used when the enemy is going to be alive for a bit
                     * 
                     * TODO: Booby-Trapped Presents needs to check how many enemies there are
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Ice Tomb",                   () => hpEnemy > 0.6),
                        new AandC("Greench's Gift"),  
                        new AandC("Call Blizzard",              () => ! debuff("Blizzard")),
                        new AandC("Club"),
                        new AandC("Ice Lance"),
                        new AandC("Booby-Trapped Presents"),  
                    };
                    break;

                case "Sporeling Sprout":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Jab              | Charge
                     * Slot 2: Creeping Fungus  | Leech Seed
                     * Slot 3: Spore Shrooms    | Crouch
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Creeping Fungus",    () => ! debuff("Creeping Fungus")),
                        new AandC("Leech Seed",         () => ! debuff("Leech Seed")),
                        new AandC("Spore Shrooms",      () => ! debuff("Spore Shrooms") && hpEnemy > 0.6),
                        new AandC("Crouch",             () => ! buff("Crouch")),
                        new AandC("Crouch",             () => buffLeft("Crouch") == 1 && speed < speedEnemy),
                        new AandC("Jab"),
                        new AandC("Charge"),
                    };
                    break;

                case "Stunted Yeti":
                    /* Changelog:
                     * 2015-01-24: Viable base tactic designed - Studio60
                     * 
                     * Abilities
                     * Slot 1: Thrash   | Punch
                     * Slot 2: Mangle   | Haymaker
                     * Slot 3: Rampage  | Bash
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Mangle",     () => ! debuff("Mangle")),
                        new AandC("Haymaker",   () => myPetIsLucky),
                        new AandC("Rampage",    () => ! weak("Rampage") && hp > 0.4 && hpEnemy > 0.4),
                        new AandC("Bash",       () => ! enemyIsStunned && ! enemyIsResilient),
                        new AandC("Thrash"),
                        new AandC("Punch"),
                    };
                    break;

                case "Ore Eater":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Acid Touch   | Punch
                     * Slot 2: Shell Armor  | Spiny Carapace
                     * Slot 3: Body Slam    | Demolish
                     * 
                     * Tactic Information:
                     * Shell Armor should block knockback damage (Untested)
                     * 
                     * TODO: Use Spiny Carapace again on anticipated big hit
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Shell Armor",    () => ! buff("Shell Armor")),
                        new AandC("Spiny Carapace", () => ! buff("Spiny Carapace")),  
                        new AandC("Body Slam",      () => buff("Shell Armor")),
                        new AandC("Demolish",       () => myPetIsLucky),
                        new AandC("Acid Touch"),  
                        new AandC("Punch"),
                    };
                    break;

                case "Sister of Temptation":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Shadow Shock     | Agony
                     * Slot 2: Curse of Doom    | Siphon Life
                     * Slot 3: Lovestruck   | Haunting Song
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Curse of Doom",  () => ! debuff("Curse of Doom") && hpEnemy > 0.5), 
                        new AandC("Siphon Life",    () => ! debuff("Siphon Life") && hp < 0.9),  
                        new AandC("Lovestruck"),  
                        new AandC("Haunting Song",  () => hp < 0.8),
                        new AandC("Shadow Shock"),
                        new AandC("Agony"),
                    };
                    break;

                case "Treasure Goblin":
                    /* Changelog:
                     * 2015-01-20: Dodge is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Portal is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities
                     * Slot 1: Coin Toss    | Magic Sword
                     * Slot 2: Wild Magic   | Sear Magic
                     * Slot 3: Dodge        | Portal
                     * 
                     * TODO: Sear Magic needs to check for negative/positive auras on pet
                     * TODO: Portal needs to check for alternate pets in team
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Wild Magic",     () => ! debuff("Wild Magic")),
                        new AandC("Dodge",          () => shouldIHide && speed >= speedEnemy), 
                        new AandC("Portal",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Coin Toss"),
                        new AandC("Magic Sword"), 
                        new AandC("Sear Magic"),                      
                    };
                    break;

                case "Wretched Servant":
                    /* Changelog:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1
                     * 
                     * Abilities
                     * Slot 1: Jab          | Nether Blast
                     * Slot 2: Consume      | Weakness
                     * Slot 3: Wild Magic   | Consume Magic
                     * 
                     * * TODO: Consume Magic needs to check for negative/positive auras on pet
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Wild Magic",     () => ! debuff("Wild Magic")),
                        new AandC("Consume",        () => hp < 0.7), 
                        new AandC("Weakness",       () => ! debuff("Weakness")),
                        new AandC("Jab"), 
                        new AandC("Nether Blast"),
                        new AandC("Consume Magic"),
                    };
                    break;

                default:
                    //////////////////////////
                    // Unknown Humanoid Pet //
                    //////////////////////////
                    Logger.Alert("Unknown humanoid pet: " + petName);
                    humanoid_abilities = null;
                    break;
            }

            return humanoid_abilities;



        }
    }
}
