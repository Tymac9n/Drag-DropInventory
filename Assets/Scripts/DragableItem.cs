using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private GameItems gameItems;
    public static Action<int?> OnDraggedItem;
    public ItemSlot itemSlot;
    public static ItemSlot StartingSlot;
    public static GameObject DraggedObject;
    private int? itemID;
    private PlayerEquipment _playerEquipment;

    public void Awake()
    {
        _playerEquipment = FindObjectOfType<PlayerEquipment>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        DraggedObject = gameObject;
        itemID = itemSlot.GetID();
        if (itemID == null)
        {
            DraggedObject = null;
            StartingSlot = null;
            return;
        }
        Sprite itemSprite = gameItems.GetItemByID(itemID).Image;
        _playerEquipment.dragPrefabImage.sprite = itemSprite;
        _playerEquipment.DragPrefab.SetActive(true);
        StartingSlot = itemSlot;
        OnDraggedItem.Invoke(itemID);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (DraggedObject == null) return;
        _playerEquipment.DragPrefab.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DraggedObject = null;
        _playerEquipment.DragPrefab.SetActive(false);
        OnDraggedItem.Invoke(null);
    }

    public void HideDraggedPrefab()
    {
        OnDraggedItem.Invoke(null);
        _playerEquipment.DragPrefab.SetActive(false);
    }

}