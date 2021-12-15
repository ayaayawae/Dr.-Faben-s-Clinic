using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    // public Money moneyCs;
    // public GameObject moneyObj;

    private GameManager gameManagerCs;
    public GameObject gameManagerObj;

    public Text moneyPsText, moneyPlus, progressTime, moneyOnClick;

    // Start is called before the first frame update
    void Start()
    {
        // moneyCs = moneyObj.GetComponent<Money>();
        gameManagerCs = gameManagerObj.GetComponent<GameManager>();

        moneyPsText = this.transform.GetChild(0).GetComponent<Text>();
        moneyPlus = this.transform.GetChild(1).GetComponent<Text>();
        progressTime = this.transform.GetChild(2).GetComponent<Text>();
        moneyOnClick = this.transform.GetChild(3).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyPsText.text = "Money Per Second : " + gameManagerCs.moneyPerSecond.ToString();
        moneyPlus.text = "Money Plus : " + gameManagerCs.moneyPlus.ToString();
        progressTime.text = "ProgressTime : " + gameManagerCs.progressTime.ToString();
        moneyOnClick.text = "Money Per Click : " + gameManagerCs.moneyOnClick.ToString();
    }
}
