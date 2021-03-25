using UnityEngine;

public class GridCreation : MonoBehaviour
{
    public Vector3Int gridSize;
    public Vector3 gridOrigin;
    public float gridScale;

    public GameObject platform;
    public Transform platformRef;
    public Transform morphBotsRef;

    public Node[,,] grid;

    private void Awake()
    {
        platformRef.transform.position = morphBotsRef.transform.position = gridOrigin;
        gridSize.y += 1;
        grid = new Node[gridSize.x, gridSize.y, gridSize.z];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int z = 0; z < gridSize.z; z++)
            {
                Vector3 newPosition = new Vector3(x * gridScale + gridOrigin.x, gridOrigin.y, z * gridScale + gridOrigin.z);
                GameObject newPlatform = Instantiate(platform, newPosition, Quaternion.identity);
                newPlatform.transform.localScale = new Vector3(gridScale, gridScale, gridScale);
                newPlatform.name = "Platform(" + newPosition.x + ", " + newPosition.y + ", " + newPosition.z + ")";
                newPlatform.transform.SetParent(platformRef);
            }
        }
    }
}
