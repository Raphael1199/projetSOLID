using System;
using UnityEngine;

[Serializable]
public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;

    // Getters
    public string getName()
    {
        return itemName;
    }

    // Méthode spécifique à réécrire
    public virtual void UseItem(PlayerCharacter player)
    {
    }

    public virtual void GetPickedUp()
    {
        Destroy(gameObject);
    }

}