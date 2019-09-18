using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public List<Door> Doors;
    public static RoomManager Instance;

    public GameObject WorkerPrefab;
    public List<Worker> Workers;

    public float MinTimeSpawn = 60.0f;
    public float MaxTimeSpawn = 300.0f;
    public float TimeTillSpawn = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Doors = new List<Door>();
        TimeTillSpawn = Random.Range(MinTimeSpawn, MaxTimeSpawn);

        Workers = new List<Worker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SpawnWorker();
        }

        TimeTillSpawn -= Time.deltaTime;
        if(TimeTillSpawn <= 0f)
        {
            SpawnWorker();
            TimeTillSpawn = Random.Range(MinTimeSpawn, MaxTimeSpawn);
        }
    }

    public static void AddDoor(Door door)
    {
        Instance.Doors.Add(door);
    }

    private void SpawnWorker()
    {
        Worker worker = Instantiate(WorkerPrefab).GetComponent<Worker>();
        Door door = Doors[Random.Range(0, Doors.Count)];
        worker.transform.position = door.transform.parent.position + door.transform.forward * 1.0f;
    }
}
