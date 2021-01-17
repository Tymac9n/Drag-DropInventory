using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerInventorySlot : ItemSlot, IDropHandler
{
    [SerializeField] private GameItems gameItems;
    [SerializeField] public Image Image;
    [SerializeField] private int? itemIndex;
    [SerializeField] private ItemType type;

    public override int? GetIndex()
    {
        return itemIndex;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedObject = DragableItem.DraggedObject;
        if (draggedObject == null) return;
        int? draggedIndex = draggedObject.GetComponent<ItemSlot>().GetIndex();
        var draggedType = gameItems.GetItemByID(draggedIndex).Type;
        if (draggedType != type)
        {
            Debug.Log("Нельзя поместить предмет с типом " + draggedType + " в ячейку с типом " + type); // error window
            return;
        }
        if (draggedObject.GetComponent<PlayerInventorySlot>())
        {
            SwapItems(DragableItem.StartingSlot, draggedIndex);
        }
        else FillFromIndex(draggedIndex);
    }

    private void FillFromIndex(int? index)
    {
        itemIndex = index;
        var item = gameItems.GetItemByID(index);
        if (item == null)
        {
            ClearPlayerInventorySlot();
            return;
        }
        Image.sprite = item.Image;
        Color thisColor = Image.color;
        thisColor.a = 1f;
        Image.color = thisColor;
    }

    private void ClearPlayerInventorySlot()
    {
        itemIndex = null;
        Color slotColor = Image.color;
        slotColor.a = 0.05f;
        Image.color = slotColor; 
        Image.sprite = null;
    }

    private void SwapItems(ItemSlot startingSlot, int? draggedIndex)
    {
        int? tempIndex = draggedIndex;
        draggedIndex = itemIndex;
        itemIndex = tempIndex;
        FillFromIndex(itemIndex);
        startingSlot.GetComponent<PlayerInventorySlot>().FillFromIndex(draggedIndex);

    }
}
