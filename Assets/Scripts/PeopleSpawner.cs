using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class PeopleSpawner : MonoBehaviour
{
    private float timeBetweenSpawns;
    float spawnDistance = 0.0f;
    public GameObject[] people;
    float timeSinceLastSpawn;
    private int i = 0;
    public GameObject gameManagerObj;
    private int totalRoom;

    private GameManager gameManagerCs;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerCs = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeBetweenSpawns = gameManagerObj.GetComponent<GameManager>().timeBetweenSpawns;

    }
    
    void FixedUpdate()
    {
        timeBetweenSpawns = gameManagerObj.GetComponent<GameManager>().timeBetweenSpawns;
        totalRoom = gameManagerCs.totalRoom + 1;
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= timeBetweenSpawns) {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnPeople();
            i++;
        }
    }

    void SpawnPeople()
    {
        int room = Random.Range(1, totalRoom);
        if(checkRoom(room)){
            int peopleType = Random.Range(0, 7);
            GameObject prefab = people[peopleType];
            GameObject spawn = Instantiate<GameObject>(prefab);
            spawn.name = "People " + room;
            spawn.SetActive(true);
            spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
        }
        
    }

    public void spawnTimeChange()
    {
        // timeBetweenSpawns = spawnSlider.value;
    }

    bool checkRoom(int room){
        if(gameManagerCs.roomIsFilled[room-1] == 0){
            gameManagerCs.roomIsFilled[room-1] = 1;
            return true;
        }else{
            return false;
        }
    }
}