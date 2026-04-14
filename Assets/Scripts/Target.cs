using UnityEngine;

public class Target : LivingObject, IAttackable
{
    public void GetAttacked(int damage)
    {
        LoseHP(damage);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
