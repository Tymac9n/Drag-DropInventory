using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameItems gameItems;
    public ItemSlot itemSlot;
    public static ItemSlot StartingSlot;
    public static GameObject DraggedObject;
    private int? index;
    private PlayerInventory playerInventory;

    public void Awake()
    {
        playerInventory = FindObjectOfType<PlayerInventory>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedObject = gameObject;
        index = itemSlot.GetIndex();
        if (index == null)
        {
            DraggedObject = null;
            StartingSlot = null;
            return;
        }
        Sprite itemSprite = gameItems.GetItemByID(index).Image;
        playerInventory.dragPrefabImage.sprite = itemSprite;
        playerInventory.DragPrefab.SetActive(true);
        StartingSlot = itemSlot;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (DraggedObject == null) return;
        playerInventory.DragPrefab.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedObject = null;
        playerInventory.DragPrefab.SetActive(false);
    }

}