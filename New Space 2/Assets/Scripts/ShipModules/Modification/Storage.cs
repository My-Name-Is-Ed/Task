using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Хранилище
    public class Storage : BaseModule
    {
        private Dictionary<int, int> _limit = new Dictionary<int, int>();

        public Storage()
        {
            Type = TypeModule.Storage;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 50, Strength = 10} },
                { 2, new MainСharacteristicModule() { Price = 65, Strength = 15} },
                { 3, new MainСharacteristicModule() { Price = 85, Strength = 20} },
            };

            _limit = new Dictionary<int, int>()
            {
                { 1, 2000 },
                { 2, 3000 },
                { 3, 4000 },
            };

            CantBeNear = new List<TypeModule>()
            {
                TypeModule.CommandCenter,
                TypeModule.Battery,
                
            };
        }

        public int Limit => _limit[Lvl];
    }
}
