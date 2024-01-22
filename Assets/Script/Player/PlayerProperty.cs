using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperty : MonoBehaviour
{
    [SerializeField] private AudioClip damageSoundClip;
    public Dictionary<ItemPropertyType, List<ItemProperty>> propertyDict; 
    public int hpValue = 100;
    public int energyValue = 100;
    public int mentalValue = 100;
    public int level = 1;
    public int currentExp = 0;
    // Start is called before the first frame update
    void Awake()
    {
        propertyDict = new Dictionary<ItemPropertyType, List<ItemProperty>>();

        propertyDict.Add(ItemPropertyType.Speed, new List<ItemProperty>());
       

        AddProperty(ItemPropertyType.Speed, 5);
       
        EventCenter.OnEnemyDied += OnEnemyDied;
        
    }

    public void UseDrug(ItemSO itemSO){
        foreach(ItemProperty p in itemSO.propertyList){
            AddProperty(p.propertyType, p.value);
            PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();
        }
    }

    public void AddProperty(ItemPropertyType pt, int value){
        switch(pt){
            case ItemPropertyType.HP:
                hpValue += value;
                return;
            case ItemPropertyType.Energy:
                energyValue += value;
                return;
            case ItemPropertyType.Mental:
                mentalValue += value;
                return;
        }
        List<ItemProperty> list;
        propertyDict.TryGetValue(pt, out list);
        list.Add(new ItemProperty(pt, value));
        
    }

    public void RemoveProperty(ItemPropertyType pt, int value){
        switch(pt){
            case ItemPropertyType.HP:
                hpValue -= value;
                return;
            case ItemPropertyType.Energy:
                energyValue -= value;
                return;
            case ItemPropertyType.Mental:
                mentalValue-= value;
                return;
        }
        List<ItemProperty> list;
        propertyDict.TryGetValue(pt, out list);
        list.Remove(list.Find(x => x.value == value));
    }

    private void OnDestroy(){
        EventCenter.OnEnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy){
        this.currentExp += enemy.exp;
        if(currentExp >= level*30){
            currentExp -= level*30;
            level++;
        }
        PlayerPropertyUI.Instance.UpdatePlayerPropertyUI();
    }

    void Update(){
        OnPlayerDied();
    }

    private void OnPlayerDied(){
        if(hpValue <= 0){
            DiedUI.Instance.Show();
        }
    }
}
