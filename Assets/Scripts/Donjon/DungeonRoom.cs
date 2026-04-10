using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public enum RoomObjective { None, Enemy, Puzzle, Rest }
    private RoomObjective roomObjective;
    /// <summary>
    /// /////////////////
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
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

    private GameObject[] doorToOpen = new GameObject[4];

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
        leftDoor.SetActive(false);
    }

    public void ClearRightDoor()
    {
        rightDoor.SetActive(false);
    }

    public void ClearTopDoor()
    {
        topDoor.SetActive(false);
    }

    public void ClearDownDoor()
    {
        downDoor.SetActive(false);
    }

    /// <summary>
    /// ///////////////////////////////////////////////
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public void OpenAllRequiredDoor()
    {
        foreach (var item in doorToOpen)
        {
            if (item != null)
            {
                item.SetActive(false);
            }
        }
    }

    private void CloseAllDoor()
    {
        leftDoor.SetActive(true);
        rightDoor.SetActive(true);
        topDoor.SetActive(true);
        downDoor.SetActive(true);
    }
}
