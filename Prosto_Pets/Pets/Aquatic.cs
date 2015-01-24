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
                    /* Changelog:
                     * 2015-01-23: Revised Pump Mechanic
                     * 2015-01-22: Removed Soothe (for now). Enemy is very likely to not sleep due to damage - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet    | Poison Spit
                     * Slot 2: Healing Wave | Cleansing Rain
                     * Slot 3: Soothe       | Pump
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Wave",   () => hp < 0.7 ),   
                        new AandC("Cleansing Rain", () => hp < 0.9 ),   
                        new AandC("Pump",           () => buff("Pumped Up") && strong("Pump")),  
                        new AandC("Poison Spit",    () => buff("Pumped Up") && strong("Poison Spit")),  
                        new AandC("Pump",           () => ! buff("Pumped Up") && hpEnemy > 0.4),  
                        new AandC("Poison Spit"),
                        new AandC("Water Jet"), 
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
                    /* Changelog:
                     * 2015-01-22: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Healing Wave | Cleansing Rain
                     * Slot 3: Frog Kiss    | Swarm of Flies
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Wave",   () => hp < 0.7),
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain") || hp < 0.9),
                        new AandC("Swarm of Flies", () => ! debuff("Swarm of Flies")),
                        new AandC("Tongue Lash",    () => speed > speedEnemy || strong("Tongue Lash")),
                        new AandC("Frog Kiss",      () => ! enemyIsResilient),    
                        new AandC("Frog Kiss",      () => myPetHasAbility("Tongue Lash") && weak("Tongue Lash")),
                        new AandC("Water Jet"),
                        new AandC("Tongue Lash"),
                    };
                    break;

                case "Chuck":
                case "Muckbreath":
                case "Snarly":
                case "Toothy":
                    /* Changelog:
                     * 2015-01-22: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Rip      | Consume
                     * Slot 2: Surge    | Water Jet
                     * Slot 3: Devour   | Blood in the Water
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Devour",             () => hpEnemy < 0.2 || (strong("Devour") || hp < 0.3)),  
                        new AandC("Rip",                () => ! enemyIsBleeding), 
                        new AandC("Consume",            () => hp < 0.8),
                        new AandC("Blood in the Water", () => enemyIsBleeding || myPetIsLucky),
                        new AandC("Surge",              () => myPetHasAbility("Consume") && (weak("Consume") || strong("Surge"))),
                        new AandC("Surge",              () => myPetHasAbility("Rip") && (weak("Rip") || strong("Surge"))),
                        new AandC("Water Jet",          () => myPetHasAbility("Consume") && (weak("Consume") || strong("Water Jet"))),
                        new AandC("Water Jet",          () => myPetHasAbility("Rip") && (weak("Rip") || strong("Water Jet"))),
                        new AandC("Consume"),
                        new AandC("Rip"),
                    };
                    break;

                case "Darkmoon Turtle":
                case "Softshell Snapling":
                case "Speedy":
                case "Spiny Terrapin":
                case "Turquoise Turtle":
                    /* Changelog:
                     * 2015-01-22: Shell Shield now has a higher priority - Studio60
                     *             Powerball has been added into the rotation - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Grasp
                     * Slot 2: Shell Shield | Healing Wave
                     * Slot 3: Headbutt     | Powerball
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Wave",   () => hp < 0.7),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield")),
                        new AandC("Headbutt"),
                        new AandC("Powerball",      () => myPetHasAbility("Bite") && weak("Bite")),
                        new AandC("Powerball",      () => myPetHasAbility("Grasp") && weak("Grasp")),
                        new AandC("Powerball",      () => strong("Powerball")),
                        new AandC("Powerball",      () => ! weak("Powerball") && speed < speedEnemy),
                        new AandC("Bite"),
                        new AandC("Grasp"),
                    };
                    break;

                case "Emerald Turtle":
                    /* Changelog:
                     * 2015-01-22: Powerball has been added into the rotation - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Emerald Bite | Grasp
                     * Slot 2: Shell Shield | Healing Wave
                     * Slot 3: Headbutt     | Powerball
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Wave",   () => hp < 0.7 ),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield") ),
                        new AandC("Headbutt"),
                        new AandC("Powerball",      () => myPetHasAbility("Emerald Bite") && weak("Emerald Bite")),
                        new AandC("Powerball",      () => myPetHasAbility("Grasp") && weak("Grasp")),
                        new AandC("Powerball",      () => strong("Powerball")),
                        new AandC("Powerball",      () => ! weak("Powerball") && speed < speedEnemy),
                        new AandC("Emerald Bite"),
                        new AandC("Grasp"),
                    };
                    break;

                case "Emperor Crab":
                case "Shore Crab":
                case "Shore Crawler":
                case "Spirebound Crab":
                case "Strand Crab":
                case "Strand Crawler":
                    /* Changelog:
                     * 2015-01-22: Renewing Mists is no longer recast while it is still up - Studio60
                     *             Whirlpool has been added into the rotation - Studio60
                     *             Shell Shield mechanic changed to most uptime without wasting turns - Studio60
                     *             
                     * Abilities:
                     * Slot 1: Snap             | Surge
                     * Slot 2: Renewing Mists   | Healing Wave
                     * Slot 3: Shell Shield     | Whirlpool
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Renewing Mists", () => ! buff("Renewing Mists")),
                        new AandC("Healing Wave",   () => hp < 0.7),
                        new AandC("Shell Shield",   () => speed <= speedEnemy && buffLeft("Shell Shield") < 2),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield")),
                        new AandC("Whirlpool",      () => ! debuff("Whirlpool") && hpEnemy > 0.5),
                        new AandC("Snap"),
                        new AandC("Surge"),
                    };
                    break;

                case "Fishy":
                case "Tiny Goldfish":
                    /* Changelog:
                     * 2015-01-22: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet        | Surge
                     * Slot 2: Cleansing Rain   | Healing Wave
                     * Slot 3: Whirlpool        | Pump
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Cleansing Rain",     () => ! weather("Cleansing Rain") || hp < 0.8),
                        new AandC("Healing Wave",       () => hp < 0.7 ),
                        new AandC("Whirlpool",          () => ! debuff("Whirlpool") && hpEnemy > 0.5),
                        new AandC("Pump",               () => buff("Pumped Up") || hpEnemy > 0.4),
                        new AandC("Water Jet"),
                        new AandC("Surge"),
                    };
                    break;

                case "Frostshell Pincher":
                case "Ironclaw Scuttler":
                case "Kelp Scuttler":
                    /* Changelog:
                     * 2015-01-22: Double Spiny Carapace is now used for retaliation on huge attacks - Studio60
                     *             Spiny Carapace/Shell Shield are now being kept active without wasting turns - Studio60
                     *             Blood in the Water is now used when hit buff is active - Studio60
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
                        new AandC("Spiny Carapace",     () => shouldIHide && speed >= speedEnemy),
                        new AandC("Rip",                () => ! debuff("Bleeding")),
                        new AandC("Spiny Carapace",     () => ! buff("Spiny Carapace")),
                        new AandC("Spiny Carapace",     () => buffLeft("Spiny Carapace") == 1 && speed <= speedEnemy),
                        new AandC("Shell Shield",       () => ! buff("Shell Shield")),
                        new AandC("Shell Shield",       () => buffLeft("Shell Shield") == 1 && speed <= speedEnemy),
                        new AandC("Blood in the Water", () => myPetIsLucky || enemyIsBleeding),
                        new AandC("Rip"),
                        new AandC("Claw"),
                    };
                    break;

                case "Gahz'rooki":
                    /* Changelog:
                     * 2015-01-23: Swallow You Whole is prioritized if it has a type advantage - Studio60
                     * 2015-01-22: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite         | Tail Slap
                     * Slot 2: Devour       | Swallow You Whole
                     * Slot 3: Whirlpool    | Geyser
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Devour",             () => hpEnemy < 0.2 || (strong("Devour") && hpEnemy < 0.3)),
                        new AandC("Swallow You Whole",  () => hpEnemy < 0.25),
                        new AandC("Whirlpool",          () => ! debuff("Whirpool") && hpEnemy > 0.5),
                        new AandC("Geyser",             () => ! debuff("Geyser") && hpEnemy > 0.55),
                        new AandC("Swallow You Whole",  () => myPetHasAbility("Bite") && weak("Bite")),
                        new AandC("Swallow You Whole",  () => strong("Swallow You Whole")),
                        new AandC("Bite"),
                        new AandC("Tail Slap"),
                    };
                    break;

                case "Golden Civet":
                case "Golden Civet Kitten":
                case "Kuitan Mongoose":
                case "Mongoose":
                case "Mongoose Pup":
                case "Sifang Otter":
                case "Sifang Otter Pup":
                    /* Changelog:
                     * 2015-01-22: viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Bite     | Gnaw
                     * Slot 2: Screech  | Survival
                     * Slot 3: Surge    | Dive
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Dive",       () => shouldIHide && speed >= speedEnemy),
                        new AandC("Survival",   () => hp < 0.3 ),
                        new AandC("Screech",    () => ! debuff("Speed Reduction") && speed <= speedEnemy),
                        new AandC("Surge",      () => strong("Surge") || weak("Bite")),
                        new AandC("Bite"),
                        new AandC("Gnaw"),
                    };
                    break;

                case "Gulp Froglet":
                    /* Changelog:
                     * 2015-01-23: Mudslide is used earlier, if water attacks are weak or critter attacks are strong - Studio60
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
                     * TODO: Mudslide needs to check if more than one enemy team pet is alive
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Mudslide",           () => ! weather("Mudslide")),
                        new AandC("Mudslide",           () => weak("Water Jet") || strong("Mudslide")),
                        new AandC("Toxic Skin",         () => ! buff("Toxic Skin")),
                        new AandC("Toxic Skin",         () => buffLeft("Toxic Skin") == 1 && speed <= speedEnemy),
                        new AandC("Swarm",              () => ! debuff("Shattered Defenses")),
                        new AandC("Water Jet"),
                        new AandC("Frog Kiss"),
                        new AandC("Corpse Explosion"),
                    };
                    break;

                case "Hydraling":
                    /* Changelog:
                     * 2015-22-01: Shell Armor priority raised - Studio60
                     *             Deep Bite typo corrected (was Deep Byte) - Studio60
                     *             Whirlpool use restricted to enemies with more than 50% health - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Deep Bite        | Tail Slap
                     * Slot 2: Call Lightning   | Swallow You Whole
                     * Slot 3: Shell Armor      | Whirlpool
                     *
                     * TODO: Call Lightning is not always beneficial, only if mech's on our side
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Shell Armor",        () => ! buff("Shell Armor")),
                        new AandC("Swallow You Whole",  () => hpEnemy < 0.25 ),
                        new AandC("Whirlpool",          () => ! debuff("Whirlpool") && hpEnemy > 0.5),
                        new AandC("Call Lightning",     () => ! weather("Lightning Storm")),
                        new AandC("Deep Bite"),
                        new AandC("Tail Slap"),
                    };
                    break;

                case "Horny Toad":
                    /* Changelog:
                     * 2015-01-22: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Healing Wave | Cleansing Rain
                     * Slot 3: Frog Kiss    | Swarm of Flies
                     * 
                     * TODO: Frog Kiss should be used primarily if Tongue Lash is selected and weak
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Wave",       () => hp < 0.7 ),
                        new AandC("Swarm of Flies",     () => ! debuff("Swarm of Flies")),
                        new AandC("Cleansing Rain",     () => ! weather("Cleansing Rain") || hp < 0.9),
                        new AandC("Frog Kiss",          () => ! enemyIsResilient),
                        new AandC("Water Jet"),
                        new AandC("Tongue Lash"),
                    };
                    break;

                case "Land Shark":
                    /* Changelog:
                     * 2015-01-22: Blood in the Water is now also cast with +hit effects - Studio60
                     * 2015-01-20: Blood in the Water is now checking for all bleed effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet            | Tail Slap
                     * Slot 2: Tidal Wave           | Focus
                     * Slot 3: Blood in the Water   | Swallow You Whole
                     *
                     * TODO: Tidal Wave should check for enemy/own objects
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Swallow You Whole",  () => hpEnemy < 0.25),
                        new AandC("Tidal Wave",         () => debuff("Decoy") || debuff("Turret")),
                        new AandC("Focus",              () => ! buff("Focused")),
                        new AandC("Blood in the Water", () => enemyIsBleeding || myPetIsLucky),
                        new AandC("Water Jet"),
                        new AandC("Tail Slap"),
                    };
                    break;

                case "Leviathan Hatchling":
                    /* Changes:
                     * 2015-01-23: Toxic Skin is now being kept active
                     * 2015-01-18: Initial tactic by Studio60 for new pet coming in patch 6.1 
                     *
                     * Abilities:
                     * Slot 1: Tail Slap    | Water Jet
                     * Slot 2: Toxic Skin   | Poison Spit
                     * Slot 3: Whirlpool    | Primal Cry
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Toxic Skin",     () => ! buff("Toxic Skin")),
                        new AandC("Toxic Skin",     () => buffLeft("Toxic Skin") == 1 && speed <= speedEnemy),
                        new AandC("Poison Spit",    () => ! debuff("Poisoned")),
                        new AandC("Whirlpool",      () => hpEnemy > 0.4),
                        new AandC("Primal Cry",     () => ! debuff("Speed Reduction")),
                        new AandC("Tail Slap"), // Slot 1
                        new AandC("Water Jet"), // Slot 1
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
                        new AandC("Wish",           () => hp < 0.5),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield")),
                        new AandC("Renewing Mists", () => ! buff("Renewing Mists")),
                        new AandC("Whirlpool",      () => ! debuff("Whirlpool") && hpEnemy > 0.5),
                        new AandC("Snap"),
                        new AandC("Surge"),
                    };
                    break;

                case "Moonshell Crab":
                    /* Changelog:
                     * 2015-01-23: Amplify Magic is no longer cast too soon - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Arcane Slash     | Water Jet
                     * Slot 2: Shell Shield     | Amplify Magic
                     * Slot 3: Renewing Mists   | Moon Tears
                     * 
                     * TODO: Moon Tears: Detect state of team / enemy team pets
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Arcane Slash",   () => hpEnemy < 0.2 ),
                        new AandC("Moon Tears",     () => ! weather("Moonlight")),
                        new AandC("Renewing Mists", () => hp < 0.7 && ! buff("Renewing Mists")  ),
                        new AandC("Amplify Magic",  () => hp > 0.4 && ! buff("Amplify Magic")),
                        new AandC("Shell Shield",   () => hp < hpEnemy && ! buff("Shell Shield" )),
                        new AandC("Arcane Slash"),
                        new AandC("Water Jet"),
                    };
                    break;

                case "Mr. Chilly":
                case "Pengu":
                case "Tundra Penguin":
                    /* 2015-01-23: Ice Lance is cast when it has a type advantage over base attacks and if frost spit is not selected or the enemy is chilled (oh boy!) - Studio60
                     *             Belly Slide is now only cast during Blizzard or with +hit
                     * Abilities:
                     * Slot 1: Peck         | Surge
                     * Slot 2: Frost Spit   | Slippery Ice
                     * Slot 3: Ice Lance    | Belly Slide
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Slippery Ice",   () => ! debuff("Slippery Ice")),
                        new AandC("Slippery Ice",   () => debuffLeft("Slippery Ice") == 1 && speed <= speedEnemy),
                        new AandC("Ice Lance",      () => (myPetHasAbility("Peck") && (weak("Peck") || strong("Ice Lance")) && (! myPetHasAbility("Frost Spit") || enemyIsChilled))),
                        new AandC("Ice Lance",      () => (myPetHasAbility("Surge") && (weak("Surge") || strong("Ice Lance")) && (! myPetHasAbility("Frost Spit") || enemyIsChilled))),
                        new AandC("Frost Spit",     () => (myPetHasAbility("Peck") && (weak("Peck") || strong("Frost Spit")))),
                        new AandC("Frost Spit",     () => (myPetHasAbility("Surge") && (weak("Surge") || strong("Frost Spit")))),
                        new AandC("Belly Slide",    () => myPetIsLucky || weather("Blizzard")),
                        new AandC("Peck"),
                        new AandC("Surge"),
                    };
                    break;

                case "Mud Jumper":
                    /* Changelog:
                     * 2015-01-23: Tongue Lash is used before Pump with type advantage or higher speed - Studio60
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
                        new AandC("Tongue Lash",    () => strong("Tongue Lash") || speed > speedEnemy),
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
                        new AandC("Clobber",        () => ! enemyIsResilient),
                        new AandC("Water Jet"),
                        new AandC("Punch"),
                    };
                    break;

                case "Purple Puffer":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Water Jet    | Surge
                     * Slot 2: Spiked Skin  | Healing Wave
                     * Slot 3: Whirlpool    | Pump
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Spiked Skin",    () => ! shouldIHide && speed >= speedEnemy),
                        new AandC("Healing Wave",   () => hp < 0.7 ),
                        new AandC("Spiked Skin",    () => ! buff("Spiked Skin")),
                        new AandC("Spiked Skin",    () => buffLeft("Spiked Skin") == 1 && speed <= speedEnemy),
                        new AandC("Pump",           () => ! buff("Pumped Up")),
                        new AandC("Whirlpool",      () => ! debuff("Whirlpool") && hpEnemy > 0.5),
                        new AandC("Water Jet"),
                        new AandC("Surge"),
                    };
                    break;

                case "Sea Calf":
                    /* Changelog:
                     * 2015-01-23: Blood in the Water is now also used with +Hit buffs
                     * 2015-01-20: Bubble is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Dive is now also used to hide from huge attacks if both pets have equal speed - Studio60
                     *             Blood in the Water is now checking for all bleed effects - Studio60
                     * 2015-01-18: Initial tactic by Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Water Jet    | Surge
                     * Slot 2: Bubble       | Dive
                     * Slot 3: Feed         | Blood in the Water
                     */
                    aquatic_abilities = new List<AandC>() {
                        new AandC("Bubble",             () => shouldIHide && speed >= speedEnemy),
                        new AandC("Dive",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Feed",               () => hp < 0.7),
                        new AandC("Blood in the Water", () => myPetIsLucky || enemyIsBleeding),
                        new AandC("Water Jet"),
                        new AandC("Surge"),
                    };
                    break;

                case "Sea Pony":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Water Jet    | Tidal Wave
                     * Slot 2: Surge        | Cleansing Rain
                     * Slot 3: Whirlpool    | Pump
                     * 
                     * Tactic Information:
                     * Surge is stronger than Tidal Wave
                     * Pump is stronger than Tidal Wave if Surge is not selected
                     * 
                     * TODO: Tidal Wave needs to check for enemy objects
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain")),
                        new AandC("Tidal Wave",     () => debuff("Decoy") || debuff("Turret")),
                        new AandC("Whirlpool",      () => ! debuff("Whirlpool") && hpEnemy > 0.4),
                        new AandC("Pump",           () => buff("Pumped Up")),
                        new AandC("Pump",           () => hpEnemy > 0.4),
                        new AandC("Surge",          () => myPetHasAbility("Tidal Wave")),
                        new AandC("Pump",           () => myPetHasAbility("Tidal Wave") && ! myPetHasAbility("Surge")),
                        new AandC("Water Jet"),
                        new AandC("Tidal Wave"),
                    };
                    break;

                case "Spawn of G'nathus":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Swallow You Whole    | Jolt
                     * Slot 2: Dive                 | Lightning Shield
                     * Slot 3: Thunderbolt          | Paralyzing Shock
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Dive",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Swallow You Whole",  () => hpEnemy < 0.25),
                        new AandC("Lightning Shield",   () => ! buff("Lightning Shield")),
                        new AandC("Thunderbolt"),
                        new AandC("Paralyzing Shock"),
                        new AandC("Swallow You Whole"),
                        new AandC("Jolt"),
                    };
                    break;

                case "Spineclaw Crab":
                    /* Changelog:
                     * 2015-01-23: Blood in the Water is now also used with hit buffs - Studio60
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
                        new AandC("Blood in the Water", () => myPetIsLucky | enemyIsBleeding),
                        new AandC("Rip"),
                        new AandC("Triple Snap"),
                    };
                    break;

                case "Swamp Croaker":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet    | Tongue Lash
                     * Slot 2: Croak        | Swarm of Flies
                     * Slot 3: Frog Kiss    | Bubble
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Bubble",             () => shouldIHide && speed > speedEnemy),
                        new AandC("Swarm of Flies",     () => ! debuff("Swarm of Flies")),
                        new AandC("Croak",              () => ! debuff("Croak")),
                        new AandC("Croak",              () => debuffLeft("Croak") == 1 && speed <= speedEnemy),
                        new AandC("Frog Kiss",          () => ! enemyIsResilient),
                        new AandC("Frog Kiss",          () => myPetHasAbility("Tongue Lash") && (weak("Tongue Lash"))),
                        new AandC("Frog Kiss",          () => myPetHasAbility("Tongue Lash") && (strong("Frog Kiss"))),
                        new AandC("Water Jet"),
                        new AandC("Tongue Lash"),
                    };
                    break;

                case "Tideskipper":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Crush        | Grasp
                     * Slot 2: Tidal Wave   | Body Slam
                     * Slot 3: Clobber      | Geyser
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Tidal Wave",     () => debuff("Decoy") || debuff("Turret")),
                        new AandC("Clobber"),
                        new AandC("Geyser",         () => ! debuff("Geyser") && hpEnemy > 0.5),
                        new AandC("Body Slam",      () => hp > 0.4 && myPetHasAbility("Grasp") && (weak("Grasp") || strong("Body Slam"))),
                        new AandC("Crush"),
                        new AandC("Grasp"),
                    };
                    break;

                case "Tiny Blue Carp":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Surge            | Psychic Blast
                     * Slot 2: Healing Stream   | Wild Magic
                     * Slot 3: Pump             | Mana Surge
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Stream", () => hp < 0.8),
                        new AandC("Wild Magic",     () => ! debuff("Wild Magic")),
                        new AandC("Pump",           () => ! buff("Pumped Up")),
                        new AandC("Mana Surge",     () => weather("Arcane Winds")),
                        new AandC("Mana Surge",     () => myPetHasAbility("Surge") && (weak("Surge") || strong("Mana Surge")) && hp > 0.4),
                        new AandC("Psychic Blast",  () => weather("Arcane Winds")),
                        new AandC("Pump",           () => myPetHasAbility("Psychic Blast") && (weak("Psychic Blast") || strong("Pump"))),
                        new AandC("Surge"),
                        new AandC("Psychic Blast"),
                    };
                    break;

                case "Tiny Green Carp":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet        | Surge
                     * Slot 2: Cleansing Rain   | Healing Stream
                     * Slot 3: Whirlpool        | Invisibility
                     * 
                     * Tactic Information:
                     * Invisibility is currently not used as there is no solid use case
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Stream", () => hp < 0.8),
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain")),
                        new AandC("Whirlpool",      () => ! debuff("Whirlpool") && hpEnemy > 0.4),
                        new AandC("Water Jet"),
                        new AandC("Surge"),
                    };
                    break;

                case "Tiny Red Carp":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet        | Poison Spit
                     * Slot 2: Cleansing Rain   | Healing Stream
                     * Slot 3: Whirlpool        | Spiked Skin
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Healing Stream", () => hp < 0.8),
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain")),
                        new AandC("Spiked Skin",    () => ! buff("Spiked Skin")),
                        new AandC("Spiked Skin",    () => buffLeft("Spiked Skin") == 1 && speed < speedEnemy),
                        new AandC("Whirlpool",      () => ! debuff("Whirlpool") && hpEnemy > 0.4),
                        new AandC("Water Jet"),
                        new AandC("Poison Spit"),
                    };
                    break;

                case "Tiny White Carp":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities:
                     * Slot 1: Water Jet        | Surge
                     * Slot 2: Cleansing Rain   | Healing Wave
                     * Slot 3: Dive             | Healing Stream
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Dive",           () => shouldIHide && speed >= speedEnemy),
                        new AandC("Healing Wave",   () => hp < 0.6),
                        new AandC("Healing Stream", () => hp < 0.8),
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain")),
                        new AandC("Water Jet"),
                        new AandC("Surge"),
                    };
                    break;

                case "Wanderer's Festival Hatchling":
                    /* Changelog:
                     * 2015-01-23: Viable base tactic designed - Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Bite         | Grasp
                     * Slot 2: Shell Shield | Perk Up
                     * Slot 3: Pump         | Cleansing Rain
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Cleansing Rain", () => ! weather("Cleansing Rain")),
                        new AandC("Shell Shield",   () => ! buff("Shell Shield")),
                        new AandC("Shell Shield",   () => buffLeft("Shell Shield") == 1 && speed <= speedEnemy),
                        new AandC("Perk Up",        () => ! buff("Healthy") && hp < 0.7),
                        new AandC("Pump",           () => ! buff("Pumped Up")),
                        new AandC("Pump",           () => myPetHasAbility("Bite") && (weak("Bite") || strong("Pump")) && hpEnemy > 0.3),
                        new AandC("Bite"),
                        new AandC("Grasp"),
                    };
                    break;

                case "Zangar Crawler":
                    /* Changelog:
                     * 2015-01-23: Revised existing tactic - Studio60
                     * 
                     * Abilities: 
                     * Slot 1: Rip              | Claw
                     * Slot 2: Spiny Carapace   | Shell Shield
                     * Slot 3: Dive             | Blood in the Water
                     */
                    aquatic_abilities = new List<AandC>()
                    {
                        new AandC("Dive",               () => shouldIHide && speed >= speedEnemy),
                        new AandC("Spiny Carapace",     () => shouldIHide && speed >= speedEnemy),
                        new AandC("Shell Shield",       () => ! buff("Shell Shield" )),
                        new AandC("Shell Shield",       () => buffLeft("Shell Shield") == 1 && speed <= speedEnemy),
                        new AandC("Spiny Carapace",     () => ! buff("Spiny Carapace")),
                        new AandC("Spiny Carapace",     () => buffLeft("Spiny Carapace") == 1 && speed <= speedEnemy),
                        new AandC("Blood in the Water", () => myPetIsLucky || enemyIsBleeding),
                        new AandC("Rip",                () => ! debuff("Bleeding")),
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