using System;
using UnityEngine;

[Serializable]
public class PlayerEquipements
{
    [SerializeField]
    private Weapon equippedWeapon;

    [SerializeField]
    private Armor equippedHelmet;
    [SerializeField]
    private Armor equippedChest;
    [SerializeField]
    private Armor equippedBoots;


    // Getters
    public Weapon GetWeapon()
    {
        return equippedWeapon;
    }

    public Armor GetHelmet()
    {
        return equippedHelmet;
    }
    public Armor GetChest()
    {
        return equippedChest;
    }
    public Armor GetBoots()
    {
        return equippedBoots;
    }

    public Equipement[] getAllEquipements()
    {
        Equipement[] equipementsToReturn = new Equipement[4];
        equipementsToReturn[0] = equippedWeapon;
        equipementsToReturn[1] = equippedHelmet;
        equipementsToReturn[2] = equippedChest;
        equipementsToReturn[3] = equippedBoots;
        return equipementsToReturn;
    }


    // Méthode spécifique
    public void EquipItem(Equipement itemToEquip)
    {
        if (itemToEquip is Weapon)
        {
            equippedWeapon = (Weapon)itemToEquip;
        }
        else if (itemToEquip is Armor)
        {
            Armor armor = (Armor)itemToEquip;
            switch (armor.GetArmorType())
            {
                case Armor.armorTypes.Helmet:
                    equippedHelmet = armor;
                    break;

                case Armor.armorTypes.Chest:
                    equippedChest = armor;
                    break;

                case Armor.armorTypes.Boots:
                    equippedBoots = armor;
                    break;

                default:
                    break;
            }
            return;
        }
    }
}
