using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.IO;

public class ItemSupport : EditorWindow
{
    public Item item = new Item();
    public string Equipment;

    private ItemData itemsData = new ItemData();
    private string path;

    //public int ID ;
    //public bool Unlock = false;
    //public string Name;
    //private int Vitality;
    //public int Mana;
    //public int Damage;
    //public float Speed;
    //public Sprite SourceImage;
    //public string Description;

    [MenuItem("Inventory/Add")]
    public static void AddItem(MenuCommand command)
    {
        UnityEditor.EditorWindow window = GetWindow(typeof(ItemSupport));
        const int width = 500;
        const int height = 350;
        Vector2 size = new Vector2(width, height);
        window.minSize = size;
        window.position = new Rect(0, 0, width, height);
        window.Show();
    }

    void OnGUI()
    {
        path = Application.dataPath + "/Items/";
        Equipment = EditorGUILayout.TextField("Equipment", Equipment);
        item.ID = EditorGUILayout.IntField("Id", item.ID);
        item.Unlock = EditorGUILayout.Toggle("Unlock", item.Unlock);
        item.Name = EditorGUILayout.TextField("Name", item.Name);
        item.Vitality = EditorGUILayout.IntField("Vitality", item.Vitality);
        item.Mana = EditorGUILayout.IntField("Mana", item.Mana);
        item.Damage = EditorGUILayout.IntField("Damage", item.Damage);
        item.Speed = EditorGUILayout.FloatField("Speed", item.Speed);
        item.SourceImage = (Sprite)EditorGUILayout.ObjectField("SourceImage", item.SourceImage, typeof(Sprite), false);
        item.Description = EditorGUILayout.TextField("Description", item.Description);
        if (GUILayout.Button("SaveImage"))
        {
            if (Check())
            {
                SaveImage();
            }
        }
        if (GUILayout.Button("Save All"))
        {
            if (Check())
            {
                SaveAll();
            }
        }
    }
    private bool Check()
    {
        if (string.IsNullOrEmpty(Equipment))
        {
            Debug.Log("Insert a name for the item");
            return false;
        }
        else if (!Equipment.Equals("Armor") && !Equipment.Equals("Helmet") && !Equipment.Equals("Cloak") 
            && !Equipment.Equals("Weapon") && !Equipment.Equals("Legging") && !Equipment.Equals("Shoes"))
        {
            Debug.Log("Incorect Equipment");
            return false;
        }
        else if (item.SourceImage == null)
        {
            Debug.Log("Insert an image to create the item");
            return false;
        }
        else if (item.ID < 0)
        {
            Debug.Log("Insert a ID for the item");
            return false;
        }
        else if (Equipment.Equals("Name"))
        {
            Debug.Log("Insert a name for the item");
            return false;
        }
        return true;
    }



    private void SaveImage()
    {
        string dataAsJson;
        dataAsJson = File.ReadAllText(path + Equipment + ".json");
        Debug.Log(dataAsJson);
        itemsData = JsonUtility.FromJson<ItemData>(dataAsJson);
        File.WriteAllText(path + Equipment + "1.json", dataAsJson);
        if (item.ID < itemsData.items.Length)
        {
            itemsData.items[item.ID].SourceImage = item.SourceImage;
            dataAsJson = JsonUtility.ToJson(itemsData, true);
            File.WriteAllText(path + Equipment + ".json", dataAsJson);
            Debug.Log("Done");
        }
    }
    private void SaveAll()
    {
        string dataAsJson;
        dataAsJson = File.ReadAllText(path + Equipment + ".json");
        Debug.Log(dataAsJson);
        itemsData = JsonUtility.FromJson<ItemData>(dataAsJson);
        File.WriteAllText(path + Equipment + "1.json", dataAsJson);
        if (item.ID < itemsData.items.Length) {
            itemsData.items[item.ID] = item;
            dataAsJson = JsonUtility.ToJson(itemsData, true);
            File.WriteAllText(path +Equipment +".json", dataAsJson);
            Debug.Log("Done");
        }
        else
        {
            Debug.Log("ID out of items count");
        }

    }
}
