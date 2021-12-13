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
    private int oldTotalRoom;
    private Button cardButton;
    private Image cardImageBg;
    private GameObject eventSystem;
    public GameObject gameManagerObj;
    private GameManager gameManagerCS;
    public GameObject menuUpgrade;

    public GameObject[] room;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerCS = gameManagerObj.GetComponent<GameManager>();
        eventSystem = GameObject.Find("EventSystem");
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
            Debug.Log(assetName);
        } else {
            Debug.Log("Uang Cukup");
            MoneyValue -= price;
            MoneyText.text = MoneyValue.ToString();
            switch(assetName){
                case "Tambah Kamar": upgradeTambahKamar(asset);
                break;
                
                case "Ruangan 1": StartCoroutine(upgradeLevelKamar(0));
                break;
                
                case "Ruangan 2": StartCoroutine(upgradeLevelKamar(1));
                break;
                
                case "Ruangan 3": StartCoroutine(upgradeLevelKamar(2));
                break;
                
                case "Ruangan 4": StartCoroutine(upgradeLevelKamar(3));
                break;
                
                case "Ruangan 5": StartCoroutine(upgradeLevelKamar(4));
                break;
                
                case "Ruangan 6": StartCoroutine(upgradeLevelKamar(5));
                break;
            
                case "Ruangan 7": StartCoroutine(upgradeLevelKamar(6));
                break;

                case "Ruangan 8": StartCoroutine(upgradeLevelKamar(7));
                break;
            }

            // if(assetName == "Tambah Kamar") {
            //     upgradeTambahKamar(asset);
            // } else if(assetName == "Ruangan 1") {

            // }
        }
    }

    IEnumerator unlockRoom(){
        Animator anim = menuUpgrade.GetComponent<Animator>();
        anim.SetBool("isMenuShow", false);
        oldTotalRoom = gameManagerCS.totalRoom-1;
        gameManagerCS.totalRoom += 1;

        eventSystem.SetActive(false);
        yield return new WaitForSeconds(0.8f); 
        roomCover[oldTotalRoom].GetComponent<Animator>().SetTrigger("unlock");
        yield return new WaitForSeconds(2f);
        eventSystem.SetActive(true);
        roomCover[oldTotalRoom].SetActive(false);
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

    void upgradeTambahKamar(GameObject asset) {
        if(gameManagerCS.totalRoom < 8){
            StartCoroutine(unlockRoom());
            gameManagerCS.moneyPerSecond += 5;
            if(gameManagerCS.totalRoom == 8) {
                disableCard(asset); 
            }
        }
    }

    void disableCard(GameObject asset) {
        cardButton = asset.GetComponent<Button>();
        cardButton.interactable = false;

        cardImageBg = asset.transform.GetChild(0).GetComponent<Image>();
        cardImageBg.color = Color.gray;
    }

    IEnumerator upgradeLevelKamar(int idKamar){ //0
        int level = gameManagerCS.roomLevel[idKamar];

        if(level < 3 && gameManagerCS.totalRoom >= idKamar+1){
            Debug.Log("sini");
            eventSystem.SetActive(false);
            Animator anim = menuUpgrade.GetComponent<Animator>();
            anim.SetBool("isMenuShow", false);
            room[idKamar].transform.GetChild(level-1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            room[idKamar].transform.GetChild(level-1).gameObject.GetComponent<Animator>().SetTrigger("fall");
            gameManagerCS.roomLevel[idKamar] += 1;
            eventSystem.SetActive(true);
        }else{
            Debug.Log("Ruangan belum terbuka atau sudah mentok level");
        }
    }
    // int getLevelKamar(int idKamar){
    //     int getLevel = gameManagerCS.roomLevel[idKamar];
    //     return getLevel;
    // }
}
