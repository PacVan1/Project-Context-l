using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize = new Vector2Int(10, 10);
    [SerializeField] int gridCellSize = 1;
    public bool[,] grid;

    Vector3 mousePosition;

    void Start()
    {
        grid = new bool[gridSize.x, gridSize.y];
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 mousePositionRelativeToGrid = mousePosition - transform.position;
            Vector2Int mouseGridIndex = new Vector2Int((int)mousePositionRelativeToGrid.x / gridCellSize, (int)mousePositionRelativeToGrid.y / gridCellSize);

            if (mouseGridIndex.x > 0 && mouseGridIndex.x < gridSize.x - 1 && mouseGridIndex.y > 0 && mouseGridIndex.y < gridSize.y - 1)
            {
                grid[mouseGridIndex.x, mouseGridIndex.y] = true;
                Debug.Log("mouse index added!");
            }
            else
            {
                Debug.Log("mouse button pressed!");
            }
        }
    }

    private void OnDrawGizmos()
    {
        // draw grid positions
        for (int i = 0; i < gridSize.x; i++)
        {
            for (int j = 0; j < gridSize.y; j++)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(new Vector3(i * gridCellSize + transform.position.x, j * gridCellSize + transform.position.y), 0.2f);

/*                if (grid[i, j] == true)
                {
                    Gizmos.color = Color.white;
                    Gizmos.DrawSphere(new Vector3(i * gridCellSize + transform.position.x, j * gridCellSize + transform.position.y), 0.1f);
                }*/
            }
        }
    }
}
