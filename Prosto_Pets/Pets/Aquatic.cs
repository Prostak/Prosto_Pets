/////////////////////////
// AQUATIC PET TACTICS //
/////////////////////////

using System;
using System.Collections.Generic;

namespace Prosto_Pets
{
    public class Aquatic : PetTacticsBase
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

            List<AandC> aquatic_abilities;

            switch (petName)
            {
                case "Aqua Strider":
                case "Dancing Water Skimmer":
                case "Eternal Strider":
                case "Mirror Strider":
                    /* Abilities:
                     * Slot 1: Water Jet    | Poison Spit
                     * Slot 2: Healing Wave | Cleansing Rain
                     * Slot 3: Soothe       | Pump
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Healing Wave", 	 () => hp < 0.7 ),	
			            new AandC( "Cleansing Rain", () => hp < 0.9 ),	
			            new AandC( "Water Jet"), 
			            new AandC( "Poison Spit",	 () =>	buff("Pumped Up")),	
			            new AandC( "Soothe"),
			            new AandC( "Pump",      	 () => ! buff("Pumped Up") ),  
		            };
                    break;

                case "Biletoad":
                case "Frog": 
                case "Garden Frog": 
                case "Huge Toad": 
                case "Jubling": 
                case "Jungle Darter": 
                case "Leopard Tree Frog": 
                case "Mac Frog": 
                case "Mojo": 
                case "Small Frog": 
                case "Spotted Bell Frog": 
                case "Toad": 
                case "Tree Frog":
                case "Wood Frog":
                case "Yellow-Bellied Bullfrog":
                    /* Abilities:
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Healing Wave | Cleansing Rain
                     * Slot 3: Frog Kiss    | Swarm of Flies
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Healing Wave", 	    () => hp < 0.7 ),
			            new AandC( "Water Jet"),
			            new AandC( "Tongue Lash"),	 
			            new AandC( "Cleansing Rain"),
			            new AandC( "Frog Kiss"),	
			            new AandC( "Swarm of Flies")
		            };
                    break;

                case "Chuck":
                case "Muckbreath":
                case "Snarly":
                case "Toothy":
                    /* Abilities:
                     * Slot 1: Rip      | Consume
                     * Slot 2: Surge    | Water Jet
                     * Slot 3: Devour   | Blood in the Water
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Devour",             () => hpEnemy < 0.20 ),	
			            new AandC( "Rip"),	
			            new AandC( "Consume"),
			            new AandC( "Surge"),
			            new AandC( "Water Jet"),	
			            new AandC( "Blood in the Water")
		            };
                    break;

                case "Darkmoon Turtle":
                case "Softshell Snapling":
                case "Speedy":
                case "Spiny Terrapin":
                case "Turquoise Turtle":
                    /* Abilities:
                     * Slot 1: Bite         | Grasp
                     * Slot 2: Shell Shield | Healing Wave
                     * Slot 3: Headbutt     | Powerball
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Healing Wave",  () => hp < 0.7 ),
			            new AandC( "Headbutt"),
			            new AandC( "Shell Shield",  () => ! buff("Shell Shield") ),
			            new AandC( "Bite"),
			            new AandC( "Grasp"),
			            new AandC( "Powerball")
		            };
                    break;

                case "Emerald Turtle":
                    /* Abilities:
                     * Slot 1: Emerald Bite | Grasp
                     * Slot 2: Shell Shield | Healing Wave
                     * Slot 3: Headbutt     | Powerball
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Healing Wave", 	() => hp < 0.7 ),
			            new AandC( "Shell Shield",  () => ! buff("Shell Shield") ),
			            new AandC( "Headbutt"),
			            new AandC( "Emerald Bite"),
			            new AandC( "Grasp"),
			            new AandC( "Powerball"),
		            };
                    break;

                case "Emperor Crab":
                case "Shore Crab":
                case "Shore Crawler":
                case "Spirebound Crab":
                case "Strand Crab":
                case "Strand Crawler":
                    /* Abilities:
                     * Slot 1: Snap             | Surge
                     * Slot 2: Renewing Mists   | Healing Wave
                     * Slot 3: Shell Shield     | Whirlpool
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Surge",             () => hpEnemy < hp	),
			            new AandC( "Renewing Mists",    () => buffLeft("Renewing Mists") < 2	),
			            new AandC( "Healing Wave", 	    () => hp < 0.7 ),
			            new AandC( "Shell Shield", 	    () => buffLeft("Shell Shield") < 2 ),
			            new AandC( "Snap"),
			            new AandC( "Surge"),
			            new AandC( "Whirlpool")
		            };
                    break;

                case "Fishy":
                case "Tiny Goldfish":
                    /* Abilities:
                     * Slot 1: Water Jet        | Surge
                     * Slot 2: Cleansing Rain   | Healing Wave
                     * Slot 3: Whirlpool        | Pump
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Healing Wave", 	    () => hp < 0.7 ),
			            new AandC( "Water Jet"),
			            new AandC( "Surge"),
			            new AandC( "Cleansing Rain"),
			            new AandC( "Whirlpool"),
			            new AandC( "Pump")
		            };
                    break;

                case "Frostshell Pincher": 
                case "Ironclaw Scuttler": 
                case "Kelp Scuttler":
                    /* Changelog:
                     * 2015-01-20: Dive is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Rip              | Claw
                     * Slot 2: Spiny Carapace   | Shell Shield
                     * Slot 3: Dive             | Blood in the Water
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Dive",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Rip",                () => ! debuff("Bleeding")),
                        new AandC("Spiny Carapace",     () => ! buff("Spiny Carapace")),
                        new AandC("Shell Shield",       () => ! buff("Shell Shield")),
                        new AandC("Blood in the Water", () => debuff("Bleeding")),
                        new AandC("Rip"),
                        new AandC("Claw"),
                    };
                    break;

                case "Gahz'rooki":
                    /* Abilities:
                     * Slot 1: Bite         | Tail Slap
                     * Slot 2: Devour       | Swallow You Whole
                     * Slot 3: Whirlpool    | Geyser
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Devour", 		    () => 	hpEnemy < 0.20 ),
			            new AandC("Bite"),
			            new AandC("Tail Slap"),
			            new AandC("Swallow You Whole"),
			            new AandC("Whirlpool"),
			            new AandC("Geyser"),
		            };
                    break;

                case "Golden Civet": 
                case "Golden Civet Kitten": 
                case "Kuitan Mongoose": 
                case "Mongoose": 
                case "Mongoose Pup": 
                case "Sifang Otter": 
                case "Sifang Otter Pup":
                    /* Abilities:
                     * Slot 1: Bite     | Gnaw
                     * Slot 2: Screech  | Survival
                     * Slot 3: Surge    | Dive
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Survival", () => hp < 0.3 ),
			            new AandC( "Dive"),
			            new AandC( "Bite"),
			            new AandC( "Gnaw"),
			            new AandC( "Screech"),
			            new AandC( "Surge"),
		            };
                    break;

                case "Gulp Froglet":
                    /* Changelog:
                     * 2015-01-20: Toxic Skin is now only used if it is not already active - Studio60
                     * 2015-01-19: Mudslide is no longer used if it is already active - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet    | Frog Kiss
                     * Slot 2: Mudslide     | Toxic Skin
                     * Slot 3: Swarm        | Corpse Explosion
                     *
                     * TODO: Corpse Explosion should only be used if other friendly pets are alive
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Mudslide",           () => ! weather("Mudslide")),
                        new AandC("Toxic Skin",         () => ! buff("Toxic Skin")),
                        new AandC("Swarm",              () => ! debuff("Shattered Defenses")),
                        new AandC("Water Jet"),
                        new AandC("Frog Kiss"),
                        new AandC("Corpse Explosion"),
                    };
                    break;

                case "Hydraling":
                    /* Abilities:
                     * Slot 1: Deep Bite        | Tail Slap
                     * Slot 2: Call Lightning   | Swallow You Whole
                     * Slot 3: Shell Armor      | Whirlpool
                     *
                     * TODO: Call Lightning is not always beneficial, only if mech's on our side
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Swallow You Whole", () => hpEnemy < 0.25 ),
			            new AandC( "Call Lightning",    () => ! weather("Lightning Storm")),
			            new AandC( "Shell Armor"),
			            new AandC( "Whirlpool"),
			            new AandC( "Deep Byte"),
			            new AandC( "Tail Slap"),
		            };
                    break;

                case "Horny Toad":
                    /* Abilities:
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Healing Wave | Cleansing Rain
                     * Slot 3: Frog Kiss    | Swarm of Flies
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Healing Wave",      () => hp < 0.7 ),
			            new AandC( "Water Jet"),
			            new AandC( "Tongue Lash"),
			            new AandC( "Cleansing Rain"),
			            new AandC( "Frog Kiss"),
			            new AandC( "Swarm of Flies"),
		            };
                    break;

                case "Land Shark":
                    /* Changelog:
                     * 2015-01-20: Blood in the Water is now checking for all bleed effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet            | Tail Slap
                     * Slot 2: Tidal Wave           | Focus
                     * Slot 3: Blood in the Water   | Swallow You Whole
                     *
                     * TODO: Tidal Wave should check for enemy/own objects
                     * TODO: Blood in the Water should check if team pets have bleed abilities
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Swallow You Whole",  () => hpEnemy < 0.25),
                        new AandC("Tidal Wave",         () => debuff("Decoy") || debuff("Turret")),
                        new AandC("Focus",              () => ! buff("Focused")),
                        new AandC("Blood in the Water", () => enemyIsBleeding()),
                        new AandC("Water Jet"),
                        new AandC("Tail Slap"),
                    };
                    break;

                case "Leviathan Hatchling":
                    /* Changes:
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1 
                     *
                     * Abilities:
                     * Slot 1: Tail Slap    | Water Jet
                     * Slot 2: Toxic Skin   | Poison Spit
                     * Slot 3: Whirlpool    | Primal Cry
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Toxic Skin", () => ! buff("Toxic Skin")),	// Slot 2
                        new AandC("Poison Spit", () => ! debuff("Poisoned")),	// Slot 2
                        new AandC("Whirlpool", () => hpEnemy > 0.4),	// Slot 3
                        new AandC("Primal Cry", () => ! debuff("Speed Reduction")),	// Slot 3
                        new AandC("Tail Slap"),	// Slot 1
                        new AandC("Water Jet"),	// Slot 1
                    };
                    break;

                case "Magical Crawdad":
                    /* Abilities: 
                     * Slot 1: Snap             | Surge
                     * Slot 2: Renewing Mists   | Shell Shield
                     * Slot 3: Whirlpool        | Wish
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Shell Shield",      () => ! buff("Shell Shield")),
			            new AandC( "Snap"),
			            new AandC( "Surge"),
			            new AandC( "Renewing Mists"),
			            new AandC( "Whirlpool"),
			            new AandC( "Wish")
		            };
                    break;

                case "Moonshell Crab":
                    /* Abilities:
                     * Slot 1: Arcane Slash     | Water Jet
                     * Slot 2: Shell Shield     | Amplify Magic
                     * Slot 3: Renewing Mists   | Moon Tears
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Arcane Slash",      () => hpEnemy < 0.2 ),
			            new AandC( "Moon Tears"),
			            new AandC( "Renewing Mists",    () => hp < 0.7 && ! buff("Renewing Mists")	),
			            new AandC( "Amplify Magic",	    () => hp > 0.4),
			            new AandC( "Shell Shield",      () => hp < hpEnemy && ! buff("Shell Shield" )),
			            new AandC( "Arcane Slash"),
			            new AandC( "Water Jet"),
		            };
                    break;

                case "Mr. Chilly":
                case "Pengu": 
                case "Tundra Penguin":
                    /* Abilities:
                     * Slot 1: Peck         | Surge
                     * Slot 2: Frost Spit   | Slippery Ice
                     * Slot 3: Ice Lance    | Belly Slide
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Peck"),
			            new AandC("Surge"),
			            new AandC("Frost Spit"),
			            new AandC("Slippery Ice"),
			            new AandC("Ice Lance"),
			            new AandC("Belly Slide"),
		            };
                    break;

                case "Mud Jumper":
                    /* Changelog:
                     * 2015-01-20: Bubble is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     * 2015-01-19: Mudslide is no longer used if it is already active
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Mudslide     | Swarm of Flies
                     * Slot 3: Bubble       | Pump
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Bubble",         () => shouldIHide && speed >= speedEnemy),
                        new AandC("Pump",           () => buff("Pumped Up")),
                        new AandC("Mudslide",       () => ! weather("Mudslide")),
                        new AandC("Swarm of Flies", () => ! debuff("Swarm of Flies")),
                        new AandC("Pump",           () => hpEnemy > 0.4),
                        new AandC("Water Jet"),
                        new AandC("Tongue Lash"),
                    };
                    break;

                case "Puddle Terror":
                    /* Changelog:
                     * 2015-01-20: Dive is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Clobber is now checking for all stun effects - Studio60
                     * 2015-01-19: Clobber is only used if the enemy is not Resilient - Studio60
                     * 2015-01-19: Nature's Ward conditions have been changed - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Water Jet        | Punch
                     * Slot 2: Nature's Ward    | Clobber
                     * Slot 3: Sunlight         | Dive
                     *
                     * Tactic Information:
                     * Nature's Ward is not used against aquatic enemies due to type disadvantage
                    */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Dive",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Sunlight",       () => ! weather("Sunny Day")),
                        new AandC("Nature's Ward",  () => hp < 0.9 && ! famEnemy(PF.Aquatic) && ! buff("Nature's Ward")),
                        new AandC("Clobber",        () => ! enemyIsResilient()),
                        new AandC("Water Jet"),
                        new AandC("Punch"),
                    };
                    break;

                case "Purple Puffer":
                    /* Abilities: 
                     * Slot 1: Water Jet    | Surge
                     * Slot 2: Spiked Skin  | Healing Wave
                     * Slot 3: Whirlpool    | Pump
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC( "Healing Wave",  () => hp < 0.7 ),
			            new AandC( "Water Jet"),
			            new AandC( "Surge"),
			            new AandC( "Spiked Skin"),
			            new AandC( "Whirlpool"),
			            new AandC( "Pump"),
		            };
                    break;

                case "Sea Calf":
                    /* Changelog:
                     * 2015-01-20: Bubble is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Dive is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Blood in the Water is now checking for all bleed effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Water Jet    | Surge
                     * Slot 2: Bubble       | Dive
                     * Slot 3: Feed         | Blood in the Water
                     *
                     * TODO: Blood in the Water should check if team pets have bleed abilities
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Bubble",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Dive",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Feed",               () => hp < 0.7),
                        new AandC("Blood in the Water", () => enemyIsBleeding()),
                        new AandC("Water Jet"),
                        new AandC("Surge"),
                    };
                    break;

                case "Sea Pony":
                    /* Abilities: 
                     * Slot 1: Water Jet    | Tidal Wave
                     * Slot 2: Surge        | Cleansing Rain
                     * Slot 3: Whirlpool    | Pump
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Water Jet"),
			            new AandC("Tidal Wave"),
			            new AandC("Surge"),
			            new AandC("Cleansing Rain"),
			            new AandC("Whirlpool"),
			            new AandC("Pump"),
		            };
                    break;

                case "Spawn of G'nathus":
                    /* Abilities:
                     * Slot 1: Swallow You Whole    | Jolt
                     * Slot 2: Dive                 | Lightning Shield
                     * Slot 3: Thunderbolt          | Paralyzing Shock
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Dive"),
			            new AandC("Swallow You Whole"),
			            new AandC("Jolt"),
			            new AandC("Lightning Shield"),
			            new AandC("Thunderbolt"),
			            new AandC("Paralyzing Shock"),
		            };
                    break;

                case "Spineclaw Crab":
                    /* Changelog:
                     * 2015-01-20: Blood in the Water is now checking for all bleed effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Rip              | Triple Snap
                     * Slot 2: Spiny Carapace   | Healing Wave
                     * Slot 3: Whirlpool        | Blood in the Water
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Rip",                () => ! debuff("Bleeding")),
                        new AandC("Spiny Carapace",     () => ! buff("Spiny Carapace")),
                        new AandC("Healing Wave",       () => hp < 0.6),
                        new AandC("Whirlpool",          () => hpEnemy > 0.5),
                        new AandC("Blood in the Water", () => enemyIsBleeding()),
                        new AandC("Rip"),
                        new AandC("Triple Snap"),
                    };
                    break;

                case "Swamp Croaker":
                    /* Abilities:
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Croak        | Swarm of Flies
                     * Slot 3: Frog Kiss    | Bubble
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Bubble",         () => hp < 0.7 ),
			            new AandC("Water Jet"),
			            new AandC("Tongue Lash"),
			            new AandC("Frog Kiss"),
			            new AandC("Swarm of Flies"),
			            new AandC("Croak"),
		            };
                    break;

                case "Tideskipper":
                    /* Abilities:
                     * Slot 1: Crush        | Grasp
                     * Slot 2: Tidal Wave   | Body Slam
                     * Slot 3: Clobber      | Geyser
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Crush"),
			            new AandC("Grasp"),
			            new AandC("Tidal Wave"),
			            new AandC("Body Slam"),
			            new AandC("Clobber"),
			            new AandC("Geyser"),
		            };
                    break;

                case "Tiny Blue Carp":
                    /* Abilities: 
                     * Slot 1: Surge            | Psychic Blast
                     * Slot 2: Healing Stream   | Wild Magic
                     * Slot 3: Pump             | Mana Surge
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Surge"),
			            new AandC("Psychic Blast"),
			            new AandC("Healing Stream"),
			            new AandC("Wild Magic"),
			            new AandC("Pump"),
			            new AandC("Mana Surge"),
		            };
                    break;

                case "Tiny Green Carp":
                    /* Abilities:
                     * Slot 1: Water Jet        | Surge
                     * Slot 2: Cleansing Rain   | Healing Stream
                     * Slot 3: Whirlpool        | Invisibility
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Water Jet"),
			            new AandC("Surge"),
			            new AandC("Cleansing Rain"),
			            new AandC("Healing Stream"),
			            new AandC("Whirlpool"),
			            new AandC("Invisibility"),
		            };
                    break;

                case "Tiny Red Carp":
                    /* Abilities:
                     * Slot 1: Water Jet        | Poison Spit
                     * Slot 2: Cleansing Rain   | Healing Stream
                     * Slot 3: Whirlpool        | Spiked Skin
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Water Jet"),
			            new AandC("Poison Spit"),
			            new AandC("Cleansing Rain"),
			            new AandC("Healing Stream"),
			            new AandC("Whirlpool"),
			            new AandC("Spiked Skin"),
		            };
                    break;

                case "Tiny White Carp":
                    /* Abilities:
                     * Slot 1: Water Jet        | Surge
                     * Slot 2: Cleansing Rain   | Healing Wave
                     * Slot 3: Dive             | Healing Stream
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Healing Wave",   () => hp < 0.7 ),
			            new AandC("Dive"),
			            new AandC("Water Jet"),
			            new AandC("Surge"),
			            new AandC("Cleansing Rain"),
			            new AandC("Healing Stream"),
		            };
                    break;

                case "Wanderer's Festival Hatchling":
                    /* Abilities: 
                     * Slot 1: Bite         | Grasp
                     * Slot 2: Shell Shield | Perk Up
                     * Slot 3: Pump         | Cleansing Rain
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Shell Shield",   () => ! buff("Shell Shield")),
			            new AandC("Bite"),
			            new AandC("Grasp"),
			            new AandC("Perk Up"),
			            new AandC("Pump"),
			            new AandC("Cleansing Rain"),
		            };
                    break;

                case "Zangar Crawler":
                    /* Abilities: 
                     * Slot 1: Rip              | Claw
                     * Slot 2: Spiny Carapace   | Shell Shield
                     * Slot 3: Dive             | Blood in the Water
                     */
                    aquatic_abilities = new List<AandC>()
		            {
			            new AandC("Devour", 			() => hpEnemy < 0.20 ),
			            new AandC("Blood in the Water", () => debuff("Bleeding")),
			            new AandC("Rip",                () => ! debuff("Bleeding")),
			            new AandC("Spiny Carapace"),
			            new AandC("Shell Shield",       () => hp < hpEnemy && ! buff("Shell Shield" )),
			            new AandC("Rip"),
			            new AandC("Claw"),
		            };
                    break;

                default:
                    /////////////////////////
                    // Unknown Aquatic Pet //
                    /////////////////////////
                    Logger.Alert("Unknown aquatic pet: " + petName);
                    aquatic_abilities = null;
                    break;
            }

            return aquatic_abilities;
        }
    }
}