using UnityEngine;

public class Weapon : Equipement
{
    private int damage;
    private float range;

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
}
