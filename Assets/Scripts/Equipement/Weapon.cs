using System;
using UnityEngine;


[Serializable]
public class Weapon : Equipement
{
    [SerializeField]
    protected int damage;
    [SerializeField]
    protected int range;

    // Getter
    public int getDamage() {
        return damage;
    }

    public int getRange()
    {
        return range;
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
}
