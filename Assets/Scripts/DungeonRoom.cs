using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public enum RoomObjective { None, Enemy, Puzzle, Rest }
    private RoomObjective roomObjective;
    /// <summary>
    /// /////////////////
    /// </summary>
    [SerializeField]
    private DungeonData dungeonData;

    [SerializeField]
    private GameObject leftDoor;
    [SerializeField]
    private GameObject rightDoor;
    [SerializeField]
    private GameObject topDoor;
    [SerializeField]
    private GameObject downDoor;

    public RoomObjective GetRoomObjective()
    {
        return roomObjective;
    }

    public void SetRoomObjective(RoomObjective Objective)
    {
        roomObjective = Objective;
    }

    public DungeonData GetDungeonData()
    {
        return dungeonData;
    }

    public void SetDungeonData(DungeonData data)
    {
        dungeonData = data;
    }

    public void ClearLeftDoor()
    {

    }
}
