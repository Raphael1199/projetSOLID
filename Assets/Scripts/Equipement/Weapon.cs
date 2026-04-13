using System;
using UnityEngine;


[Serializable]
public class Weapon : Equipement
{
    protected int damage;
    protected float range;

    // Getter
    public int getDamage() {
        return damage;
    }

    public float getRange()
    {
        return range;
    }

    // Méthode spécifique
    public override void UseItem(PlayerCharacter player)
    {
        player.EquipItem(this);
    }

    public virtual void Attack(IAttackable target)
    {
        target.GetAttacked(damage);
    }
}
