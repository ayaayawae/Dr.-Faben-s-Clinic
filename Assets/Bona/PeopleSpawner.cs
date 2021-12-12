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


    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSpawns = gameManagerObj.GetComponent<GameManager>().timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if(timeSinceLastSpawn >= timeBetweenSpawns) {
            timeSinceLastSpawn -= timeBetweenSpawns;
            SpawnPeople();
            i++;
        }
    }

    void SpawnPeople()
    {
        int tmp = Random.Range(0, 7);
        GameObject prefab = people[tmp];
        GameObject spawn = Instantiate<GameObject>(prefab);
        spawn.name = "People " + i;
        spawn.SetActive(true);
        spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
    }

    public void spawnTimeChange()
    {
        // timeBetweenSpawns = spawnSlider.value;
    }
}