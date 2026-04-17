using System;
using Unity.VisualScripting;
using UnityEngine;


[Serializable]
public class Weapon : Equipement
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected int range;
    [SerializeField]
    protected FX hitFx;

    // Getter
    public int getDamage() {
        return damage;
    }

    public int getRange()
    {
        return range;
    }

    public FX getHitFX()
    {
        return hitFx;
    }

    // M�thode sp�cifique
    public override void UseItem(PlayerCharacter player)
    {
        player.EquipItem(this);
    }

    public virtual void Attack(IAttackable target)
    {
        target.GetAttacked(damage);
    }

    public override void GetPickedUp(PlayerCharacter player)
    {
        itemCollider.enabled = false;
        player.EquipItem(this);
    }
}
