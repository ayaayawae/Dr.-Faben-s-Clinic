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
    private int price;
    public Text MoneyText;
    private string assetName;
    public GameObject[] roomCover;

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
            if(gameManagerCS.totalRoom != 8){
                StartCoroutine(unlockRoom());
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
    
    // IEnumerator fadeRoomAnimation(){
    //     for(float i = 1.0f; i > 0; i -= 0.1f){
    //         roomCover[gameManagerCS.totalRoom-1].transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, i);
    //         Debug.Log(i);
    //         yield return new WaitForSeconds(0.5f);
    //     }
    //     roomCover[gameManagerCS.totalRoom-1].SetActive(false);
    //     gameManagerCS.totalRoom += 1;
    // }
}
