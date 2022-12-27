using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RoomPlacer : MonoBehaviour
{
    public Room[] RoomPrefabs;
    public Room StartingRoom;

    [SerializeField]
    private int _roomCount = 30;
    private Room[,] spawnedRooms;

    private IEnumerator Start()
    {
        spawnedRooms = new Room[30, 30];
        spawnedRooms[14, 14] = StartingRoom;

        for (int i = 0; i < _roomCount; i++)
        {
            // Это вот просто убрать чтобы подземелье генерировалось мгновенно на старте
            yield return new WaitForSecondsRealtime(0.1f);
            RoomPlace();
            //PlaceOneRoom();
        }
        Debug.Log("Done");
        ConnectRooms();
    }

    private void PlaceOneRoom()
    {
        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;
                int maxY = spawnedRooms.GetLength(1) - 1;

                if (x > 0 && spawnedRooms[x - 1, y] == null) vacantPlaces.Add(new Vector2Int(x - 1, y));
                if (y > 0 && spawnedRooms[x, y - 1] == null) vacantPlaces.Add(new Vector2Int(x, y - 1));
                if (x < maxX && spawnedRooms[x + 1, y] == null) vacantPlaces.Add(new Vector2Int(x + 1, y));
                if (y < maxY && spawnedRooms[x, y + 1] == null) vacantPlaces.Add(new Vector2Int(x, y + 1));
            }
        }

        // Эту строчку можно заменить на выбор комнаты с учётом её вероятности, вроде как в ChunksPlacer.GetRandomChunk()
        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

        int limit = 500;
        while (limit-- > 0)
        {
            // Эту строчку можно заменить на выбор положения комнаты с учётом того насколько он далеко/близко от центра,
            // или сколько у него соседей, чтобы генерировать более плотные, или наоборот, растянутые данжи
            Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));

            if (ConnectToSomething(newRoom, position))
            {
                newRoom.transform.position = new Vector3(position.x * 25, (position.y - 5)*21);
                spawnedRooms[position.x, position.y] = newRoom;
                return;
            }
        }

    }

    private bool ConnectToSomething(Room room, Vector2Int p)
    {
        int maxX = spawnedRooms.GetLength(0) - 1;
        int maxY = spawnedRooms.GetLength(1) - 1;

        List<Vector2Int> neighbours = new List<Vector2Int>();

        if (room.DoorU != null && p.y < maxY && spawnedRooms[p.x, p.y + 1]?.DoorD != null) neighbours.Add(Vector2Int.up);
        if (room.DoorD != null && p.y > 0 && spawnedRooms[p.x, p.y - 1]?.DoorU != null) neighbours.Add(Vector2Int.down);
        if (room.DoorR != null && p.x < maxX && spawnedRooms[p.x + 1, p.y]?.DoorL != null) neighbours.Add(Vector2Int.right);
        if (room.DoorL != null && p.x > 0 && spawnedRooms[p.x - 1, p.y]?.DoorR != null) neighbours.Add(Vector2Int.left);

        if (neighbours.Count == 0) return false;

        Vector2Int selectedDirection = neighbours[Random.Range(0, neighbours.Count)];
        Room selectedRoom = spawnedRooms[p.x + selectedDirection.x, p.y + selectedDirection.y];

        if (selectedDirection == Vector2Int.up)
        {
            room.DoorU.SetActive(false);
            selectedRoom.DoorD.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.down)
        {
            room.DoorD.SetActive(false);
            selectedRoom.DoorU.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.right)
        {
            room.DoorR.SetActive(false);
            selectedRoom.DoorL.SetActive(false);
        }
        else if (selectedDirection == Vector2Int.left)
        {
            room.DoorL.SetActive(false);
            selectedRoom.DoorR.SetActive(false);
        }

        return true;
    }



    private void RoomPlace()
    {
        Room newRoom = Instantiate(RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]);

        HashSet<Vector2Int> vacantPlaces = new HashSet<Vector2Int>();
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if (spawnedRooms[x, y] == null) continue;

                int maxX = spawnedRooms.GetLength(0) - 1;// newRoom.size.x;
                int maxY = spawnedRooms.GetLength(1) - 1;// - newRoom.size.y;

                
                if (x - newRoom.size.x  + 1 > 0 && spawnedRooms[x - newRoom.size.x, y] == null)
                {
                    if (checker(new Vector2Int(x, y), new Vector2Int(-newRoom.size.x, 0)))
                        vacantPlaces.Add(new Vector2Int(x - newRoom.size.x, y));
                }

                if (y - newRoom.size.y + 1 > 1 && spawnedRooms[x, y - newRoom.size.y] == null)
                {
                    if (checker(new Vector2Int(x, y), new Vector2Int(0, -newRoom.size.y)))
                        vacantPlaces.Add(new Vector2Int(x, y - newRoom.size.y));
                }

                if (x + newRoom.size.x < maxX && spawnedRooms[x + 1, y] == null)
                {
                    if (checker(new Vector2Int(x, y), new Vector2Int(1, 0)))
                        vacantPlaces.Add(new Vector2Int(x + 1, y));
                }

                if (y + newRoom.size.y < maxY && spawnedRooms[x, y + 1] == null)
                {
                    if (checker(new Vector2Int(x, y), new Vector2Int(0, 1)))
                        vacantPlaces.Add(new Vector2Int(x, y + 1));
                }
                
            }
        }
        bool checker(Vector2Int possition, Vector2Int multiply)
        {
            for (int i = 0; i < newRoom.size.x; i++)
            {
                for (int j = 0; j < newRoom.size.y; j++)
                {
                    
                    try
                    {
                        if (spawnedRooms[possition.x + i + multiply.x, possition.y + j + multiply.y] != null)
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }

                }
            }
            return true;
        }


        Vector2Int position = vacantPlaces.ElementAt(Random.Range(0, vacantPlaces.Count));
        newRoom.possition = position;
        newRoom.transform.position = new Vector3(position.x * 25, (position.y - 5) * 21);

        int num = 0;
        for(int i=0;i<newRoom.size.x;i++)
        {
            for (int j = 0; j < newRoom.size.y; j++)
            {
                Room room = newRoom.rooms[num];
                spawnedRooms[position.x + i, position.y + j] = room;
                newRoom.rooms[num].possition = new Vector2Int(position.x + i, position.y + j);
                num++;
                //Destroy(newRoom.gameObject);
                
            }
        }

    }

    private void ConnectRooms()
    {
        for (int x = 0; x < spawnedRooms.GetLength(0); x++)
        {
            for (int y = 0; y < spawnedRooms.GetLength(1); y++)
            {
                if(spawnedRooms[x, y]!=null)
                    ConnectToSomething(spawnedRooms[x, y], new Vector2Int(x, y));
            }
        }
    }

    private void RoomChanse()
    {

    }
}
