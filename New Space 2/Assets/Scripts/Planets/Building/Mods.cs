using UnityEngine;

public class Mods : MonoBehaviour
{
    private void OnDrawGizmos()     //Only for Building Mode
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube((transform.position) + new Vector3(0,0.1f,0), new Vector3(1, 0.1f, 1));
    }
}
