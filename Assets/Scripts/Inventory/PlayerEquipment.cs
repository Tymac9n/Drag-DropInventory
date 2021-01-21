using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField] private PlayerInventoryItems _playerInventory;
    [SerializeField] public GameObject DragPrefab;
    [SerializeField] public Image dragPrefabImage;

    public void Awake()
    {
        ImagesLoader.LoadImages();
        //foreach (RectTransform child in gameObject.transform)
        //{
        //    child.GetComponent<PlayerEquipmentSlot>().FillSlot(child.GetSiblingIndex());
        //}
    }

}
