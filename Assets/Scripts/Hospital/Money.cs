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
    private string priceText;
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
            switch(assetName){
                case "Tambah Kamar": upgradeTambahKamar(asset, price);
                break;
                
                case "Ruangan 1": StartCoroutine(upgradeLevelKamar(0, price, asset));
                break;
                
                case "Ruangan 2": StartCoroutine(upgradeLevelKamar(1, price, asset));
                break;
                
                case "Ruangan 3": StartCoroutine(upgradeLevelKamar(2, price, asset));
                break;
                
                case "Ruangan 4": StartCoroutine(upgradeLevelKamar(3, price, asset));
                break;
                
                case "Ruangan 5": StartCoroutine(upgradeLevelKamar(4, price, asset));
                break;
                
                case "Ruangan 6": StartCoroutine(upgradeLevelKamar(5, price, asset));
                break;
            
                case "Ruangan 7": StartCoroutine(upgradeLevelKamar(6, price, asset));
                break;

                case "Ruangan 8": StartCoroutine(upgradeLevelKamar(7, price, asset));
                break;
            }
            MoneyText.text = MoneyValue.ToString();
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

    void upgradeTambahKamar(GameObject asset, int price) {
        if(gameManagerCS.totalRoom < 8){
            MoneyValue -= price;
            StartCoroutine(unlockRoom());

            priceText = asset.transform.GetChild(0).GetChild(4).GetComponent<Text>().text;
            price = int.Parse(priceText.ToString());
            price *= 2;

            //increase price
            asset.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = price.ToString();

            //increase level
            asset.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = "Level : " + gameManagerCS.totalRoom.ToString();

            enableCard(asset);
            
            // gameManagerCS.moneyPerSecond += 5;

            if(gameManagerCS.totalRoom == 8) {
                asset.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Text>().text = "Level : MAX";
                asset.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = "MAX";
                maxCard(asset); 
            }
        }
    }

    void disableCard(GameObject asset) {
        cardButton = asset.GetComponent<Button>();
        cardButton.interactable = false;

        cardImageBg = asset.transform.GetChild(0).GetComponent<Image>();
        cardImageBg.color = Color.gray;
    }

    void enableCard(GameObject asset) {
        cardButton = asset.transform.parent.GetChild(gameManagerCS.totalRoom + 1).GetComponent<Button>();
        cardButton.interactable = true;

        cardImageBg = asset.transform.parent.GetChild(gameManagerCS.totalRoom + 1).GetChild(0).GetComponent<Image>();
        cardImageBg.color = new Color(1f, 0.5f, 0.5f, 1f);
    }

    void maxCard(GameObject asset) {
        cardButton = asset.GetComponent<Button>();
        cardButton.interactable = false;

        cardImageBg = asset.transform.GetChild(0).GetComponent<Image>();
        cardImageBg.color = new Color(0f, 0.7f, 0f, 1f);
    }
    

    IEnumerator upgradeLevelKamar(int idKamar, int price, GameObject asset){ //0
        int level = gameManagerCS.roomLevel[idKamar];

        if(level < 3 && gameManagerCS.totalRoom >= idKamar+1){
            Debug.Log("sini");
            MoneyValue -= price; 

            eventSystem.SetActive(false);
            Animator anim = menuUpgrade.GetComponent<Animator>();
            anim.SetBool("isMenuShow", false);
            room[idKamar].transform.GetChild(level-1).gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            room[idKamar].transform.GetChild(level-1).gameObject.GetComponent<Animator>().SetTrigger("fall");
            gameManagerCS.roomLevel[idKamar] += 1;
            eventSystem.SetActive(true);

            if(gameManagerCS.roomLevel[idKamar] == 3) {
                maxCard(asset);
                asset.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = "MAX";
            }
        }else{
            Debug.Log("Ruangan belum terbuka atau sudah mentok level");
        }
    }
    // int getLevelKamar(int idKamar){
    //     int getLevel = gameManagerCS.roomLevel[idKamar];
    //     return getLevel;
    // }
}
