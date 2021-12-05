using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Slider slider;
    public Text DealText;

    public Canvas Interface;

    private float volume;
    private string DealMode;
    private string DealResurs;
    private float Price;
    private float fullPrice;
    private int miniVolume;
    private int maxVolume;

    private void Update()
    {
        volume = miniVolume + slider.value * maxVolume;
        fullPrice = Price * volume;
        DealText.text = $"{DealMode} {volume} {DealResurs} for {fullPrice}";
    }

    public void BuyMicro()
    {
        Price = 0.5f;
        DealMode = "Buy";
        DealResurs = "Energy";
        miniVolume = 1;
        maxVolume = 99;
    }
    public void BuyMini()
    {
        Price = 0.4f;
        DealMode = "Buy";
        DealResurs = "Energy";
        miniVolume = 100;
        maxVolume = 400;
    }
    public void BuyMid()
    {
        Price = 0.3f;
        DealMode = "Buy";
        DealResurs = "Energy";
        miniVolume = 500;
        maxVolume = 1000;
    }
    public void BuyOpt()
    {
        Price = 0.1f;
        DealMode = "Buy";
        DealResurs = "Energy";
        miniVolume = 1500;
        maxVolume = 1500;
    }
    public void SellMicro()
    {
        Price = 0.12f;
        DealMode = "Sell";
        DealResurs = "Ore";
        miniVolume = 1;
        maxVolume = 99;
    }
    public void SellMini()
    {
        Price = 0.1f;
        DealMode = "Sell";
        DealResurs = "Ore";
        miniVolume = 100;
        maxVolume = 400;
    }
    public void SellMid()
    {
        Price = 0.08f;
        DealMode = "Sell";
        DealResurs = "Ore";
        miniVolume = 500;
        maxVolume = 1000;
    }
    public void SellOpt()
    {
        Price = 0.06f;
        DealMode = "Sell";
        DealResurs = "Ore";
        miniVolume = 1500;
        maxVolume = 1500;
    }

    public void Deal()
    {
        if (DealMode == "Buy")
        {
            if (0 > ServiceResurs.Money - fullPrice)
            {
                Error();
            }
            else
            {
                ServiceResurs.Money -= fullPrice;
                ServiceResurs.Energy += volume;
                if (ServiceResurs.Energy > ServiceResurs.LimitEnergy)
                    ServiceResurs.Energy = ServiceResurs.LimitEnergy;
            }
            
        }
        else if (DealMode == "Sell")
        {
            if (0 > ServiceResurs.Ore - volume)
            {
                Error();
            }
            else
            {
                ServiceResurs.Money += fullPrice;
                ServiceResurs.Ore -= volume;
            }
        }
        Interface.GetComponent<RefreshPanels>().RealRefresh();
    }
    public void Error()
    { 
    
    }
}

