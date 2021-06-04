﻿using EnvCalc.Tools;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            Logger.Entity = new Logger();
            if (!Settings.CheckBetriebsmodus())
            {
                Logger.Entity.WriteLog("Betriebsmodus konnte nicht ermittelt werden", LogEventLevel.Warning);
            }
            //if (!Settings.LadeEinstellungen())
            //{
            //    MessageBox.Show("Fehler beim Laden der Einstellungen. Prüfen Sie den Pfad..");
            //}

            BackendDataAccess.ErzeugeInstanz();
            Logger.Entity.WriteLog("DataAccess initialisiert und bereit für Anfragen", LogEventLevel.Information);

            base.OnStartup(e);
        }
    }
}
