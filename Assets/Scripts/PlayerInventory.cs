using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private PlayerItems playerItems;
    [SerializeField] public GameObject DragPrefab;
    [SerializeField] public Image dragPrefabImage;

    public void Awake()
    {
        ImagesLoader.LoadImages();
        //foreach (RectTransform child in gameObject.transform)
        //{
        //    child.GetComponent<PlayerInventorySlot>().FillSlot(child.GetSiblingIndex());
        //}
    }
}
