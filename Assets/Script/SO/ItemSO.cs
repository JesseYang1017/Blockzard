using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    public int id;
    public string name;
    public ItemType itemType;
    public string description;
    public List<ItemProperty> propertyList;
    public Sprite icon;
    public GameObject prefab;
}

public enum ItemType{
    Weapon,
    Consumable
}

[Serializable]
public class ItemProperty{
    public ItemPropertyType propertyType;
    public int value;
    public ItemProperty(){

    }

    public ItemProperty(ItemPropertyType propertyType, int value){
        this.propertyType = propertyType;
        this.value = value;
    }
}


public enum ItemPropertyType{
    HP,
    Energy,
    Mental,
    Speed,
    Attack

}