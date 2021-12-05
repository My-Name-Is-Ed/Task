using UnityEngine;
using UnityEngine.UI;
using Test.ShipModules.Abstraction;
using Test;

public class RefreshPanels : MonoBehaviour
{
    public Button ButtonConverter;
    public Button ButtonRepairer;

    public Text Money;
    public Text Energy;
    public Text Ore;

    public static GameObject GameOverPanel;

    public static void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void RealRefresh()
    {
        Refresh(Money, Energy, Ore);
    }
    void Start()
    {
        GameOverPanel = transform.Find("GameOverPanel").gameObject;
        bool ConverTrue = false;
        bool RepairerTrue = false;
        foreach (BaseModule modules in Ship.Modules)
        {
            
            if (modules.Type == TypeModule.Converter)
            {
                ConverTrue = true;
                
            }
            if (modules.Type == TypeModule.Repairer)
            {
                RepairerTrue = true;
            }
        }
        if (ConverTrue)
        {
            ButtonConverter.gameObject.SetActive(true);
        }
        else
        {
            ButtonConverter.gameObject.SetActive(false);
        }
        if (RepairerTrue)
        {
            ButtonRepairer.gameObject.SetActive(true);
        }
        else
        {
            ButtonRepairer.gameObject.SetActive(false);
        }
        Refresh(Money, Energy, Ore);
    }
    static void Refresh(Text money, Text energy, Text ore)
    {
        money.text = $"{ServiceResurs.Money}";
        energy.text = $"{ServiceResurs.Energy}";
        ore.text = $"{ServiceResurs.Ore}";

        if (ServiceResurs.Energy <= 0 && ServiceResurs.Ore <= 0)
        {
            GameOver();
        }
    }
    
}
