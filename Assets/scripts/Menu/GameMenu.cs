using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenu : Plate
{
    [SerializeField]
    private GameObject Menu;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E))
        {
            Menu.SetActive(true);
        }
    }
}
