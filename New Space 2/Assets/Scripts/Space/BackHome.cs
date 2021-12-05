using UnityEngine;

public class BackHome : MonoBehaviour
{
    public void BackStation()
    {
        MoveShip._target = transform.position + new Vector3(0.5f, 0.3f, 0.5f);

    }
}
