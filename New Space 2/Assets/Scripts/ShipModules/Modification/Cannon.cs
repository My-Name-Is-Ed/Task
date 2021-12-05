using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Пушка
    public class Cannon : BaseModule
    {
        private Dictionary<int, int> _damage = new Dictionary<int, int>();

        public Cannon()
        {
            Type = TypeModule.Cannon;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 150, Strength = -5} },
                { 2, new MainСharacteristicModule() { Price = 270, Strength = -3} },
                { 3, new MainСharacteristicModule() { Price = 486, Strength = -1} },
            };

            _damage = new Dictionary<int, int>()
            {
                { 1, 50 },
                { 2, 60 },
                { 3, 75 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.CommandCenter,
                TypeModule.Engine,
                TypeModule.Collector,
                TypeModule.Converter,
                TypeModule.Generator,
            };
        }
        public int Damage => _damage[Lvl];
        public int ConsShot = 5;
    }
}
