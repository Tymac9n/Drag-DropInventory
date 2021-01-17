using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItemsInventory : MonoBehaviour
{
    [SerializeField] private GameItems items;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private RectTransform content;

    public void Start()
    {
        ImagesLoader.LoadImages();
        for (int itemIndex = 0; itemIndex < items.ItemsCount; itemIndex++)
        {
            var ID = items.GetIDByIndex(itemIndex);
            var slot = Instantiate(itemPrefab);
            slot.GetComponent<InventorySlot>().FillByID(ID);
            slot.name = items.GetItemByID(ID).Name;
            slot.transform.SetParent(content, false);
        }
    }
}
