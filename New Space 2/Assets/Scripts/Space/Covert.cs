using UnityEngine;
using UnityEngine.UI;

public class Covert : MonoBehaviour
{
    public GameObject Interface;
    public void Convert()
    {
        float Efficiency = ServiceResurs.ConvertKPD;
        if (Efficiency < ServiceResurs.Ore)
        {
            ServiceResurs.Ore -= Efficiency;
            ServiceResurs.Energy++;
            if (ServiceResurs.Energy > ServiceResurs.LimitEnergy)
            {
                ServiceResurs.Energy = ServiceResurs.LimitEnergy;
            }
            Interface.GetComponent<RefreshPanels>().RealRefresh();
        }
    }
}
