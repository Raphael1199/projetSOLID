using System;
using UnityEngine;

[Serializable]
public class PlayerEquipements
{
    [SerializeField]
    private Weapon equippedWeapon;

    [SerializeField]
    private Armor equippedArmor;

    // Getters
    public Weapon GetWeapon()
    {
        return equippedWeapon;
    }

    public Armor GetArmor()
    {
        return equippedArmor;
    }

    public Equipement[] getAllEquipements()
    {
        Equipement[] equipementsToReturn = new Equipement[4];
        equipementsToReturn[0] = equippedWeapon;
        equipementsToReturn[1] = equippedArmor;
        return equipementsToReturn;
    }


    // M�thode sp�cifique
    public void EquipItem(Equipement itemToEquip)
    {
        if (itemToEquip is Weapon)
        {
            equippedWeapon = (Weapon)itemToEquip;
        }
        else if (itemToEquip is Armor)
        {
            equippedArmor = (Armor)itemToEquip;
            return;
        }
    }
}
