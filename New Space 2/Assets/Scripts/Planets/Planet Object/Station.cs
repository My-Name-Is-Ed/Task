using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : BasePlanets
{
    public GameObject Ship;
    public Canvas Canvas;

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
}
