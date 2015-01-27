using Styx.WoWInternals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Prosto_Pets
{
    public static class BattleLogParser
    {
        private static string _locale = Lua.GetReturnVal<string>("return GetLocale()", 0);

        // Parses the current battle round from a log event as there
        // is no other way to get it from the game
        public static void LuaMessage(object sender, LuaEventArgs args)
        {
            string msg = args.Args[0].ToString();
            string regex = "";

            switch(_locale) {
                case "frFR":
                case "esES":
                case "esMX":
                case "itIT":
                case "koKR":
                case "ptBR":
                case "ruRU":
                case "zhCN":
                case "zhTW":
                    break;

                case "deDE":
                    regex = @"Runde\s(\d*)";
                    break;

                case "enGB":
                case "enUS":
                default:
                    regex = @"Round\s(\d*)";
                    break;
            }

            if(regex == "")
                return;

            Match match = Regex.Match(msg, @"Round\s(\d*)");

            if (match.Success)
            {
                string roundStr = match.Groups[1].Value;
                int round = Convert.ToInt32(roundStr);
                Battle.SetRoundFromLog(round);
            }
        }
    }
}
