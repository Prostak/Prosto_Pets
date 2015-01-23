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
                    /* Abilities
                     * Slot 1: Crush        | Demolish
                     * Slot 2: Sandstorm    | Stoneskin
                     * Slot 3: Deflection   | Rupture
                     * 
                     * TODO: Add Uncanny Luck to Demolish
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Deflection",     () => shouldIHide),
                        new AandC("Sandstorm"),                            
                        new AandC("Crush"),
                        new AandC("Demolish"),
                        new AandC("Stoneskin"),
                        new AandC("Rupture"),
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
                     * 
                     * TODO: Add Uncanny Strike to Haymaker
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Going Bonkers!",     () => ! buff("Bonkers!")),
                        new AandC("Dodge",              () => shouldIHide && speed >= speedEnemy), 
                        new AandC("Haymaker"),
                        new AandC("Tornado Punch"),
                        new AandC("Jab"), 
                        new AandC("Bite"),
                    };
                    break;

                case "Corefire Imp":
                    /* Abilities
                     * Slot 1: Burn         | Rush
                     * Slot 2: Immolation   | Flamethrower
                     * Slot 3: Cauterize    | Wild Magic
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Rush",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Burn"),
                        new AandC("Flamethrower"),
                        new AandC("Cauterize"),
                        new AandC("Wild Magic"),
                    };
                    break;

                case "Curious Oracle Hatchling":
                    /* Abilities
                     * Slot 1: Punch            | Water Jet
                     * Slot 2: Super Sticky Goo | Aged Yolk
                     * Slot 3: Backflip         | Dreadful Breath
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Punch"),
                        new AandC("Water Jet"),
                        new AandC("Super Sticky Goo"),
                        new AandC("Aged Yolk"),
                        new AandC("Backflip"),
                        new AandC("Dreadful Breath"),
                    };
                    break;

                case "Curious Wolvar Pup":
                    /* Abilities
                     * Slot 1: Punch        | Bite
                     * Slot 2: Snap Trap    | Frenzyheart Brew
                     * Slot 3: Whirlwind    | Maul
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Punch"),
                        new AandC("Bite"),
                        new AandC("Snap Trap"),
                        new AandC("Frenzyheart Brew"),
                        new AandC("Whirlwind"),
                        new AandC("Maul"),
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
                    /* Abilities
                     * Slot 1: Punch            | Deep Breath
                     * Slot 2: Scorched Earth   | Call Darkness
                     * Slot 3: Clobber          | Roar
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Punch"),
                        new AandC("Deep Breath"),
                        new AandC("Scorched Earth"),
                        new AandC("Call Darkness"),
                        new AandC("Clobber"),
                        new AandC("Roar"),
                    };
                    break;

                case "Father Winter's Helper":
                case "Winter's Little Helper":
                    /* Abilities
                     * Slot 1: Snowball         | Ice Lance
                     * Slot 2: Call Blizzard    | Eggnog
                     * Slot 3: Ice Tomb         | Gift of Winter's Veil
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Snowball"),
                        new AandC("Ice Lance"),
                        new AandC("Call Blizzard"),
                        new AandC("Eggnog"),
                        new AandC("Ice Tomb"),
                        new AandC("Gift of Winter's Veil"),  
                    };
                    break;

                case "Feral Vermling":
                case "Hopling":
                    /* Abilities
                     * Slot 1: Crush        | Tongue Lash
                     * Slot 2: Sticky Goo   | Poison Lash
                     * Slot 3: Backflip     | Dreadful Breath
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Crush"),
                        new AandC("Tongue Lash"),
                        new AandC("Sticky Goo"),
                        new AandC("Poison Lash"),
                        new AandC("Backflip"),
                        new AandC("Dreadful Breath"),
                    };
                    break;

                case "Fiendish Imp":
                    /* Abilities
                     * Slot 1: Burn         | Sear Magic
                     * Slot 2: Immolation   | Flamethrower
                     * Slot 3: Rush         | Nether Gate
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Rush",           () => speed < speedEnemy && ! buff("Speed Boost")),
                        new AandC("Immolation",     () => ! buff("Immolation")),
                        new AandC("Burn"),
                        new AandC("Sear Magic"),
                        new AandC("Flamethrower"),
                        new AandC("Nether Gate"),
                    };
                    break;

                case "Flayer Youngling":
                    /* Abilities
                     * Slot 1: Blitz    | Triple Snap
                     * Slot 2: Focus    | Deflection
                     * Slot 3: Kick     | Rampage
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Blitz"),
                        new AandC("Triple Snap"),
                        new AandC("Focus"),
                        new AandC("Deflection"),
                        new AandC("Kick"),
                        new AandC("Rampage"),
                    };
                    break;

                case "Gregarious Grell":
                    /* Abilities
                     * Slot 1: Punch        | Burn
                     * Slot 2: Immolate     | Phase Shift
                     * Slot 3: Cauterize    | Sear Magic
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Punch"),
                        new AandC("Burn"),
                        new AandC("Phase Shift"),
                        new AandC("Cauterize"),
                        new AandC("Sear Magic"),
                    };
                    break;

                case "Grommloc":
                    /* Changelog
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
                        new AandC("Vicious Slice"),
                        new AandC("Smash"),
                        new AandC("Clobber"),
                        new AandC("Mighty Charge"),
                        new AandC("Takedown"),
                    };
                    break;

                case "Grunty":
                    /* Abilities
                     * Slot 1: Gauss Rifle  | U-238 Rounds
                     * Slot 2: Stimpack     | Shield Block
                     * Slot 3: Launch       | Lock-On
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Gauss Rifle"),
                        new AandC("U-238 Rounds"),
                        new AandC("Stimpack"),
                        new AandC("Shield Block"),
                        new AandC("Launch"),
                        new AandC("Lock-On"),
                    };
                    break;

                case "Gurky":
                case "Lurky":
                case "Murki":
                case "Murky":
                case "Terky":
                    /* Abilities
                     * Slot 1: Punch        | Flank
                     * Slot 2: Acid Touch   | Lucky Dance
                     * Slot 3: Clobber      | Stampede
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Punch"),
                        new AandC("Flank"),
                        new AandC("Acid Touch"),
                        new AandC("Lucky Dance"),
                        new AandC("Clobber"),
                        new AandC("Stampede"),
                    };
                    break;

                case "Harbinger of Flame":
                    /* Abilities
                     * Slot 1: Jab          | Burn
                     * Slot 2: Magma Wave   | Immolate
                     * Slot 3: Impale       | Conflagrate
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Impale",         () => hpEnemy < 0.25 ),
                        new AandC("Immolate",       () => ! debuff("Immolate")),
                        new AandC("Conflagrate",    () => debuff("Immolate") || weather("Scorched Earth")),
                        new AandC("Jab"),
                        new AandC("Burn"),
                        new AandC("Magma Wave"),
                    };
                    break;

                case "Harpy Youngling":
                    /* Abilities
                     * Slot 1: Quills   | Slicing Wind
                     * Slot 2: Flyby    | Counterstrike
                     * Slot 3: Squawk   | Lift-Off
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Lift-Off"),
                        new AandC("Quills"),
                        new AandC("Slicing Wind"),
                        new AandC("Flyby"),
                        new AandC("Counterstrike"),
                        new AandC("Squawk"),
                    };
                    break;

                case "Kun-Lai Runt":
                    /* Abilities
                     * Slot 1: Thrash   | Takedown
                     * Slot 2: Mangle   | Frost Shock
                     * Slot 3: Rampage  | Deep Freeze
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Thrash"),
                        new AandC("Takedown"),
                        new AandC("Mangle"),
                        new AandC("Frost Shock"),
                        new AandC("Rampage"),
                        new AandC("Deep Freeze"),
                    };
                    break;

                case "Lil' Bad Wolf":
                    /* Abilities
                     * Slot 1: Claw     | Counterstrike
                     * Slot 2: Mangle   | Dodge
                     * Slot 3: Howl     | Pounce
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Claw"),
                        new AandC("Counterstrike"),
                        new AandC("Mangle"),
                        new AandC("Dodge"),
                        new AandC("Howl"),
                        new AandC("Pounce"),
                    };
                    break;

                case "Mini Tyrael":
                    /* Abilities
                     * Slot 1: Holy Sword   | Omnislash
                     * Slot 2: Holy Justice | Surge of Light
                     * Slot 3: Holy Charge  | Restoration
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Holy Sword"),
                        new AandC("Omnislash"),
                        new AandC("Holy Justice"),
                        new AandC("Surge of Light"),
                        new AandC("Holy Charge"),
                        new AandC("Restoration"),
                    };
                    break;

                case "Moonkin Hatchling":
                    /* Abilities
                     * Slot 1: Punch            | Solar Beam
                     * Slot 2: Entangling Roots | Clobber
                     * Slot 3: Cyclone          | Moonfire
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Cyclone",            () => ! debuff("Cyclone")),
                        new AandC("Punch"),
                        new AandC("Solar Beam"),
                        new AandC("Entangling Roots"),
                        new AandC("Clobber"),
                        new AandC("Moonfire"),
                    };
                    break;

                case "Murkablo":
                    /* Abilities
                     * Slot 1: Burn             | Bone Prison 
                     * Slot 2: Agony            | Drain Power
                     * Slot 3: Blast of Hatred  | Scorched Earth
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Burn"),
                        new AandC("Bone Prison"),
                        new AandC("Agony"),
                        new AandC("Drain Power"),
                        new AandC("Blast of Hatred"),
                        new AandC("Scorched Earth"),
                    };
                    break;

                case "Murkimus the Gladiator":
                    /* Abilities
                     * Slot 1: Punch        | Flurry
                     * Slot 2: Shield Block | Counterstrike
                     * Slot 3: Heroic Leap  | Haymaker
                     * 
                     * TODO: Add Uncanny Strike to Haymaker
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Punch"),
                        new AandC("Flurry"),
                        new AandC("Shield Block"),
                        new AandC("Counterstrike"),
                        new AandC("Heroic Leap"),
                        new AandC("Haymaker"),
                    };
                    break;

                case "Pandaren Monk":
                    /* Abilities
                     * Slot 1: Jab                  | Takedown
                     * Slot 2: Focus Chi            | Staggered Steps
                     * Slot 3: Fury of 1,000 Fists  | Blackout Kick
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Jab"),
                        new AandC("Takedown"),
                        new AandC("Focus Chi"),
                        new AandC("Staggered Steps"),
                        new AandC("Fury of 1,000 Fists"),
                        new AandC("Blackout Kick"),
                    };
                    break;

                case "Peddlefeet":
                    /* Abilities
                     * Slot 1: Bow Shot                 | Rapid Fire
                     * Slot 2: Lovestruck               | Perfumed Arrow
                     * Slot 3: Shot Through The Heart   | Love Potion
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Bow Shot"),
                        new AandC("Rapid Fire"),
                        new AandC("Lovestruck"),
                        new AandC("Perfumed Arrow"),
                        new AandC("Shot Through The Heart"), 
                        new AandC("Love Potion"),
                    };
                    break;

                case "Qiraji Guardling":
                    /* Abilities
                     * Slot 1: Crush            | Whirlwind
                     * Slot 2: Hawk Eye         | Sandstorm
                     * Slot 3: Reckless Strike  | Blackout Kick
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Hawk Eye",           () => ! buff("Hawk Eye")), 
                        new AandC("Crush"),
                        new AandC("Whirlwind"),
                        new AandC("Sandstorm"),
                        new AandC("Reckless Strike"),
                        new AandC("Blackout Kick"),
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
                    /* Abilities
                     * Slot 1: Jab              | Charge
                     * Slot 2: Creeping Fungus  | Leech Seed
                     * Slot 3: Spore Shrooms    | Crouch
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Jab"),
                        new AandC("Charge"),
                        new AandC("Creeping Fungus"),
                        new AandC("Leech Seed"),
                        new AandC("Spore Shrooms"),
                        new AandC("Crouch"),
                    };
                    break;

                case "Stunted Yeti":
                    /* Abilities
                     * Slot 1: Thrash   | Punch
                     * Slot 2: Mangle   | Haymaker
                     * Slot 3: Rampage  | Bash
                     * 
                     * TODO: Add Uncanny Strike to Haymaker
                     */
                    humanoid_abilities = new List<AandC>() 
                    {
                        new AandC("Thrash"),
                        new AandC("Punch"),
                        new AandC("Mangle"),
                        new AandC("Haymaker"),
                        new AandC("Rampage"),
                        new AandC("Bash"),
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
                     * TODO: Add Uncanny Luck to Demolish
                     */
                    humanoid_abilities = new List<AandC>() {
                        new AandC("Shell Armor",    () => ! buff("Shell Armor")),
                        new AandC("Spiny Carapace", () => ! buff("Spiny Carapace")),  
                        new AandC("Body Slam",      () => buff("Shell Armor")),
                        new AandC("Demolish"),
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
