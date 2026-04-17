using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : LivingObject
{
    [SerializeField]
    private GameObject hand;
    [SerializeField]
    private string playerName;

    [SerializeField]
    private Inventory inventory = new Inventory();

    [SerializeField]
    private PlayerEquipements equipements = new PlayerEquipements();

    // Getter et Setter
    public string getName()
    {
        return playerName;
    }

    public PlayerEquipements getEquipements()
    {
        return equipements;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    // Méthodes spécifiques
    public void Attack(int damage)
    {
        // Logique d'attaque avec l'arme équipée
        System.Console.WriteLine($"{name} attaque pour {damage} points de dégâts!");
    }

    public void RestoreHealth(int amount)
    {
        hp = System.Math.Min(hp + amount, maxHealth);
        System.Console.WriteLine($"{name} restaure {amount} points de vie!");
    }

    public void LoseHealth(int amount)
    {
        hp = System.Math.Max(hp - amount, 0);
        System.Console.WriteLine($"{name} perd {amount} points de vie!");
    }

    public void UseItem(Item item)
    {
        item.UseItem(this);
    }

    public void EquipItem(Equipement equipement)
    {
        equipements.EquipItem(equipement);
        equipement.transform.SetParent(hand.transform);
        equipement.transform.position = hand.transform.position;
        equipement.transform.rotation = hand.transform.rotation;
    }

    public void GrabItem(Item itemPickedUp)
    {
        inventory.AddItem(itemPickedUp);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.TryGetComponent<Item>(out Item item);
        if (item != null)
        {
            print("ça touche");
            GrabItem(item);
            item.GetPickedUp(this);
        }
    }

    public override void GetAttacked(int damage)
    {
        base.GetAttacked(damage);
        if (!isAlive())
        {
            GameManager.Instance.FinishGame();
        }
        GameManager.Instance.UpdateUI();

    }
}