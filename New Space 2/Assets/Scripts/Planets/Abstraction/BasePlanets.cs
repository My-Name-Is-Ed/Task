using Test.Planets.Abstraction;
using UnityEngine;

public abstract class BasePlanets : MonoBehaviour
{
    public TypePlanet Type { get; protected set; }
    public void BuildPosition(Vector3 pos, GameObject planet)
    {
        GridMap.grid[(int)pos.x, (int)pos.z] = transform.gameObject;

        planet.GetComponent<LineRenderer>()
            .SetPositions(new Vector3[]
          { new Vector3(pos.x, 0.3f, pos.z),
            new Vector3( pos.x+1, 0.3f, pos.z),
            new Vector3( pos.x+1, 0.3f, pos.z+1),
            new Vector3( pos.x, 0.3f, pos.z+1)});
    }
}
