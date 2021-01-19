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
        var SlotData = slot.GetComponent<InventorySlot>();
        SlotData.FillByID(ID);
        SlotData.SetCount(_playerInventory.GetItemCountByIndex(listIndex));
    }

    public void OnDrop(PointerEventData eventData)
    {
        var draggedObject = DragableItem.DraggedObject;
        if (draggedObject == null) return;
        var draggedID = (int)DragableItem.StartingSlot.GetIndex();
        AddItem(draggedID);
    }

    private void AddItem(int ID)
    {
        if (_playerInventory.AddNewItem(ID))
        {
            CreateNewSlot(ID, _playerInventory.PlayerItemsCount()-1);
        }
        // перебрать всех в иерархии по имени найти id
    }

}
