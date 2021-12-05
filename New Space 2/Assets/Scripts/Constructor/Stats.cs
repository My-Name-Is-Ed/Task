using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text Money;
    public Text Energy;
    public Text Ore;
    public Text CountCorpus;
    public Text CountBattery;
    public Text CountCannon;
    public Text CountCollector;
    public Text CountConverter;
    public Text CountEngine;
    public Text CountGenerator;
    public Text CountRepeirer;
    public Text CountStorage;
    public Text Strenght;

    public void RefreshStats()
    {
        Money.text = $"{ServiceResurs.Money}";

        Energy.text = $"{ServiceResurs.Energy} / {ServiceResurs.LimitEnergy}";

        Ore.text = $"{ServiceResurs.Ore} / {ServiceResurs.LimitOre}";

        CountCorpus.text = $"{ServiceResurs.CountCorpus} / {ServiceResurs.LimitCorpus}";

        CountBattery.text = $"{ServiceResurs.CountBattery}";

        CountCannon.text = $"{ServiceResurs.CountCannon}";

        CountCollector.text = $"{ServiceResurs.CountCollector}";

        CountConverter.text = $"{ServiceResurs.CountConverter}";

        CountEngine.text = $"{ServiceResurs.CountEngine} / {ServiceResurs.LimitEngine}";

        CountGenerator.text = $"{ServiceResurs.CountGenerator}";

        CountRepeirer.text = $"{ServiceResurs.CountRepeirer}";

        CountStorage.text = $"{ServiceResurs.CountStorage}";

        Strenght.text = $"{ServiceResurs.LimitStrength}"; ;
}
}
