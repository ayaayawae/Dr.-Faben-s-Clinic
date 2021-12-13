using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public int MoneyValue;
    public int MoneyPlus;
    public int MoneyPerSecond;
    public int DelayAmount = 1;
    public Text MoneyText;
    public GameObject[] roomCover;
    private int price;
    private string assetName;

    protected float Timer;
    private int totalRoom;
    public GameObject gameManagerObj;
    private GameManager gameManagerCS;
    public GameObject menuUpgrade;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerCS = gameManagerObj.GetComponent<GameManager>();
        // MoneyValue = int.Parse(MoneyText.text);
        
    }

    // Update is called once per frame
    void Update()
    {
        increaseMoneyPS();
    }

    public void upgradeAsset(GameObject asset) {
        assetName = asset.transform.GetChild(0).GetChild(1).GetComponent<Text>().text.ToString();
        price = int.Parse(asset.transform.GetChild(0).GetChild(4).GetComponent<Text>().text.ToString());
        
        if(MoneyValue < price) {
            Debug.Log("Uang tidak Cukup");
        } else {
            Debug.Log("Uang Cukup");
            MoneyValue -= price;
            MoneyText.text = MoneyValue.ToString();
            if(assetName == "Tambah Kamar") {
                upgradeTambahKamar();
            } 
            
        }
    }

    IEnumerator unlockRoom(){
        Animator anim = menuUpgrade.GetComponent<Animator>();
        anim.SetBool("isMenuShow", false);
        yield return new WaitForSeconds(1.5f);
        roomCover[gameManagerCS.totalRoom-1].GetComponent<Animator>().SetTrigger("unlock");
        yield return new WaitForSeconds(2f);
        roomCover[gameManagerCS.totalRoom-1].SetActive(false);
        gameManagerCS.totalRoom += 1;
    }

    void increaseMoneyPS() {
        Timer += Time.deltaTime;

        if(Timer >= DelayAmount) {
            Timer = 0f;
            MoneyValue = int.Parse(MoneyText.text);
            MoneyValue += MoneyPerSecond;
            MoneyText.text = MoneyValue.ToString();
        }
    }

    void upgradeTambahKamar() {
        if(gameManagerCS.totalRoom != 8){
            StartCoroutine(unlockRoom());
        }
        gameManagerCS.moneyPerSecond += 5;
    }
}
