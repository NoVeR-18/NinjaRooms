using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    [SerializeField]
    GameObject GameObject;
    bool active;
    void Update()
    {
            GameObject.SetActive(active);
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            active = true;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.tag == "Player")
        {
            active = false;
        }
    }

}
