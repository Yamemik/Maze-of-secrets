﻿using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] Cells CellPrefab;

    public HintRenderer HintRenderer;

    public Vector3 CellSize = new Vector3(1, 1, 0);
    public Maze maze;

    private void Start()
    {
        MazeGenerator generator = new MazeGenerator();
        maze = generator.GenerateMaze();

        for (int x = 0; x < maze.cells.GetLength(0); x++)
        {
            for (int y = 0; y < maze.cells.GetLength(1); y++)
            {
                Cells c = Instantiate(CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity);

                c.WallLeft.SetActive(maze.cells[x, y].WallLeft);
                c.WallBottom.SetActive(maze.cells[x, y].WallBottom);
            }
        }

        HintRenderer.DrawPath();
    }
}
