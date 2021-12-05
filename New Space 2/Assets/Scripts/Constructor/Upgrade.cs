using UnityEngine;
using Test.ShipModules.Abstraction;
using Test;

public class Upgrade : MonoBehaviour
{
    public void LvlUp()
    {
        var Modul = transform.Find("GameObject").GetChild(0).GetComponent<BaseModule>();
        if (Modul.Lvl < 3)
        {
            int priceUpdate = Modul.LvlUpgradePrice;


            if (priceUpdate < ServiceResurs.Money)
            {
                ServiceResurs.Money -= priceUpdate;
                transform.Find("GameObject").GetChild(0).GetComponent<BaseModule>().Lvl++;
                Ship.Refresh(Modul);
                transform.parent.GetComponent<Stats>().RefreshStats();
            }
            else
            {
                transform.GetComponent<ConstructorBlock>().Error();
            }
        }
        else
        {
            transform.GetComponent<ConstructorBlock>().Error();
        }
    }

}
