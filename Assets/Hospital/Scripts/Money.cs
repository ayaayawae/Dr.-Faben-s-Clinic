using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private int MoneyValue;
    public int MoneyPlus = 1;
    public int DelayAmount = 1;
    public Text MoneyText;

    protected float Timer;

    // Start is called before the first frame update
    void Start()
    {
        // MoneyValue = int.Parse(MoneyText.text);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if(Timer >= DelayAmount) {
            Timer = 0f;
            MoneyValue = int.Parse(MoneyText.text);
            MoneyValue += MoneyPlus;
            MoneyText.text = MoneyValue.ToString();
        }
    }
}
