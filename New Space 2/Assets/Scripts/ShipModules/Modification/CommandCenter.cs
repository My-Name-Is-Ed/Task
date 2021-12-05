using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Командный центр
    public class CommandCenter : BaseModule
    {
        private Dictionary<int, int> _limitCorpuses = new Dictionary<int, int>();

        public CommandCenter()
        {
            Type = TypeModule.CommandCenter;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 100, Strength = 10} },
                { 2, new MainСharacteristicModule() { Price = 300, Strength = 20} },
                { 3, new MainСharacteristicModule() { Price = 900, Strength = 30} },
            };

            _limitCorpuses = new Dictionary<int, int>()
            {
                { 1, 4 },
                { 2, 8 },
                { 3, 12 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.Engine,
                TypeModule.Cannon,
                TypeModule.Storage,
            };
        }

        public int LimitCorpus => _limitCorpuses[Lvl];
    }
}
