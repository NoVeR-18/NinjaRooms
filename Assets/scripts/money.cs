using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public int _money;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerCash.Money += _money;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCash>().TextMoney.text = PlayerCash.Money.ToString();
            Destroy(gameObject); // удаление монеты с данной игровой сцены 
        }
    }
}
