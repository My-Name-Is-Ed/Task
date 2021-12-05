using UnityEngine;
using UnityEngine.EventSystems;

public class GridMap : MonoBehaviour
{
    public static Vector2Int GridSize = new Vector2Int(40, 40);
    public static GameObject[,] grid;
    public Camera mainCamera;
    public GameObject Ship;


    private void Awake()
    {
        grid = new GameObject[GridSize.x, GridSize.y];
    }
    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);
                MoveShip._target = new Vector3(x + 0.5f, 0, y + 0.5f);
                Ship.transform.LookAt(MoveShip._target);
            }
        }
        
    }
}
