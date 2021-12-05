using System;
using System.Collections.Generic;
using System.Linq;
using Test.ShipModules;
using Test.ShipModules.Abstraction;

namespace Test
{
    public class Ship
    {
        //Список модулей корабля

        public static List<BaseModule> Modules { get; private set; } = new List<BaseModule>();  

        //Процес добавление модуля

        public static bool TryAddModule(BaseModule module)
        {
            switch (module.Type)
            {
                case TypeModule.CommandCenter:
                    return AddModule(module);

                case TypeModule.Corpus:
                    return TryAddCorpus(module);

                case TypeModule.Engine:
                    return TryAddEngine(module);

                case TypeModule.Battery:
                    return AddModule(module);

                case TypeModule.Storage:
                    return AddModule(module);

                case TypeModule.Cannon:
                    return AddModule(module);

                case TypeModule.Collector:
                    return AddModule(module);

                case TypeModule.Converter:
                    return AddModule(module);

                case TypeModule.Generator:
                    return AddModule(module);

                case TypeModule.Repairer:
                    return AddModule(module);

                default:
                    throw new ArgumentException(nameof(module.Type));
            }
        }
        public static void Refresh(BaseModule module)
        {
            ServiceResurs.LimitStrength = CalculateStrength();
            switch (module.Type)
            {
                case TypeModule.CommandCenter:
                    ServiceResurs.CountCommandCenter = CalculatedCount(module.Type);
                    ServiceResurs.LimitCorpus = CalculatedLimitCorpus();
                    return;

                case TypeModule.Corpus:
                    ServiceResurs.LimitEngine = CalculatedLimitEngine();
                    ServiceResurs.CountCorpus = CalculatedCount(module.Type);
                    return;

                case TypeModule.Engine:
                    ServiceResurs.СonsumptionBattle = CalculatedConsBattle();
                    ServiceResurs.СonsumptionKM = CalculatedConsKm();
                    ServiceResurs.CountEngine = CalculatedCount(module.Type);
                    return;

                case TypeModule.Battery:
                    ServiceResurs.LimitEnergy = CalculatedLimitEnergy();
                    ServiceResurs.CountBattery = CalculatedCount(module.Type);
                    return;

                case TypeModule.Storage:
                    ServiceResurs.LimitOre = CalculatedLimitOre();
                    ServiceResurs.CountStorage = CalculatedCount(module.Type);
                    return;

                case TypeModule.Cannon:
                    ServiceResurs.ConsumptionShot = CalculatedConsShot();
                    ServiceResurs.Damage = CalculatedDamage();
                    ServiceResurs.CountCannon = CalculatedCount(module.Type);
                    return;

                case TypeModule.Collector:
                    ServiceResurs.ConsumptionRaid = CalculatedConsRaid();
                    ServiceResurs.CollectRaid = CalculatedCollectRaid();
                    ServiceResurs.CountCollector = CalculatedCount(module.Type);
                    return;

                case TypeModule.Converter:
                    ServiceResurs.ConvertKPD = CalculatedConvertKPD();
                    ServiceResurs.CountConverter = CalculatedCount(module.Type);
                    return;

                case TypeModule.Generator:
                    ServiceResurs.GeneratorKPD = CalculatedGeneratorKPD();
                    ServiceResurs.CountGenerator = CalculatedCount(module.Type);
                    return;

                case TypeModule.Repairer:
                    ServiceResurs.RepeirerKPD = CalculatedRepairKPD();
                    ServiceResurs.CountRepeirer = CalculatedCount(module.Type);
                    return;
                default:
                    return;
            }
        }

        //Уникальные условия для каждого модуля

        private static bool TryAddCorpus(BaseModule module)
        {
            var countCorpus = Modules.Count(x => x.Type == TypeModule.Corpus);

            if (countCorpus >= ServiceResurs.LimitCorpus)
                return false;

            return AddModule(module);
        }
        private static bool TryAddEngine(BaseModule module)
        {
            var countCorpus = Modules.Count(x => x.Type == TypeModule.Engine);

            if (countCorpus >= ServiceResurs.LimitEngine)
                return false;

            return AddModule(module);
        }
        private static bool AddModule(BaseModule module)
        {
            if (module.Characteristic.Price < ServiceResurs.Money)  //Проверка на наличие необходимой для покупки суммы
            {
                ServiceResurs.Money -= module.Characteristic.Price;
                Modules.Add(module);
                Refresh(module);
                ServiceResurs.Strength += module.Characteristic.Strength;
                switch (module.Type)
                {
                    case TypeModule.CommandCenter:
                        return true;

                    case TypeModule.Corpus:
                        return true;

                    case TypeModule.Engine:
                        return true;

                    case TypeModule.Battery:
                        return true;

                    case TypeModule.Storage:
                        return true;

                    case TypeModule.Cannon:
                        return true;

                    case TypeModule.Collector:
                        return true;

                    case TypeModule.Converter:
                        return true;

                    case TypeModule.Generator:
                        return true;

                    case TypeModule.Repairer:
                        return true;

                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Расчет параметров корабля

        private static int CalculatedCount(TypeModule Type)
        {
            return Modules.Count(x => x.Type == Type);
        }   //Считает количество модулей одного типа
        private static int CalculateStrength()
        {
            return Modules.Sum(x => x.Characteristic.Strength);
        }   //Считает прочность корабля
        private static int CalculatedLimitCorpus()
        {
            int newLimit = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.CommandCenter)
                {
                    newLimit += modules.GetComponent<CommandCenter>().LimitCorpus;
                }
            }
            return newLimit;
        }   //Считает лимит корпусов
        private static int CalculatedLimitEngine()
        {
            return (Modules.Count(x => x.Type == TypeModule.Corpus)) / 2;   //1 двигатель на 2 корпуса
        }   //Считает лимит двигателей
        private static int CalculatedDamage()
        {
            int newDamage = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Cannon)
                {
                    newDamage += modules.GetComponent<Cannon>().Damage;
                }
            }
            return newDamage;
        }   //Считает урон за выстрел
        private static int CalculatedConsShot()
        {
            int ConsShot = 5;
            return CalculatedCount(TypeModule.Cannon) * ConsShot;
        }   //Считает расход энергии за выстрел
        private static int CalculatedConsBattle()
        {
            int ConsBattle = 5;
            int Count = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Engine)
                {
                    ConsBattle += modules.GetComponent<Engine>().ForBattle;
                    Count++;
                }
            }
            return ConsBattle / (Count * Count);
        }   //Cчитает расход энергии за бой
        private static int CalculatedConsKm()
        {
            int ConsKm = 0;
            int Count = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Engine)
                {
                    ConsKm += modules.GetComponent<Engine>().ForHundredKm;
                    Count++;
                }
            }
            return ConsKm / (Count * Count);
        }   //Считает расход энергии на 100 км
        private static int CalculatedLimitEnergy()
        {
            int newLimit = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Battery)
                {
                    newLimit += modules.GetComponent<Battery>().Limit;
                }
            }
            return newLimit;
        }   //Считает лимит на энергию
        private static int CalculatedLimitOre()
        {
            int newLimit = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Storage)
                {
                    newLimit += modules.GetComponent<Storage>().Limit;
                }
            }
            return newLimit;
        }   //Считает лимит на руду
        private static int CalculatedCollectRaid()
        {
            int newCollect = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Engine)
                {
                    newCollect += modules.GetComponent<Collector>().Collect;
                }
            }
            return newCollect;
        }   //Считает количество собраной руды за раз
        private static int CalculatedConsRaid()
        {
            int ConsRaid = 5;
            return ConsRaid * CalculatedCount(TypeModule.Collector);
        }   //Считает расход энергии на 1 сбор руды
        private static int CalculatedConvertKPD()
        {
            int ConsConvert = 0;
            int Count = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Converter)
                {
                    ConsConvert += modules.GetComponent<Converter>().Efficiency;
                    Count++;
                }
            }
            return ConsConvert / (Count * Count);
        }   //Считает КПД конвертера
        private static int CalculatedGeneratorKPD()
        {
            int ConsConvert = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Generator)
                {
                    ConsConvert += modules.GetComponent<Generator>().Efficiency;
                }
            }
            return ConsConvert;
        }   //Считает КПД генератора
        private static int CalculatedRepairKPD()
        {
            int newKPD = 0;
            foreach (BaseModule modules in Modules)
            {
                if (modules.Type == TypeModule.Repairer)
                {
                    newKPD += modules.GetComponent<Repairer>().Efficiency;
                }
            }
            return newKPD;
        }       //Считает КПД ремонтника
    }
}
