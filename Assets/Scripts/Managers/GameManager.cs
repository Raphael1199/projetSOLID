using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField]
    private DungeonManager dungeonManager;
    [SerializeField]
    private WeaponSpawner weaponSpawner;
    [SerializeField]
    private UIManager UIManager;

    public GameObject player;
    public static GameManager Instance

    {
        get { return instance; }
    }


    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance =  FindAnyObjectByType<GameManager>();
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
        SpawnPlayer(dungeonManager.GetDungeonRooms()[0].GetSpawnPoint() + Vector3.up);
        weaponSpawner.SpawnStartWeapon(dungeonManager.GetDungeonRooms()[0].GetSpawnPoint() + new Vector3(0, 1, 3));
        UpdateUI();
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

    public void FinishGame()
    {
        StartCoroutine(LoseRoutine());
    }

    public IEnumerator LoseRoutine()
    {
        Destroy(player);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public void UpdateUI()
    {
        UIManager.UpdateHP(player.GetComponent<PlayerCharacter>().getHealth());
    }
}
