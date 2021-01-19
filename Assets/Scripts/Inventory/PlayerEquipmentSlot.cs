﻿using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerEquipmentSlot : ItemSlot, IDropHandler
{
    [SerializeField] private GameItems gameItems;
    [SerializeField] private PlayerInventory inventoryItems;
    [SerializeField] public Image Image;
    [SerializeField] private int? itemID;
    [SerializeField] private ItemType type;

    public override int? GetID()
    {
        return itemID;
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedObject = DragableItem.DraggedObject;
        if (draggedObject == null) return;
        int? draggedID = DragableItem.StartingSlot.GetID();
        var draggedType = gameItems.GetItemByID(draggedID).Type;
        if (draggedType != type)
        {
            Debug.Log("Нельзя поместить предмет с типом " + draggedType + " в ячейку с типом " + type); // error window
            return;
        }
        if (draggedObject.GetComponent<PlayerEquipmentSlot>())
        {
            SwapItems(DragableItem.StartingSlot, draggedID);
            return;
        }
        if (DragableItem.StartingSlot.GetComponent<PlayerInventorySlot>())
        {
            DragableItem.DraggedObject.GetComponent<DragableItem>().HideDraggedPrefab();
            DragableItem.StartingSlot.GetComponent<PlayerInventorySlot>().DecrementCount();
            if(itemID!=null)
                inventoryItems.AddItem((int) itemID);
        }
        FillFromIndex(draggedID);
        // УДАЛИТЬ!!!!!
        FindObjectOfType<PlayerEquipment>().ShowInfo(); //  Для тестов выводит все слоты экипировки героя с индексом предмета   
        // УДАЛИТЬ!!!
    }

    private void FillFromIndex(int? index)
    {
        itemID = index;
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

    public void ClearPlayerInventorySlot()
    {
        itemID = null;
        Color slotColor = Image.color;
        slotColor.a = 0.05f;
        Image.color = slotColor;
        Image.sprite = null;
    }

    private void SwapItems(ItemSlot startingSlot, int? draggedIndex)
    {
        int? tempIndex = draggedIndex;
        draggedIndex = itemID;
        itemID = tempIndex;
        FillFromIndex(itemID);
        startingSlot.GetComponent<PlayerEquipmentSlot>().FillFromIndex(draggedIndex);

    }

    public void ShowSlotInfo()
    {
        Debug.Log(gameObject.name + "index: " + itemID);
    }
}
