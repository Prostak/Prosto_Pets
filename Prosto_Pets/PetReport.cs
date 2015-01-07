using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Styx.Common.Helpers;
using Styx.CommonBot.Inventory;
using Styx.Helpers;
using Styx.Plugins;

using Styx.Common;
using Styx.WoWInternals;
using Styx.WoWInternals.WoWObjects;
using Styx;

using Styx.CommonBot;
using Styx.CommonBot.Profiles;
using Styx.CommonBot.POI;

//*************************************************

using Styx.WoWInternals.World;
using Styx.WoWInternals.Misc;

using Bots.BGBuddy.Helpers;

using Styx.CommonBot.Routines;
using Styx.Pathing;
using Styx.TreeSharp;
using Levelbot.Decorators.Death;
using Levelbot.Actions.Death;
using Bots.Grind;
using CommonBehaviors.Actions;
using System.Windows.Forms;
using NewMixedMode;

namespace Prosto_Pets
{
    public class PetReport : IPetReporter
    {

        private string _zone;
        private bool _started;

        const int success = 1;
        const int failure = 0;

        Styx.WoWPoint _reportedPoint;
        StreamWriter _petLog;

        Hashtable _petsSeen;

        public PetReport()
        {
            _petsSeen = new Hashtable();
            Clear();
        }
        
        void Clear()
        {
            _zone = "";
            _reportedPoint = WoWPoint.Zero;  // potential border multi-report problems, but preference is to close the file and clean the Hash then to try to remember everything
            _started = false;
            _petsSeen.Clear();
        }

        // creates an empty or loads the existing profile for the zone the pet is in
        public void Start()
        {
            if( _started )
            {
                Logger.Write("Report already started for the zone " + _zone);
                // new zone checked on addition
                return;
            }

            if (OpenReportToAppend(PlayerZone()) == success)
            {
                _zone = PlayerZone();
                _started = true;
            }

        }

        public static string PlayerZone()
        {
            string zoneName = string.IsNullOrEmpty(StyxWoW.Me.ZoneText)
            ? "noZone"
            : (StyxWoW.Me.CurrentMap.IsGarrison ? "Garrison" : StyxWoW.Me.ZoneText);
            return zoneName;
        }

        // writes the gathered profile to the disk: hotspots (and associated pets as comments)
        public void Stop() 
        {
            if (!_started) 
            {
                Logger.Alert("PetReport not started - nothing to stop");
                return;
            }
            Logger.Write("Closing the report for the zone " + _zone);
            _petLog.Close();
            Clear();
            _started = false;
        }

        public void CheckAndDoZoneReset()
        {
            if( _zone != PlayerZone() )
            {
                Logger.Write("Player changed the zone to " + PlayerZone() );
                Stop();
                Start();
            }
        }
    
        // checks if filename player is in the same area, if not performs Close - Start 
        // then checks if filename point is close to an existing hotspot, if not creates one and adds filename pet name there  
        public void AddBattle(string name)
        {
            if (!_started || !PluginSettings.Instance.RecordPets) return;
            CheckAndDoZoneReset();
            if( !_started)
            {
                Logger.Alert( " Some failure on Zone change" );
                return;
            }
            // battle is always where the player is
            if( _reportedPoint.Distance2DSqr( StyxWoW.Me.Location ) > 150*150 )
            {
                ReportPoint( StyxWoW.Me.Location );
            }
            ReportBattle( name );
        }

        // checks if filename player is in the same area, if not performs Close - Start 
        // then checks if filename pet id is already registered, if not creates one and adds filename pet name there  
        public void AddSeen(string id, string name, Styx.WoWPoint point)
        {
            if (!_started || !PluginSettings.Instance.RecordPets) return;
            CheckAndDoZoneReset();
            if( _petsSeen.ContainsKey( id ))
            {
                //Logger.WriteDebug( "pet " +name+ " already reported");
                return;
            }
            _petsSeen[id] = 1;
            Styx.WoWPoint pointToReport = point;
            //Styx.WoWPoint pointToReport = StyxWoW.Me.Location;   // TODO: config?
            if (_reportedPoint.Equals(WoWPoint.Zero) || _reportedPoint.Distance2DSqr(pointToReport) > 200 * 200)
            {
                ReportPoint( point );
            }
            ReportSeen( name );
        }

        private void ReportPoint( Styx.WoWPoint p )
        {
            _petLog.WriteLine( "<Hotspot X=\"" + p.X + "\" Y=\"" + p.Y + "\" Z=\"" + p.Z + "\"/>");
            _reportedPoint = p;
        }

        private void ReportBattle( string name )
        {
            _petLog.WriteLine( "<!--Battle Name=\"" + name + "\"-->");
        }

        private void ReportSeen( string name )
        {
            Logger.Write("Seeing new " + name);
            _petLog.WriteLine( "<!--Seen Name=\"" + name + "\"-->");
        }

        private int OpenReportToAppend(string zone)
        {
            string prostoProfilesDir = "Bots\\Prosto_Pets\\Pet_Reports";
            string sPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            sPath = Path.GetDirectoryName(sPath);  // Honorbuddy directory
            sPath = Path.Combine(sPath, prostoProfilesDir);

            if (!Directory.Exists(sPath))
            {
                Logger.Alert("Creating directory for generated profiles: " + sPath);
                Directory.CreateDirectory(sPath);
                if( !Directory.Exists(sPath)) 
                {
                    Logger.Alert("Failed to create the directory: " + sPath);
                    return failure;
                }
            }

            sPath = Path.Combine(sPath, zone + "_PetReport.xml");

            if (!File.Exists(sPath))
            {
                Logger.Write("Report " + sPath + " not found. To be created.");
            }
            else
            {
                Logger.Write("Report " + sPath + " found. To be appended.");
            }

            try
            {
                _petLog = File.AppendText( sPath );
                _petLog.AutoFlush = true;  // not very intensive output, but it is bad to loose filename record
            }
            catch( Exception e)
            {
                Logger.Alert( e.ToString() );
                return failure;
            }
            return success;
        }
    }
}
