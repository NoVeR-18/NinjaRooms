using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsCreator : MonoBehaviour
{

    [SerializeField]
    private Sprite image1;
    [SerializeField]
    private Sprite image2;

    public Item[] Helmet = new Item[16];
    public Item[] Cloack = new Item[16];
    public Item[] Armor = new Item[16];
    public Item[] Weapon = new Item[16];
    public Item[] Leggings = new Item[16];
    public Item[] Shoes = new Item[16];

    string json;
    private void Start()
    {
        Test();
    }
    private void Test()
    {
        Helmet[0].Unlock = true;
        Helmet[0].Name = "Helmet";
        Helmet[0].Healt = 100;
        Helmet[0].Mana = 50;
        Helmet[0].Speed = 0;
        Helmet[0].SourceImage = image1;

        Helmet[1].Unlock = false;
        Helmet[1].Name = "kimano";
        Helmet[1].Healt = 70;
        Helmet[1].Mana = 20;
        Helmet[1].Speed = 10;
        Helmet[1].SourceImage = image2;

        Helmet[2].Unlock = false;
        Helmet[2].Name = "armor";
        Helmet[2].Healt = 10;
        Helmet[2].Mana = 10;
        Helmet[2].Speed = 0;
        Helmet[3].SourceImage = image1;


        Helmet[3].Unlock = true;
        Helmet[3].Name = "Shoes";
        Helmet[3].Healt = 10;
        Helmet[3].Mana = 10;
        Helmet[3].Speed = 0;
        Helmet[3].SourceImage = image2;

        json = JsonUtility.ToJson(Helmet[0]);
        File.WriteAllText(Application.dataPath + "/Items/Helmet"+ 0 +".json", json);
        json = JsonUtility.ToJson(Helmet[1]);
        File.WriteAllText(Application.dataPath + "/Items/Helmet" + 1 + ".json", json);
        json = JsonUtility.ToJson(Helmet[2]);
        File.WriteAllText(Application.dataPath + "/Items/Helmet" + 2 + ".json", json);
        json = JsonUtility.ToJson(Helmet[3]);
        File.WriteAllText(Application.dataPath + "/Items/Helmet" + 3 + ".json", json);
        json = JsonUtility.ToJson(Helmet[3]);
        File.WriteAllText(Application.dataPath + "/Items/Helmet" + 4 + ".json", json);
        json = JsonUtility.ToJson(Helmet[3]);
        File.WriteAllText(Application.dataPath + "/Items/Helmet" + 5 + ".json", json);
    }

    private void HelmetCreator()
    {

        Helmet[0] = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Helmet.json"));
    }
    private void CloackCreator()
    {

        //item2 = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "Items/Cloack.json"));
    }
    private void ArmorCreator()
    {

        //item2 = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "Items/Armor.json"));
    }
    private void WeaponCreator()
    {

        //item2 = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "Items/Weapon.json"));
    }
    private void LeggingsCreator()
    {
        //item2 = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "Items/Legging.json"));

    }
    private void ShoesCreator()
    {
        //item2 = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "Items/Shoes.json"));

    }




}
