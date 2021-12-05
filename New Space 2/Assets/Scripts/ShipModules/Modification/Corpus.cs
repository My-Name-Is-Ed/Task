using System.Collections.Generic;
using Test.ShipModules.Abstraction;
using Test.ShipModules.Сharacteristics;

namespace Test.ShipModules
{
    // Корпус
    public class Corpus : BaseModule
    {
        public Corpus()
        {
            Type = TypeModule.Corpus;

            _characteristics = new Dictionary<int, MainСharacteristicModule>()
            {
                { 1, new MainСharacteristicModule() { Price = 100, Strength = 100} },
                { 2, new MainСharacteristicModule() { Price = 250, Strength = 200} },
                { 3, new MainСharacteristicModule() { Price = 625, Strength = 300} },
            };
        }
    }
}
