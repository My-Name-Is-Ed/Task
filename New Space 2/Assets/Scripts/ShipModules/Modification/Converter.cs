using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Конвертер
    public class Converter : BaseModule
    {
        private Dictionary<int, int> _efficiency = new Dictionary<int, int>();

        public Converter()
        {
            Type = TypeModule.Converter;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 200, Strength = -5} },
                { 2, new MainСharacteristicModule() { Price = 270, Strength = -3} },
                { 3, new MainСharacteristicModule() { Price = 365, Strength = 0} },
            };

            _efficiency = new Dictionary<int, int>()
            {
                { 1, 5 },
                { 2, 4 },
                { 3, 3 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.Engine,
                TypeModule.Cannon,
            };
        }

        public int Efficiency => _efficiency[Lvl];
    }
}
