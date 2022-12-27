using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/*public class Item
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Value { get; set; }
    public int Power { get; set; }
    public int Defense { get; set; }
    public int Vitality { get; set; }
    public string Description 
    public bool Stackable { get; set; }
    public int Rarity { get; set; }
    public string Slug { get; set; }
    public Sprite Sprite { get; set; }

    
}*/
[Serializable]
public class Item
{
    public int ID;
    public bool Unlock;
    public string Name;
    public int Vitality;
    public int Mana;
    public int Damage;
    public float Speed;
    public Sprite SourceImage;
    public string Description;
}


[Serializable]
public class ItemData
{
    public Item[] items;
}
/*
 
 "id": 14,
    "Unlock": false,
    "Name": "kimano",
    "stats": {
      "Healt": 70,
      "Mana": 20,
      "Damage": 0,
      "Speed": 10.0
    },
    "SourceImage": { "instanceID": 15172 },
    "description": ""
 
 */
