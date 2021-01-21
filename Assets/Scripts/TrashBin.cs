using UnityEngine;
using UnityEngine.EventSystems;

public class TrashBin : MonoBehaviour, IDropHandler
{
    [SerializeField] private SoundController sound;

    public void OnDrop(PointerEventData eventData)
    {
        var draggedObject = DragableItem.DraggedObject;
        if (draggedObject == null) return;
        sound.PlaySound(null);
        if (draggedObject.GetComponent<PlayerEquipmentSlot>())
        {
            draggedObject.GetComponent<PlayerEquipmentSlot>().ClearSlot();
            return;
        }
        if (DragableItem.StartingSlot.GetComponent<PlayerInventorySlot>())
        {
            DragableItem.DraggedObject.GetComponent<DragableItem>().HideDraggedPrefab();
            DragableItem.StartingSlot.GetComponent<PlayerInventorySlot>().DecrementCount();
        }
    }
}
