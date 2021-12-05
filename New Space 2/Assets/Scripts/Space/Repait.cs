using UnityEngine.UI;
using UnityEngine;

public class Repait : MonoBehaviour
{
    public GameObject Interface;
    public void Repairer()
    {
        float Efficiency = ServiceResurs.RepeirerKPD;
        int concRepair = ServiceResurs.CountRepeirer;
        if (concRepair < ServiceResurs.Energy)
        {
            ServiceResurs.Energy -= concRepair;
            ServiceResurs.Strength += (int)Efficiency;
            if (ServiceResurs.Strength > ServiceResurs.LimitStrength)
            {
                ServiceResurs.Strength = ServiceResurs.LimitStrength;
            }
            Interface.GetComponent<RefreshPanels>().RealRefresh();
        }
    }
}
