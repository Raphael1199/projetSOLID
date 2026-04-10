using System;
using UnityEngine;

[Serializable]
public class Item : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private string description;
    [SerializeField]
    private float weight;
    [SerializeField]
    private int value;

    // Getters
    public string getName()
    {
        return itemName;
    }

    public string getDescription()
    {
        return description;
    }

    public float getWeight()
    {
        return weight;
    }

    public int getValue()
    {
        return value;
    }

    // Méthode spécifique à réécrire
    public virtual void UseItem(PlayerCharacter player)
    {
    }
}