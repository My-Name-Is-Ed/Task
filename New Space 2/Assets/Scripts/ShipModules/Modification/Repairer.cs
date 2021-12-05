using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Ремонтник
    public class Repairer : BaseModule
    {
        private Dictionary<int, int> _efficiency = new Dictionary<int, int>();

        public Repairer()
        {
            Type = TypeModule.Repairer;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 350, Strength = 10} },
                { 2, new MainСharacteristicModule() { Price = 438, Strength = 15} },
                { 3, new MainСharacteristicModule() { Price = 547, Strength = 20} },
            };

            _efficiency = new Dictionary<int, int>()
            {
                { 1, 20 },
                { 2, 25 },
                { 3, 30 },
            };
        }

        public int Efficiency => _efficiency[Lvl];
        public int ConsRepair = 10;
    }
}
