using UnityEngine;

public class DungeonRoom : MonoBehaviour
{
    public enum RoomObjective { None, Enemy, Puzzle, Rest }
    private RoomObjective roomObjective;

    [SerializeField]
    private GameObject leftDoor;
    [SerializeField]
    private GameObject rightDoor;
    [SerializeField]
    private GameObject topDoor;
    [SerializeField]
    private GameObject downDoor;

    private GameObject[] doorToOpen = new GameObject[4];

    [SerializeField]
    private Transform playerSpawnPoint;

    public RoomObjective GetRoomObjective()
    {
        return roomObjective;
    }

    public void SetRoomObjective(RoomObjective Objective)
    {
        roomObjective = Objective;
    }

    public Vector3 GetSpawnPoint()
    {
        return playerSpawnPoint.position;
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
