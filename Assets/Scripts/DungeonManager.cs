using System.Collections;
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

    [SerializeField]
    private List<Vector2Int> activeRooms = new List<Vector2Int>();

    Vector2Int[] directions = {
    new Vector2Int(1, 0) ,  // droite
    new Vector2Int(-1, 0), // gauche
    new Vector2Int(0, 1),  // haut
    new Vector2Int(0, -1) // bas
};

    public GameObject roomToSpawn;

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
                //print(i + "///" + j);
                map[i, j] = new DungeonData();
            }
        }

        startPos = new Vector2Int(0, 0);
        //StartCoroutine(GenerateMap(startPos, startPos, 1, 0));
        StartCoroutine(GenerateMapNew(startPos, 10));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator GenerateMap(Vector2Int current, Vector2Int previous, int branchChance, int currentCount)
    {
        int count = currentCount++;
        if (map[current.x, current.y].getIsVisited() == false)
        {
            map[current.x, current.y].setIsVisited(true);
            map[current.x, current.y].SetRoomType(DungeonData.RoomType.Normal);

            GameObject createdRoom = Instantiate(roomToSpawn, new Vector3(current.x * 60, 0, current.y * 60), Quaternion.identity);
            createdRoom.name = currentCount.ToString();

            yield return new WaitForSeconds(2f);

            Vector2Int next;

            do
            {
                next = GetUnvisitedCells(current);
                Debug.Log("Je suis en " + current.x + " / " + current.y + " -> et je génère en -> " + next.x + " / " + next.y);
                if (next.x != -1)
                {
                    StartCoroutine(GenerateMap(next, current, branchChance, currentCount));
                    //GenerateMap(next, current, branchChance);
                }
            }
            while (next.x != -1);

            DebugMatrix.SetListToAffich(map, width, depth);
        }
    }

    private IEnumerator GenerateMapNew(Vector2Int start, int maxRoomCount)
    {
        Vector2Int current = start;
        //activeRooms.Add(current);

        int currentCount = 0;

        while(currentCount < maxRoomCount)
        {
            yield return new WaitForSeconds(2f);
            Vector2Int dir = GetRandomDirection(current);

            if (dir.x != -1 && dir.y != -1)
            {
                Vector2Int next = dir;

                /////////////////////////////////////////////////////////////////
                if (IsInsideGrid(next))
                {
                    bool roomExists = map[next.x, next.y] != null;
                    if (roomExists)
                    {

                        map[next.x, next.y] = new DungeonData();
                        map[next.x, next.y].SetRoomType(DungeonData.RoomType.Normal);

                        activeRooms.Add(next);
                        current = next;

                        Debug.Log("Je suis en " + current.x + " / " + current.y + " -> et je génère en -> " + next.x + " / " + next.y);
                        GameObject createdRoom = Instantiate(roomToSpawn, new Vector3(current.x * 60, 0, current.y * 60), Quaternion.identity);
                        createdRoom.name = currentCount.ToString();
                        map[current.x, current.y].setIsVisited(true);
                        currentCount++;
                    }
                }
            }
            else
            {
                // On repart d'une salle existante --> évite les blocages
                print("blocage");
                current = activeRooms[Random.Range(0, activeRooms.Count - 1)];
            }
        }
        //yield return new WaitForEndOfFrame();
    }

    private Vector2Int GetRandomDirection(Vector2Int currentCell)
    {

        int x = currentCell.x;
        int y = currentCell.y;

        List<Vector2Int> allDirections = new List<Vector2Int>();

        if (x + 1 < width)
        {
            DungeonData cellToRight = map[x + 1, y];

            if (cellToRight.getIsVisited() == false && IsInsideGrid(currentCell + directions[0]))
            {
                allDirections.Add(directions[0]);
            }
        }

        if (x - 1 >= 0)
        {
            DungeonData cellToLeft = map[x - 1, y];

            if (cellToLeft.getIsVisited() == false && IsInsideGrid(currentCell + directions[1]))
            {
                allDirections.Add(directions[1]);
            }
        }

        if (y + 1 < depth)
        {
            DungeonData cellToFront = map[x, y + 1];

            if (cellToFront.getIsVisited() == false && IsInsideGrid(currentCell + directions[2]))
            {
                allDirections.Add(directions[2]);
            }
        }

        if (y - 1 >= 0)
        {
            DungeonData cellToBack = map[x, y - 1];

            if (cellToBack.getIsVisited() == false && IsInsideGrid(currentCell + directions[0]))
            {
                allDirections.Add(directions[3]);
            }
        }

        if (allDirections.Count == 0)
        {
            return new Vector2Int(-199, -199);
        }
        return allDirections[Random.Range(0, allDirections.Count)] + currentCell;
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
            DungeonData cellToLeft = map[x - 1, y];

            if (cellToLeft.getIsVisited() == false)
            {
                allDirections.Add(directions[1]);
            }
        }

        if (y + 1 < depth)
        {
            DungeonData cellToFront = map[x, y + 1];

            if (cellToFront.getIsVisited() == false)
            {
                allDirections.Add(directions[2]);
            }
        }

        if (y - 1 >= 0)
        {
            DungeonData cellToBack = map[x, y - 1];

            if (cellToBack.getIsVisited() == false)
            {
                allDirections.Add(directions[3]);
            }
        }

        if (allDirections.Count == 0)
        {
            Debug.Log("zehbi y a pas la place");
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
