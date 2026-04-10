using System;
using UnityEngine;

[Serializable]
public class DungeonData 
{
    public enum RoomType { None, Start, Normal, Boss }
    private bool isVisited = false;
    private RoomType roomType = RoomType.None;
    private DungeonRoom room;

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

    public DungeonRoom GetRoom()
    {
        return room;
    }

    public void SetRoom(DungeonRoom room)
    {
        this.room = room;
    }
}
