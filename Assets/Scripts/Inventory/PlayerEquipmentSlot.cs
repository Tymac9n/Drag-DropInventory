using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerEquipmentSlot : ItemSlot, IDropHandler
{
    [SerializeField] private GameItems gameItems;
    [SerializeField] private PlayerInventory inventoryItems;
    [SerializeField] private EquippedItems equippedItems;
    [SerializeField] private SoundController sound;
    [SerializeField] public Image Image;
    [SerializeField] public Image CrossImage;
    [SerializeField] private int? itemID;
    [SerializeField] private ItemType type;
    [SerializeField] private int index;

    public void Start()
    {
        DragableItem.OnDraggedItem += OnDraggedItem;
        index = transform.GetSiblingIndex();
        FillFromID(equippedItems.GetIDByIndex(index));
    }

    public void OnDestroy()
    {
        DragableItem.OnDraggedItem -= OnDraggedItem;
    }

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
        if (draggedType != type) return;
        if (draggedObject.GetComponent<PlayerEquipmentSlot>())
        {
            SwapItems(DragableItem.StartingSlot, draggedID);
            sound.PlaySound(itemID);
            return;
        }
        if (DragableItem.StartingSlot.GetComponent<PlayerInventorySlot>())
        {
            DragableItem.DraggedObject.GetComponent<DragableItem>().HideDraggedPrefab();
            DragableItem.StartingSlot.GetComponent<PlayerInventorySlot>().DecrementCount();
            if(itemID!=null)
                inventoryItems.AddItem((int) itemID);
        }
        FillFromID(draggedID);
        sound.PlaySound(itemID);
    }

    private void FillFromID(int? ID)
    {
        itemID = ID;
        var item = gameItems.GetItemByID(ID);
        if (item == null)
        {
            ClearSlot();
            return;
        }
        Image.sprite = item.Image;
        Color thisColor = Image.color;
        thisColor.a = 1f;
        Image.color = thisColor;
        equippedItems.SetIDByIndex((int)ID,index);
    }

    public void ClearSlot()
    {
        itemID = null;
        Color slotColor = Image.color;
        slotColor.a = 0.05f;
        Image.color = slotColor;
        Image.sprite = null;
        equippedItems.Clear(index);
    }

    private void SwapItems(ItemSlot startingSlot, int? draggedID)
    {
        int? tempIndex = draggedID;
        draggedID = itemID;
        itemID = tempIndex;
        FillFromID(itemID);
        startingSlot.GetComponent<PlayerEquipmentSlot>().FillFromID(draggedID);

    }

    private void OnDraggedItem(int? ID)
    {
        if (ID == null)
            IsActiveSlot(true);
        else IsActiveSlot(gameItems.GetItemByID(ID).Type == type);
    }

    private void IsActiveSlot(bool IsEqualType)
    {
        CrossImage.enabled = !IsEqualType;
    }
}
