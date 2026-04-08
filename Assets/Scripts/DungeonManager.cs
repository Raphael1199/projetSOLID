using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    [SerializeField]
    private int width;
    [SerializeField]
    private int depth;
    [SerializeField]
    private DungeonData[,] map;
    private Vector2Int startPos;

    Vector2Int[] directions = {
    new Vector2Int(1, 0) ,  // droite
    new Vector2Int(-1, 0), // gauche
    new Vector2Int(0, 1),  // haut
    new Vector2Int(0, -1) // bas
};

    //debug
    public DebugMatrix DebugMatrix;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        map = new DungeonData[width, depth];
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < depth; j++)
            {
                map[i, j] = new DungeonData();
            }
        }

        startPos = new Vector2Int(0, 0);
        GenerateMap(startPos, startPos, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GenerateMap(Vector2Int current, Vector2Int previous, int branchChance)
    {
        map[current.x, current.y].setIsVisited(true);
        map[current.x, current.y].SetRoomType(DungeonData.RoomType.Normal);

        Vector2Int next;

        do
        {
            next = GetUnvisitedCells(current);
            if (next.x != -1)
            {
                GenerateMap(next, current, branchChance);
            }
        }
        while (next.x != -1);

        DebugMatrix.SetListToAffich(map, width, depth);
    }


    private Vector2Int GetUnvisitedCells(Vector2Int currentCell)
    {
        int x = currentCell.x;
        int y = currentCell.y;

        List<Vector2Int> allDirections = new List<Vector2Int>();

        if (x + 1 < width)
        {
            DungeonData cellToRight = map[x + 1, y];

            if (cellToRight.getIsVisited() == false)
            {
                allDirections.Add(directions[0]);
            }
        }

        if (x - 1 >= 0)
        {
            var cellToLeft = map[x - 1, y];

            if (cellToLeft.getIsVisited() == false)
            {
                allDirections.Add(directions[1]);
            }
        }

        if (y + 1 < depth)
        {
            var cellToFront = map[x, y + 1];

            if (cellToFront.getIsVisited() == false)
            {
                allDirections.Add(directions[2]);
            }
        }

        if (y - 1 >= 0)
        {
            var cellToBack = map[x, y - 1];

            if (cellToBack.getIsVisited() == false)
            {
                allDirections.Add(directions[3]);
            }
        }

        if (allDirections.Count == 0)
        {
            return new Vector2Int(-1, -1);
        }
        return allDirections[Random.Range(0, allDirections.Count)] + currentCell;
    }


    private bool IsInsideGrid(Vector2Int pos)
    {
        return (pos.x >= 0 && pos.x <= width && pos.y >= 0 && pos.y <= depth);
    }

    private Vector2Int GetRandomDirection()
    {
        return directions[Random.Range(0, directions.Length)];
    }


}
