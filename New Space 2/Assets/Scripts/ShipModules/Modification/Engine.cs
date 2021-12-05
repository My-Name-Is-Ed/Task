using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Двигатель
    public class Engine : BaseModule
    {
        // Расход энергии
        private Dictionary<int, int> _forBattle = new Dictionary<int, int>();

        private Dictionary<int, int> _forHundredKm = new Dictionary<int, int>();

        public Engine()
        {
            Type = TypeModule.Engine;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 200, Strength = -10} },
                { 2, new MainСharacteristicModule() { Price = 300, Strength = -8} },
                { 3, new MainСharacteristicModule() { Price = 450, Strength = -5} },
            };

            _forBattle = new Dictionary<int, int>()
            {
                { 1, 10 },
                { 2, 8 },
                { 3, 6 },
            };

            _forHundredKm = new Dictionary<int, int>()
            {
                { 1, 50 },
                { 2, 48 },
                { 3, 45 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.Cannon,
                TypeModule.Converter,
                TypeModule.CommandCenter,
                TypeModule.Collector,
            };
        }

        public int ForBattle => _forBattle[Lvl];
        public int ForHundredKm => _forHundredKm[Lvl];
        public int ForThousandKm => ForHundredKm * 10;
    }
}
