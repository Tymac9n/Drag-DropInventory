using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsOnPlayer", menuName = "Items/PlayerInventoryItems")]
public class PlayerInventoryItems : ScriptableObject
{
    [SerializeField] private List<ItemsInInventory> Inventory;

    public int PlayerItemsCount()
    {
        return Inventory.Count;
    }

    public int GetItemIDByIndex(int index)
    {
        return Inventory[index].ID;
    }

    public int GetItemCountByIndex(int index)
    {
        return Inventory[index].Count;
    }

    public bool AddNewItem(int ID)
    {
        if (!AddCount(ID))
        {
            var newItem = new ItemsInInventory();
            newItem.ID = ID;
            newItem.Count = 1;
            Inventory.Add(newItem);
            return true;
        }
        return false;
    }

    private bool AddCount(int ID)
    {
        foreach (var item in Inventory)
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

