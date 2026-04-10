using UnityEngine;

public class LivingObject : MonoBehaviour
{
    [Header("Living")]
    [SerializeField] protected int hp;
    [SerializeField] protected int maxHealth = 20;
    [SerializeField] protected FX hitFX = null;
    [SerializeField] protected FX killFX = null;

    private void Start()
    {
        hp = maxHealth;
    }

    public float getHealth()
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

    public void getHP(int hpGot)
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

}