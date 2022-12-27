using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    static public int maxHealth = 100;
    static public int curHealth = 100;
    public int Hp; 
    void Start()
    {
        
    }
    void Update()
    {
        Hp = curHealth;
        if (curHealth > maxHealth)
            curHealth = maxHealth;
    }

    public void AddjustCurrentHealth(int adj)
    {
        curHealth -= adj; if (curHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
}
