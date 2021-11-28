using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleSpawner : MonoBehaviour
{
    float timeBetweenSpawns = 3.0f;
    float spawnDistance = 0.0f;
    public GameObject[] people;
    public
    float timeSinceLastSpawn;
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
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
        GameObject prefab = people[0];
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