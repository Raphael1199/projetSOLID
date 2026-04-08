using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public enum RoomType { None, Start, Normal, Boss }
    private bool IsVisited;
    private RoomType roomType;

    public RoomType GetRoomType()
    {
        return roomType;
    }

    public void SetRoomType(RoomType type)
    {
        roomType = type;
    }
}
