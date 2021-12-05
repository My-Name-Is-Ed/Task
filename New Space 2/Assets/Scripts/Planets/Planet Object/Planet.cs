using UnityEngine;
using Test.Planets.Abstraction;

public class Planet : BasePlanets
{
    public GameObject Ship;
    public Canvas Canvas;
    public Canvas Interface;
    public GameObject PrefabAsteroid;
    public Planet()
    {
        Type = TypePlanet.Planet;
    }
    private void Start()
    {
        BuildPosition(transform.position, transform.gameObject);
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

    public void Dig()
    {
        if (ServiceResurs.Energy > 0)
        {
            ServiceResurs.Ore += ServiceResurs.CollectRaid;
            ServiceResurs.Energy -= 1;
        }
        Interface.GetComponent<RefreshPanels>().RealRefresh();
        Battle(ref ServiceResurs.Damage, ref ServiceResurs.Strength);
    }
    private void Battle(ref int Damage, ref int Strength)
    {
        bool Turn = false;      //True - ход игрока, False - ход противника

        int DamageEnemy = Random.Range(2, 4) * 50;

        int StrengthEnemy = Mathf.RoundToInt(Strength * Random.Range(0.8f, 1.2f));    //Прочность противника относительно прочности игрока

        void DealShot(int Damage, ref int Strenght)
        {
            Strenght -= Damage;
            Turn = !Turn;
        }
        while (Strength > 0 && StrengthEnemy > 0)
        {
            if(Turn)
                DealShot(Damage, ref StrengthEnemy);
            else if(!Turn)
                DealShot(DamageEnemy, ref Strength);

            if (Turn)
                BattleLogger.LogPlayer(Damage, StrengthEnemy);
            else
                BattleLogger.LogEnemy(DamageEnemy, Strength);
        }
        if (Strength < 0)
            RefreshPanels.GameOver();
        else
            ServiceResurs.CountBattles++;
        if (ServiceResurs.CountBattles == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                CreateAsteroids();
            }
            ServiceResurs.CountBattles = 0;
        }
    }
    void CreateAsteroids()
    {
        int x = Random.Range(0, GridMap.GridSize.x);
        int y = Random.Range(0, GridMap.GridSize.y);
        var NewPlace = GridMap.grid[x, y];
        if (NewPlace == null)
        {
            GameObject Asteroid = Instantiate(PrefabAsteroid);
            Asteroid.GetComponent<MiniPlanet>().Ship = Ship;
            Asteroid.GetComponent<MiniPlanet>().Interface = Interface.gameObject;
            Asteroid.transform.position = new Vector3(x, -0.3f, y);
        }
    }
}
