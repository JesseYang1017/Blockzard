using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDetailUI : MonoBehaviour
{
    
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI descriptionText;
    public GameObject propertyGrid;
    public GameObject propertyTemplate;
    private ItemSO itemSO;
    private ItemUI itemUI;
    private void Start(){
        propertyTemplate.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public void UpdateItemDetailUI(ItemSO itemSO, ItemUI itemUI){
        this.itemSO = itemSO;
        this.itemUI = itemUI;
        this.gameObject.SetActive(true);
        string type = "";
        switch(itemSO.itemType){
            case ItemType.Weapon:
                type = "Weapon";
                break;
            case ItemType.Consumable:
                type = "Consumable";
                break;
        }
        iconImage.sprite = itemSO.icon;
        nameText.text = itemSO.name;
        typeText.text = type;
        descriptionText.text = itemSO.description;

        foreach(Transform child in propertyGrid.transform){
            if(child.gameObject.activeSelf){
                Destroy(child.gameObject);
            }
        }

        foreach(ItemProperty property in itemSO.propertyList){
            string propertyStr = "";
            propertyStr += property.propertyType;
            propertyStr += ": " + property.value;
            GameObject go = GameObject.Instantiate(propertyTemplate);
            go.SetActive(true);
            go.transform.parent = propertyGrid.transform;
            go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = propertyStr;
        }
    }
    
    public void OnUseButtonClick(){
        
        InventoryUI.Instance.OnItemUse(itemSO, itemUI);
        this.gameObject.SetActive(false);

    }
}
