using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerPropertyUI : MonoBehaviour
{
    public static PlayerPropertyUI Instance { get; private set; }
    private Image hpProgressBar;
    private TextMeshProUGUI hpText;
    private Image levelProgressBar;
    private TextMeshProUGUI levelText;
    private GameObject propertyGrid;
    private GameObject propertyTemplate;
    private Image weaponIcon;
    private GameObject uiGameObject;
    private PlayerProperty pp;
    private PlayerAttack pa;


    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called before the first frame update
    void Start(){
        uiGameObject = transform.Find("UI").gameObject;
        hpProgressBar = transform.Find("UI/HPProgressBar/ProgressBar").GetComponent<Image>();
        hpText = transform.Find("UI/HPProgressBar/HPText").GetComponent<TextMeshProUGUI>();
        levelProgressBar = transform.Find("UI/LevelProgressBar/ProgressBar").GetComponent<Image>();
        levelText = transform.Find("UI/LevelProgressBar/LevelText").GetComponent<TextMeshProUGUI>();
        propertyGrid = transform.Find("UI/PropertyGrid").gameObject;
        propertyTemplate = transform.Find("UI/PropertyGrid/PropertyTemplate").gameObject;
        weaponIcon = transform.Find("UI/WeaponIcon").GetComponent<Image>();
        propertyTemplate.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag(Tag.PLAYER); 
        pp = player.GetComponent<PlayerProperty>();
        pa = player.GetComponent<PlayerAttack>();
        UpdatePlayerPropertyUI();
        
    }

    private void Update(){

    }

    public void UpdatePlayerPropertyUI(){
        hpProgressBar.fillAmount = pp.hpValue / 100.0f;
        hpText.text = pp.hpValue + "/100";

        levelProgressBar.fillAmount = pp.currentExp*1.0f / (pp.level*30);
        levelText.text = pp.level.ToString();
        ClearGrid();
        AddProperty("Energy: " + pp.energyValue);
        AddProperty("Mental: " + pp.mentalValue);
        
        foreach(var item in pp.propertyDict){
            string propertyName = "";
          
                switch(item.Key){
                    case ItemPropertyType.HP:
                        propertyName = "HP: ";
                        break;
                    case ItemPropertyType.Energy:
                        propertyName = "Energy: ";
                        break;
                    case ItemPropertyType.Mental:
                        propertyName = "Mental: ";
                        break;
                    case ItemPropertyType.Speed:
                        propertyName = "Speed: ";
                        break;
                    
                }
                int sum = 0;
                foreach(var item1 in item.Value){
                    sum += item1.value;
                }
                AddProperty(propertyName + sum);

            if(pa.weaponIcon != null){
                weaponIcon.sprite = pa.weaponIcon;
            }
        }

    }

    private void ClearGrid(){
        foreach(Transform child in propertyGrid.transform){
            if(child.gameObject.activeSelf){
                Destroy(child.gameObject);
            }
        }
    }

    private void AddProperty(string propertyStr){
            GameObject go = GameObject.Instantiate(propertyTemplate);
            go.SetActive(true);
            go.transform.parent = propertyGrid.transform;
            go.transform.Find("Property").GetComponent<TextMeshProUGUI>().text = propertyStr;
    }

    private void Show(){
        uiGameObject.SetActive(true);
    }

    private void Hide(){
        uiGameObject.SetActive(false);
    }
}
