using UnityEngine;

public class MazeGeneratorCell : MonoBehaviour
{
    public int X { get; set; }
    public int Y { get; set; }

    public bool WallLeft = true;
    public bool WallBottom = true;

    public bool Visited = false;
    public int DistanceFromStart;
}
