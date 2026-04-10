using UnityEngine;

public class LivingObject : MonoBehaviour
{
    [Header("Living")]
    public const int DEFAULT_HP = 13;
    [SerializeField] private int hp = DEFAULT_HP;
    [SerializeField] private FX hitFX = null;
    [SerializeField] private FX killFX = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

#if UNITY_EDITOR
    private void OnMouseDown()
    {
        //Hit(3);
    }
#endif

}