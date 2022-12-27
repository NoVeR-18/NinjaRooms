using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField]
    private Item Helmet;
    [SerializeField]
    private Item Cloack;
    [SerializeField]
    private Item Armor;
    [SerializeField]
    private Item Weapon;
    [SerializeField]
    private Item Leggings;
    [SerializeField]
    private Item Shoes;

    private ItemData itemsData = new ItemData();

    private string path;

    private void Start()
    {
        path = Application.dataPath + "/Items/";
    }
    public void Name(string name, int Id)
    {
        string dataAsJson;
        dataAsJson = File.ReadAllText(path + name + ".json");
        itemsData = JsonUtility.FromJson<ItemData>(dataAsJson);
        switch (name)
        {
            case "Helmet":

                //Helmet = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Helmet"+Id+".json"));
                Helmet = itemsData.items[Id];
                break;
            case "Cloak":
                Cloack = itemsData.items[Id];
                break;
            case "Armor":
                Armor = itemsData.items[Id];
                break;
            case "Weapon":
                Weapon = itemsData.items[Id];
                break;
            case "Leggings":
                Leggings = itemsData.items[Id];
                break;
            case "Shoes":
                Shoes = itemsData.items[Id];
                break;
        }


    }


}
