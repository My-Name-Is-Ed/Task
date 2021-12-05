using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Генератор
    public class Generator : BaseModule
    {
        private Dictionary<int, int> _efficiency = new Dictionary<int, int>();

        public Generator()
        {
            Type = TypeModule.Generator;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 250, Strength = 5} },
                { 2, new MainСharacteristicModule() { Price = 388, Strength = 8} },
                { 3, new MainСharacteristicModule() { Price = 601, Strength = 10} },
            };

            _efficiency = new Dictionary<int, int>()
            {
                { 1, 2 },
                { 2, 4 },
                { 3, 6 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.Cannon,
            };
        }

        public int Efficiency => _efficiency[Lvl];
    }
}
