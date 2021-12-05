using UnityEngine;
using Test.Planets.Abstraction;
using Test;
using UnityEngine.UI;

public class MiniPlanet : BasePlanets
{
    public GameObject Ship;
    public Canvas Canvas;
    public GameObject Interface;
    private int Reserve;
    public MiniPlanet()
    {
        Type = TypePlanet.Asteroid;
    }
    public void MiniDig()
    {
        if (ServiceResurs.Energy > 0)
        {
            if (Reserve < ServiceResurs.CollectRaid)
            {
                ServiceResurs.Ore += Reserve;
                ServiceResurs.Energy -= 1;
                Destroy();
            }
            else
            {
                Reserve -= ServiceResurs.CollectRaid;
                ServiceResurs.Ore += ServiceResurs.CollectRaid;
                ServiceResurs.Energy -= 1;
            }
        }
        Interface.GetComponent<RefreshPanels>().RealRefresh();

    }
    private void Start()
    {
        BuildPosition(transform.position, transform.gameObject);
        Reserve = Random.Range(100, 1000);
    }

    private void Update()
    {
        if (Ship.transform.position == (transform.position + new Vector3(0.5f, 0.3f, 0.5f)))
        {
            Canvas.transform.gameObject.SetActive(true);
        }
        else
        {
            Canvas.transform.gameObject.SetActive(false);
        }
    }
    private void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
