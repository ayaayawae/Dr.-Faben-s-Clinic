using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.Random;
using static UnityEngine.Random;


public class Movement : MonoBehaviour
{   
    string direction;
    int room;
    bool stop = false;
    bool begin = true;
    bool firstTurnExit = false;

    // int onProgress = 3;
    

    public Text MoneyText;

    int MoneyValue;
    private Money moneyCs;
    public GameObject moneyObj;
    int MoneyPlus;

    private GameManager gameManagerCs;
    public GameObject gameManagerObj;

    public int speed = 3;

    public Animator door1, door2, door3, door4, door5, door6, door7, door8;

    void Start()
    {
        moneyCs = moneyObj.GetComponent<Money>();
        gameManagerCs = gameManagerObj.GetComponent<GameManager>();

        MoneyPlus = moneyCs.MoneyPlus;

        string peopleName = transform.name;
        room = int.Parse(peopleName.Substring(peopleName.Length -1, 1));

        // Start Position
        transform.localPosition = new Vector3(-0.3009744f, 1.55f, -28.11f);
        transform.rotation = Quaternion.identity;
    }

    void Awake(){
        transform.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {   
        if(!stop && begin){
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if(!begin){
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }

    public void OnTriggerEnter (Collider col){
        if(!begin && !firstTurnExit){
            StartCoroutine(goToExit());
        }else{
            if(room.ToString() == col.gameObject.name){
                toggleDoor(room);
                if(room  < 5){
                    transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                }else{
                    transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                }
            }else if (col.gameObject.name == "Stop"){
                stop = true;
                StartCoroutine(onDoctor());
                
            }
        }
    }

    IEnumerator goToExit(){
        if(room < 5){
                yield return new WaitForSeconds(0.5f);
                transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
            }else{
                yield return new WaitForSeconds(0.5f);
                transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
            }
        firstTurnExit = true;
    }

    IEnumerator onDoctor(){
        yield return new WaitForSeconds(gameManagerCs.progressTime);
        MoneyValue = int.Parse(MoneyText.text);
        MoneyValue += MoneyPlus;
        MoneyText.text = MoneyValue.ToString();

        toggleDoor(room);
        transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
        transform.position += -transform.forward;
        begin = false;
    }

    void FixedUpdate(){
        
    }

    void toggleDoor(int doorNum){
        switch(doorNum){
            case 1: door1.SetTrigger("open");
            break;
            case 2: door2.SetTrigger("open");
            break;
            case 3: door3.SetTrigger("open");
            break;
            case 4: door4.SetTrigger("open");
            break;
            case 5: door5.SetTrigger("open");
            break;
            case 6: door6.SetTrigger("open");
            break;
            case 7: door7.SetTrigger("open");
            break;
            case 8: door8.SetTrigger("open");
            break;
            default: break;
        }
        // door1.SetBool("open", false);
    }
}
