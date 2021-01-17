using UnityEngine;

public class Connection : MonoBehaviour
{
    [SerializeField] private PlayerItems playerItems;
    [SerializeField] private GameItems gameItems;


    // Start is called before the first frame update
    void Start()
    {
        //var inventory = playerItems.Inventory;
        //foreach (var itemID in inventory)
        //{
        //    if (itemID < gameItems.AllItems.Count)
        //        Debug.Log(gameItems.AllItems[itemID].Name);
        //    else
        //    {
        //        Debug.LogError("Нет предмета с таким ID");

        //    }
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
