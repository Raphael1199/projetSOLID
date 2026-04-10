using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    private DungeonManager dungeonManager;

    public static GameManager Instance
    {
        get { return instance; }
    }

    public GameObject player;


    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = FindFirstObjectByType<GameManager>();
            if (instance == null)
            {
                GameObject gm = new GameObject();
                gm.name = "GameManager";
                instance = gm.AddComponent<GameManager>();
            }
        }
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("already an instance running", this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        StartGame();
        dungeonManager.GetDungeonRooms();
        SpawnPlayer(dungeonManager.GetDungeonRooms()[0].GetSpawnPoint() + Vector3.up);
    }

    public void SpawnPlayer(Vector3 playerStartPosition)
    {
        player.transform.position = playerStartPosition;
        player.SetActive(true);
    }

    private void StartGame()
    {
        dungeonManager.StartGenerating();
    }
}
