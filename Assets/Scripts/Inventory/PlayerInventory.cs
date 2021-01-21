using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInventory : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameItems items;
    [SerializeField] private PlayerInventoryItems _playerInventory;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private RectTransform content;

    public void Start()
    {
        ImagesLoader.LoadImages();
        CreateSlotsInInventory();
    }

    private void CreateSlotsInInventory()
    {
        for (int itemIndex = 0; itemIndex < _playerInventory.PlayerItemsCount(); itemIndex++)
        {
            var ID = _playerInventory.GetItemIDByIndex(itemIndex);
            CreateNewSlot(ID,itemIndex);
        }
    }

    private void CreateNewSlot(int ID, int listIndex)
    {
        var slot = Instantiate(itemPrefab);
        slot.name = ID.ToString();
        slot.transform.SetParent(content, false);
        var SlotData = slot.GetComponent<PlayerInventorySlot>();
        SlotData.FillByID(ID);
        SlotData.SetCount(_playerInventory.GetItemCountByIndex(listIndex));
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedObject = DragableItem.DraggedObject;
        if (draggedObject == null || DragableItem.StartingSlot.GetComponent<PlayerInventorySlot>()) return;
        var draggedID = (int)DragableItem.StartingSlot.GetID();
        AddItem(draggedID);
        if(draggedObject.GetComponent<PlayerEquipmentSlot>())
            draggedObject.GetComponent<PlayerEquipmentSlot>().ClearSlot();
    }

    public void AddItem(int ID)
    {
        if (_playerInventory.AddNewItem(ID))
        {
            CreateNewSlot(ID, _playerInventory.PlayerItemsCount()-1);
            return;
        }

        foreach (RectTransform chield in content)
        {
            if(chield.name == ID.ToString())
                chield.GetComponent<PlayerInventorySlot>().IncrementCount();
        }
    }

}
