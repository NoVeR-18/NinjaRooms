using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCash : MonoBehaviour
{

    static public int Money;
    [SerializeField] 
    public Text TextMoney;
    // Start is called before the first frame update
    void Start()
    {
        Money = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
