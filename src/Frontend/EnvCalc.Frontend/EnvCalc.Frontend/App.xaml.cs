using System;
using EnvCalc.Tools;
using System.Windows;
using Serilog.Events;

namespace EnvCalc.Frontend
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Logger.Instanz = new Logger();
            if (!Settings.CheckBetriebsmodus())
            {
                Logger.Instanz.WriteLog("Betriebsmodus konnte nicht ermittelt werden", LogEventLevel.Warning);
            }

            try
            {
                BackendDataAccess.ErzeugeInstanz();
                Logger.Instanz.WriteLog("DataAccess initialisiert und bereit für Anfragen", LogEventLevel.Information);
                base.OnStartup(e);
            }
            catch (Exception e1)
            {
                Logger.Instanz.WriteException("Fehler beim Start der Anwendung", LogEventLevel.Fatal, e1);
            }
        }
    }
}
