using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private GameItems gameItems;
    [SerializeField] private AudioClip armorEquiped;
    [SerializeField] private AudioClip weaponEquiped;
    [SerializeField] private AudioClip artifactEquiped;
    [SerializeField] private AudioClip deleteItem;

    public void PlaySound(int? itemID)
    {
        if (itemID != null)
        {
            var type = gameItems.GetItemByID(itemID).Type;
            switch (type)
            {
                case ItemType.Armor:
                    source.clip = armorEquiped;
                    source.Play();
                    break;
                case ItemType.Weapon:
                    source.clip = weaponEquiped;
                    source.Play();
                    break;
                case ItemType.Artifact:
                    source.clip = artifactEquiped;
                    source.Play();
                    break;
            }
        }
        else
        {
            source.clip = deleteItem;
            source.Play();
        }
    }
}
