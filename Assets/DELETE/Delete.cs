using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Delete", menuName = "Items/DEleTE")]
public class Delete : ScriptableObject
{
    [SerializeField] private TempInInventory[] Inventory;

    public void AddItem(int ID)
    {
        foreach (var VARIABLE in Inventory)
        {
            if (VARIABLE.ID == ID)
            {
                VARIABLE.Count++;
                return;
            }
        }
    }

    public int PlayerItemsCount()
    {
        return Inventory.Length;
    }

    public int GetItemIDByIndex(int index)
    {
        return Inventory[index].ID;
    }

    public int GetItemCountByIndex(int index)
    {
        return Inventory[index].Count;
    }
}

[System.Serializable]
public class TempInInventory
{
    public int ID;
    public int Count;
}
