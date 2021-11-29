using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    private Money moneyCs;
    public GameObject moneyObj;
    private Text moneyPsText, moneyPlus;

    // Start is called before the first frame update
    void Start()
    {
        moneyCs = moneyObj.GetComponent<Money>();
        moneyPsText = this.transform.GetChild(0).GetComponent<Text>();
        moneyPlus = this.transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyPsText.text = "Money Per Second : " + moneyCs.MoneyPerSecond.ToString();
        moneyPlus.text = "Money Plus : " + moneyCs.MoneyPlus.ToString();
    }
}
