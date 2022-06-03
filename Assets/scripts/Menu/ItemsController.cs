
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsController : MonoBehaviour
{
    [SerializeField]
    PlayerItems playerItems;
    [SerializeField]
    private Button[] _navigation = new Button[6]; 
    [SerializeField]
    private Button[] _items = new Button[15];
    [SerializeField]
    private Text _description;

    private string _itemName;
    private void Start()
    {
        Debug.Log(Application.dataPath);
        Click("Helmet");
    }
    public void Click(string ItemName)
    {
        _itemName = ItemName;
        Item item;
        for (int i = 0; i < _items.Length; i++)
        {
            item = JsonUtility.FromJson<Item>(File.ReadAllText(Application.dataPath + "/Items/" + ItemName + i + ".json"));
            _items[i].image.sprite = item.SourceImage;
            _items[i].name = item.Name;
            if(item.Unlock == false)
            {
                _items[i].interactable = false;
            }
        }
    }
    public void ItemClick(int ID)
    {
        playerItems.Name(_itemName, ID);

    }


}
