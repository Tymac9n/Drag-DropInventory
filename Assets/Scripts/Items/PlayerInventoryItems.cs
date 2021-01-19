using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsOnPlayer", menuName = "Items/PlayerInventoryItems")]
public class PlayerInventoryItems : ScriptableObject
{
    [SerializeField] private List<ItemsInInventory> inventory;

    public int PlayerItemsCount()
    {
        return inventory.Count;
    }

    public int GetItemIDByIndex(int index)
    {
        return inventory[index].ID;
    }

    public int GetItemCountByIndex(int index)
    {
        return inventory[index].Count;
    }

    public void DecreaseItem(int ID)
    {
        foreach (var item in inventory)
        {
            if (item.ID == ID)
            {
                item.Count--;
                if (item.Count < 1) inventory.Remove(item);
                return;
            }
        }
    }

    public bool AddNewItem(int ID)
    {
        if (!AddCount(ID))
        {
            var newItem = new ItemsInInventory();
            newItem.ID = ID;
            newItem.Count = 1;
            inventory.Add(newItem);
            return true;
        }
        return false;
    }

    private bool AddCount(int ID)
    {
        foreach (var item in inventory)
        {
            if (item.ID == ID)
            {
                item.Count++;
                return true;
            }
        }
        return false;
    }
}

[System.Serializable]
public class ItemsInInventory
{
    public int ID;
    public int Count;
}

