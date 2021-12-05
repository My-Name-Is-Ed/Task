using UnityEngine;

public class ConstructorGrid : MonoBehaviour
{
    public GameObject block;
    public static GameObject[,] constructorGrid;
    private void Awake()
    {
        constructorGrid = new GameObject[11, 11];
        var startPosition = new Vector3(0, 0, 0);
        var iPaddingZ = 0f;
        var jPaddingX = 0f;
        for (int i = 0; i < constructorGrid.GetLength(0); i++)
        {
            for (int j = 0; j < constructorGrid.GetLength(1); j++)
            {
                var realPosition = new Vector3(startPosition.x + jPaddingX, 0f, startPosition.z + iPaddingZ);
                var realBlock = Instantiate(block, realPosition, Quaternion.identity, transform);
                var constBlock = realBlock.GetComponent<ConstructorBlock>();
                constBlock.GridPos = new Vector2Int(i, j);
                constructorGrid[i, j] = realBlock;
                iPaddingZ += 1f;
            }
            iPaddingZ = 0f;
            jPaddingX += 1f;
        }
    }
}

