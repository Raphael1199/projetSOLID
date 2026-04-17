using UnityEngine;

public class Target : LivingObject, IAttackable
{
    public override void GetAttacked(int damage)
    {
        base.GetAttacked(damage);
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
