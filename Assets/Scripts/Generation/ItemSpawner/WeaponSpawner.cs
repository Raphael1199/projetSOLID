using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weaponsToSpawn;

    public void SpawnStartWeapon(Vector3 spawnPoint)
    {
        Weapon weapon = Instantiate(weaponsToSpawn[0], spawnPoint, Quaternion.identity);
        weapon.transform.Rotate(new Vector3(0, 180, 0));
    }
}
