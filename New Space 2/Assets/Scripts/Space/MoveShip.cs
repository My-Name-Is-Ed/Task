using UnityEngine;

public class MoveShip : MonoBehaviour
{
    public static Vector3 _target;
    public float _speed = 10f;
    public GameObject Interface;

    private void Awake()
    {
        _target = new Vector3(20, 0, 20);
    }
    private void Update()
    {
        if (transform.position != _target && ServiceResurs.Energy>0)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, Time.deltaTime * _speed);
            ServiceResurs.Energy -=ServiceResurs.ÑonsumptionKM / 100f;
            ServiceResurs.Energy += ServiceResurs.GeneratorKPD / 100f;
            if (ServiceResurs.Energy < 0)
                ServiceResurs.Energy = 0;

            Interface.GetComponent<RefreshPanels>().RealRefresh();
        }
    }
}
