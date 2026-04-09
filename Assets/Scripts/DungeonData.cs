using System;
using UnityEngine;

[Serializable]
public class DungeonData 
{
    public enum RoomType { None, Start, Normal, Boss }
    private bool isVisited = false;
    private RoomType roomType = RoomType.None;
    public DungeonRoom room;

    public RoomType GetRoomType()
    {
        return roomType;
    }

    public void SetRoomType(RoomType type)
    {
        roomType = type;
    }

    public bool getIsVisited()
    {
        return isVisited;
    }

    public void setIsVisited(bool isVisited)
    {
        this.isVisited = isVisited;
    }
}
