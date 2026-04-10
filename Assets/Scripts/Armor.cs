using UnityEngine;

public class Armor : Equipement
{
    private int defense;
    public enum armorTypes {Helmet, Chest, Boots};

    private armorTypes armorType;

    // Getters
    public int getDefense()
    {
        return defense;
    }
    
    public armorTypes GetArmorType()
    {
        return armorType;
    }

    // Mérhode spécifique
    public override void UseItem(PlayerCharacter player)
    {
        player.EquipItem(this);
    }
}
