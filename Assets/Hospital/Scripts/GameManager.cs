using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject moneyObj;
    public int moneyValue, moneyPlus, moneyPerSecond;

    public GameObject peopleSpawnerObj;
    public float timeBetweenSpawns;

    // private PeopleSpawner peopleSpawnerCs;
    private Money moneyCs;

    public int totalRoom = 9;


    // Start is called before the first frame update
    void Start()
    {
        moneyCs = moneyObj.GetComponent<Money>();
        // peopleSpawnerCs = peopleSpawnerObj.GetComponent<PeopleSpawner>();

        moneyValue = moneyCs.MoneyValue;
        moneyPlus = moneyCs.MoneyPlus;
        moneyPerSecond = moneyCs.MoneyPerSecond;

        // timeBetweenSpawns = peopleSpawnerCs.timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        moneyManager();
        peopleSpawnerManager();
    }

    void moneyManager() {
        moneyValue = moneyCs.MoneyValue;
        // moneyPlus = moneyCs.MoneyPlus;
        // moneyPerSecond = moneyCs.MoneyPerSecond;
        moneyCs.MoneyValue = moneyValue;
        moneyCs.MoneyPlus = moneyPlus;
        moneyCs.MoneyPerSecond = moneyPerSecond;
    }

    void peopleSpawnerManager() {
        // peopleSpawnerCs.timeBetweenSpawns = timeBetweenSpawns;
    }
}
