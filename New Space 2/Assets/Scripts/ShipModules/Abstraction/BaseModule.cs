using System.Collections.Generic;
using Test.ShipModules.Сharacteristics;
using UnityEngine;

namespace Test.ShipModules.Abstraction
{
    public abstract class BaseModule : MonoBehaviour
    {
        protected Dictionary<int, MainСharacteristicModule> _characteristics;

        public MainСharacteristicModule Characteristic => _characteristics[Lvl];
        public int LvlUpgradePrice => _characteristics[Lvl+1].Price;

        public List<TypeModule> CantBeNear { get; set; } = new List<TypeModule>();

        public int Lvl = 1;

        public TypeModule Type { get; protected set; }

    }
}
