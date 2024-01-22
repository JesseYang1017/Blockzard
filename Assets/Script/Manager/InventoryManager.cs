using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private AudioClip damageSoundClip;
    public static InventoryManager Instance { get; set; }
    public ItemSO defaultWeapon;
    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    
    public List<ItemSO> itemList;


    public void AddItem(ItemSO item){
        AudioSource.PlayClipAtPoint(damageSoundClip, transform.position, 1f);
        itemList.Add(item);
        InventoryUI.Instance.AddItem(item);
        MessageUI.Instance.Show("You obtained: " + item.name);
    }

    public void RemoveItem(ItemSO itemSO){
        itemList.Remove(itemSO);
    }
}
