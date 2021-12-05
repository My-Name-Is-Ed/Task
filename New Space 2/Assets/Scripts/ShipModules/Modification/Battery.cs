using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Аккумулятор
    public class Battery : BaseModule
    {
        private Dictionary<int, int> _limit = new Dictionary<int, int>();

        public Battery()
        {
            Type = TypeModule.Battery;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 150, Strength = 10} },
                { 2, new MainСharacteristicModule() { Price = 300, Strength = 15} },
                { 3, new MainСharacteristicModule() { Price = 450, Strength = 20} },
            };

            _limit = new Dictionary<int, int>()
            {
                { 1, 1000 },
                { 2, 2000 },
                { 3, 3000 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.Storage,
            };
        }

        public int Limit => _limit[Lvl];
    }
}
