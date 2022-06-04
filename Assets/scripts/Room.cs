using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject DoorU;
    public GameObject DoorR;
    public GameObject DoorD;
    public GameObject DoorL;

    public Mesh[] BlockMeshes;
    public Vector2Int size;
    public Room[] rooms;
    public Vector2Int possition;
    public int RoomID;
    private void Start()
    {
        foreach (var filter in GetComponentsInChildren<MeshFilter>())
        {
            if (filter.sharedMesh == BlockMeshes[0])
            {
                filter.sharedMesh = BlockMeshes[Random.Range(0, BlockMeshes.Length)];
                filter.transform.rotation = Quaternion.Euler(-90, 0, 90 * Random.Range(0, 4));
            }
        }
    }

}
