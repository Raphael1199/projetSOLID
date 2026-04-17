using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DebugMatrix : MonoBehaviour
{
    public List<List<DungeonData>> listToAffich;

    public DungeonData.RoomType[][] arrayToAffich;
    public DungeonData.RoomType[] arrayIntermediaire;

    public void SetListToAffich(DungeonData[,] rooms, int width, int height)
    {
        arrayToAffich = new DungeonData.RoomType[width][];
        for (int x = 0; x < width; x++)
        {
            arrayIntermediaire = new DungeonData.RoomType[width];
            for (int y = 0; y < height; y++)
            {
                    arrayIntermediaire[y] = rooms[x, y].GetRoomType(); 

                //Debug.Log(rooms[x, y].GetRoomType());
            }
            arrayToAffich[x] = arrayIntermediaire;
        }
    }
}
