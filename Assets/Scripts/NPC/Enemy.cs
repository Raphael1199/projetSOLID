using System.Collections;
using UnityEngine;

public class Enemy : MovingObject
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private int atkDelay;
    [SerializeField]
    private bool canAttack = true;
    [SerializeField]
    private FX hitFx;
    public override void GetAttacked(int damage)
    {
        base.GetAttacked(damage);
        if (!isAlive())
        {
            Instantiate(killFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (canAttack)
        {
            collision.transform.TryGetComponent<PlayerCharacter>(out PlayerCharacter player);
            if (player != null && canAttack)
            {
                player.GetAttacked(damage);
                canAttack = false;
                player.PlayhitFx(hitFx, collision.GetContact(1).point);
                StartCoroutine(attackRoutine());
            }
        }
    }

    public IEnumerator attackRoutine()
    {
        yield return new WaitForSeconds(atkDelay);
        canAttack = true;
    }

}
