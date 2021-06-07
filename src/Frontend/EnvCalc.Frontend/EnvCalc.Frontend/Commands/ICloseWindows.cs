using System;

namespace EnvCalc.Frontend.Commands
{
    public interface ICloseWindows
    {
        Action Close { get; set; }
        bool CanClose();
    }
}