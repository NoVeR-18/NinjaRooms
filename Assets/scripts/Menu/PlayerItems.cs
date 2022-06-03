using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    private Item Helmet;
    private Item Cloack;
    private Item Armor;
    private Item Weapon;
    private Item Leggings;
    private Item Shoes;

     
    public void Name(string name, int Id)
    {
        switch (name)
        {
            case "Helmet":
                Helmet= JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Helmet"+Id+".json"));

                break;
            case "Cloack":
                Helmet= JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Cloack" + Id+".json"));
                break;
            case "Armor":
                Helmet= JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Armor" + Id+".json"));
                break;
            case "Weapon":
                Helmet= JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Weapon" + Id+".json"));
                break;
            case "Leggings":
                Helmet= JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Leggings" + Id+".json"));
                break;
            case "Shoes":
                Helmet= JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/Shoes" + Id+".json"));
                break;
        }


    }


}
