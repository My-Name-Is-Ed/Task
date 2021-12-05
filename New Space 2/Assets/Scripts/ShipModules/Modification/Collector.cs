using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Сборщик
    public class Collector : BaseModule
    {
        private Dictionary<int, int> _collect = new Dictionary<int, int>();

        public Collector()
        {
            Type = TypeModule.Collector;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 75, Strength = 10} },
                { 2, new MainСharacteristicModule() { Price = 131, Strength = 12} },
                { 3, new MainСharacteristicModule() { Price = 230, Strength = 15} },
            };

            _collect = new Dictionary<int, int>()
            {
                { 1, 20 },
                { 2, 30 },
                { 3, 40 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.Engine,
                TypeModule.Cannon,
            };
        }

        public int Collect => _collect[Lvl];
        public int ConsRaid = 1;
    }
}
