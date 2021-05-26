using EnvCalc.BusinessObjects.Enums;
using Microsoft.VisualBasic.FileIO;

namespace EnvCalc.Tools
{
    public class AppSettings
    {
        public static string Loggerpfad { get; set; } = SpecialDirectories.MyDocuments + @"\EnvCalc\logs.log";
        public static string AppDataPfad { get; } = SpecialDirectories.MyDocuments + @"\EnvCalc";
        public static Betriebsmodus Betriebsmodus { get; set; }
    }
}