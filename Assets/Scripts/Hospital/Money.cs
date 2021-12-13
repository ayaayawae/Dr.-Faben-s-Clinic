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
    private int totalRoom, oldTotalRoom;
    private Button cardButton;
    private Image cardImageBg;
    private GameObject eventSystem;
    public GameObject gameManagerObj;
    private GameManager gameManagerCS;
    public GameObject menuUpgrade;


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
            if(assetName == "Tambah Kamar") {
                upgradeTambahKamar(asset);
            } else if(assetName == "Ruangan 1") {

            }
        }
    }

    IEnumerator unlockRoom(){
        Animator anim = menuUpgrade.GetComponent<Animator>();
        anim.SetBool("isMenuShow", false);
        oldTotalRoom = gameManagerCS.totalRoom-1;
        gameManagerCS.totalRoom += 1;

        eventSystem.SetActive(false);
        yield return new WaitForSeconds(1.5f);
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
}
