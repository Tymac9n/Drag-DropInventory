using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EquippedItems", menuName = "Items/EquippedItems")]
public class EquippedItems : ScriptableObject
{
    [SerializeField] private int[] equippedItems;

    public void SetIDByIndex(int ID, int index)
    {
        equippedItems[index] = ID;
    }

    public void Clear(int index)
    {
        equippedItems[index] = 0;
    }

    public int? GetIDByIndex(int index)
    {
        if (equippedItems[index] == 0) return null;
        else return equippedItems[index];
    }
}
