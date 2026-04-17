using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyToSpawn;
    private int numberOfEnemy;
    private bool shouldSpawnEnemy = true;
    private DungeonRoom parentRoom;

    public void SetShouldSpawnEnemy(bool value)
    {
        shouldSpawnEnemy = value;
    }

    public void SpawnEnemy()
    {
        numberOfEnemy = Random.Range(1, 5);
        for (int i = 0; i < numberOfEnemy; i++)
        {
            Vector3 spawningEnemyPoint = new Vector3( transform.parent.position.x + Random.Range(-1, -35), 2, transform.parent.position.z + Random.Range(-2, -35));
            Instantiate(enemyToSpawn, spawningEnemyPoint, Quaternion.identity);
            print(spawningEnemyPoint);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        parentRoom = transform.parent.GetComponent<DungeonRoom>();
        print("enemy spawn : " + transform.parent.name);
        if (shouldSpawnEnemy)
        {
            SpawnEnemy();
            shouldSpawnEnemy = false;
        }
    }
}
