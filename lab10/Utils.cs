using System;

namespace Lab10
{
    internal class Utils
    {
        private static Random _random = new();
        private static string[] _names = {
            "Radiator",
            "Alternator",
            "Battery",
            "Starter",
            "Muffler",
            "Carburetor",
            "Sparkplug",
            "Thermostat",
            "Sensor",
            "Solenoid",
            "Shockabsorber",
            "Radiatorcap",
            "Transmission",
            "Clutch",
            "Flywheel",
            "Bearing",
            "Injector",
            "Manifold",
            "Distributor",
            "Camshaft"
        };
        public static string GetRandomPartName()
        {
            return _names[_random.Next(_names.Length)];
        }
        public static int GetRandomNumber(int max) { 
            return _random.Next(max);
        }
    }
}
