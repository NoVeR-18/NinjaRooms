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
    private Button[] _itemsBtn = new Button[15];
    [SerializeField]
    private Text _description;
    [SerializeField]
    private Text _statsText;


    private string _itemName;
    private ItemData items;
    private string path;
    private ItemData itemsData = new ItemData();
    private void Start()
    {
        path = Application.dataPath + "/Items/";
        Click("Helmet");
    }
    public void Click(string ItemName)
    {
        _itemName = ItemName;
        LoadItems(ItemName);
        for (int i = 0; i < _itemsBtn.Length; i++)
        {
            //_itemsBtn[i].image.sprite = item[i].SourceImage;
            //_itemsBtn[i].name = item[i].Name;
            //if(item.Unlock == false)
            //{
            //    _itemsBtn[i].interactable = false;
            //}
        }
    }
    public void Unlock(int Id) { }

    public void LoadItems(string ItemName)
    {
        string dataAsJson;
        dataAsJson = File.ReadAllText(path + ItemName + ".json");
        itemsData = JsonUtility.FromJson<ItemData>(dataAsJson); 
        for (int i = 0; i < _itemsBtn.Length; i++)
        {
            ChangeItemInfo(i);
        }
    }
    private void ChangeItemInfo(int ID)
    {
        _itemsBtn[ID].name = itemsData.items[ID].ID +  itemsData.items[ID].Name;
        _itemsBtn[ID].image.sprite = itemsData.items[ID].SourceImage;
        #region unlock
        if (itemsData.items[ID].Unlock == false)
        {
            _itemsBtn[ID].interactable = false;
        }
        else
        {
            _itemsBtn[ID].interactable = true;
        }
        #endregion
        //_itemsBtn[i].image.sprite = path + "UI"+ ItemName + i + ".png";
    }
    public void ItemClick(int ID)
    {
        _description.text = itemsData.items[ID].Description;
        Debug.Log(itemsData.items[ID].Vitality);
        _statsText.text = "Vitality: " + itemsData.items[ID].Vitality + "\n" 
            + "Mana: " + itemsData.items[ID].Mana + "\n"
            + "Damage: " + itemsData.items[ID].Damage + "\n"
            + "Speed: " + itemsData.items[ID].Speed ;
        //playerItems.Name(_itemName, ID);

    }


}
