using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/AllGameItems", fileName = "GameItems")]
public class GameItems : ScriptableObject
{
    [SerializeField] private List<Item> AllItems;

    public int ItemsCount
    {
        get { return AllItems.Count; }
    }

    public Item GetItemByID(int? id)
    {
        if (id == null)
            return null;
        else
        {
            foreach (var item in AllItems)
            {
                if (item.ID == id)
                    return item;
            }

            return null;
        }
    }

    public int GetIDByIndex(int index)
    {
        return AllItems[index].ID;
    }
}
