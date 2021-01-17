using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsOnPlayer", menuName = "Items/PlayerItems")]
public class PlayerItems : ScriptableObject
{
    [SerializeField] private int[] Inventory;

    public int PlayerItemsCount()
    {
        return Inventory.Length;
    }

    public int GetItemIDByIndex(int index)
    {
        return Inventory[index];
    }
}
