using Unity.Mathematics;
using UnityEngine;

public abstract class LivingObject : MonoBehaviour, IAttackable
{
    [Header("Living")]
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHealth = 20;
    [SerializeField] protected FX killFX = null;

    private void Start()
    {
        hp = maxHealth;
    }

    public int getHealth()
    {
        return hp;
    }

    public float getMaxHealth()
    {
        return maxHealth;
    }


    public void kill()
    {
        hp = 0;
        //Level.AddFX(killFX, transform.position, transform.rotation);
        //Level.DestroyLivingObject(this);
    }

    public void gainHP(int hpGot)
    {
        hp += hpGot;
    }

    public bool isAlive()
    {
        return hp >= 0;
    }

    public void LoseHP(int dmg)
    {
        hp -= dmg;
    }
    

    public virtual void GetAttacked(int damage)
    {
        LoseHP(damage);
    }

    public virtual void PlayhitFx(FX hitFx, Vector3 positionFx)
    {
        Instantiate(hitFx, positionFx, transform.rotation);
    }
}