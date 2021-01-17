using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerEquipmentSlot : ItemSlot, IDropHandler
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
        int? draggedIndex = DragableItem.StartingSlot.GetIndex();
        var draggedType = gameItems.GetItemByID(draggedIndex).Type;
        if (draggedType != type)
        {
            Debug.Log("Нельзя поместить предмет с типом " + draggedType + " в ячейку с типом " + type); // error window
            return;
        }
        if (draggedObject.GetComponent<PlayerEquipmentSlot>())
        {
            SwapItems(DragableItem.StartingSlot, draggedIndex);
        }
        else FillFromIndex(draggedIndex);
        // УДАЛИТЬ!!!!!
        FindObjectOfType<PlayerEquipment>().ShowInfo(); //  Для тестов выводит все слоты экипировки героя с индексом предмета   
        // УДАЛИТЬ!!!
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
        startingSlot.GetComponent<PlayerEquipmentSlot>().FillFromIndex(draggedIndex);

    }

    public void ShowSlotInfo()
    {
        Debug.Log(gameObject.name + "index: " + itemIndex);
    }
}
