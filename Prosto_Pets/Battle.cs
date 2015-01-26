using Styx.WoWInternals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prosto_Pets
{
    public static class Battle
    {
        private static int _round = 1;
        
        public static int Round { get { return _round; } }

        // the combat log message containing the round is displayed AFTER
        // all attacks have been selected. for prosto_pets this means 
        // that we need to increment it by one to select the correct move
        // for the next turn
        public static void SetRoundFromLog(int round)
        {
            _round = round + 1;
        }

        // round is set to one at the beginning and after each battle
        public static void LuaResetRound(object sender, LuaEventArgs args)
        {
            _round = 1;
        }
    }
}
