using System;
using System.IO;
using EnvCalc.BusinessObjects.Enums;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;

namespace EnvCalc.Tools
{
    public class Settings
    {
        public static AppSettings GeladeneEinstellungen { get; set; }
        private static readonly string Settingspfad = AppSettings.AppDataPfad + @"\settings.json";

        private static bool CheckSettingsVerfuegbar()
        {
            // Die Einstellungen sollten immer verfügbar sein
            if (!Directory.Exists(AppSettings.AppDataPfad))
            {
                Directory.CreateDirectory(AppSettings.AppDataPfad);
                File.WriteAllText(Settingspfad, "{}");
                return false;
            }

            if (!File.Exists(Settingspfad))
            {
                File.WriteAllText(Settingspfad, "{}");
                return false;
            }

            return true;
        }

        public static bool LadeEinstellungen()
        {
            try
            {
                if (!CheckSettingsVerfuegbar())
                {
                    return false;
                }

                var text = File.ReadAllText(Settingspfad);
                GeladeneEinstellungen = JsonConvert.DeserializeObject<AppSettings>(text);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool CheckBetriebsmodus()
        {
            if (Environment.CurrentDirectory.Contains("Debug"))
            {
                AppSettings.Betriebsmodus = Betriebsmodus.Debug;
                return true;
            }

            if (!Environment.CurrentDirectory.Contains("Debug"))
            {
                AppSettings.Betriebsmodus = Betriebsmodus.Produktiv;
                return true;
            }

            return false;
        }
    }
}