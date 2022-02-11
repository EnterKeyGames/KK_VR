using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    [SerializeField] public static string name;
    [SerializeField] public Type type;
    [SerializeField] public string information;
    [SerializeField] public Sprite sprite;
    [SerializeField] public static int pickPoint;
    [SerializeField] public GameObject itemIcon;
    [SerializeField] public GameObject itemObject;

    public enum Type
    {
        ConsumptionItems,
        ImportantItems,
    }
    public Type GetType()
    {
        return type;
    }

    public string GetInfo()
    {
        return information;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public int PickItemPoint()
    {
        Debug.Log(pickPoint);
        return pickPoint;

    }
    public int PcikItemPointPlus()
    {
        Debug.Log(pickPoint);
        pickPoint++;
        return pickPoint;

    }

    public object ItemIconGet()
    {
        return itemIcon;
    }

    public object ItemObjectGet()
    {
        return itemObject;
    }

}

