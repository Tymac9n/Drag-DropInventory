using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : ItemSlot
{
    [SerializeField] private GameItems items;
    [SerializeField] public Image Image;
    [SerializeField] private Text title;
    [SerializeField] private Text description;
    //[SerializeField] private Text countText;
    //[SerializeField] private int count;
    [SerializeField] private int itemID;
    [SerializeField] private ItemType type;
    //[SerializeField] private bool countable;

    public override int? GetID()
    {
        return itemID;
    }

    public void FillByID(int ID)
    {
        var item = items.GetItemByID(ID);
        if (item == null) return;
        type = item.Type;
        title.text = item.Name;
        description.text = item.Description;
        Image.sprite = item.Image;
        itemID = ID;
    }

    //public void SetCount(int amount)
    //{
    //    count = amount;
    //    if (count > 1) ShowCount();
    //    countText.text = count.ToString();
    //}

    //public void IncrementCount()
    //{
    //    count++;
    //    if (count > 1) ShowCount();
    //    countText.text = count.ToString();
    //}

    //public void DecrementCount()
    //{
    //    count--;
    //    if(count < 1) Destroy(gameObject);
    //    countText.text = count.ToString();
    //    if (count < 2) HideCount();
    //}

    public ItemType GetType( )
    {
        return type;
    }

    //public void SetCountable(bool countable)
    //{
    //    this.countable = countable;
    //}

    //public bool IsCountable()
    //{
    //    return countable;
    //}

    //private void ShowCount()
    //{
    //    countText.enabled = true;
    //}

    //private void HideCount()
    //{
    //    countText.enabled = false;
    //}
}
