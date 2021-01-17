using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private GameItems items;
    [SerializeField] private PlayerItems playerItems;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private RectTransform content;

    public void Start()
    {
        ImagesLoader.LoadImages();
        for (int itemIndex = 0; itemIndex < playerItems.PlayerItemsCount(); itemIndex++)
        {
            var ID = playerItems.GetItemIDByIndex(itemIndex);
            var slot = Instantiate(itemPrefab);
            slot.GetComponent<InventorySlot>().FillByID(ID);
            slot.name = items.GetItemByID(ID).Name;
            slot.transform.SetParent(content, false);
        }
    }
}
