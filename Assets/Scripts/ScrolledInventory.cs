using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolledInventory : MonoBehaviour
{
    [SerializeField] private GameItems items;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private RectTransform content;

    public void Start()
    {
        ImagesLoader.LoadImages();
        for(int itemIndex = 0; itemIndex < items.ItemsCount; itemIndex++)
        {
            var item = items.GetItemByID(itemIndex);
            if(item == null)
                return;
            var slot = Instantiate(itemPrefab);
            slot.name = item.Name;
            slot.GetComponent<InventorySlot>().FillFromIndex(itemIndex);
            slot.transform.SetParent(content,false);
        }
    }
}
