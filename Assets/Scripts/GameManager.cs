using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
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
}
