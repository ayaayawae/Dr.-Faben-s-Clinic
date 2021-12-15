using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DestroyMoney : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManagerCs;
    public GameObject gameManagerObj;
    private Text moneyPlus;

    void Start()
    {   
        gameManagerCs = gameManagerObj.GetComponent<GameManager>();
        transform.GetChild(1).GetComponent<Text>().text = "+" + gameManagerCs.moneyOnClick.ToString();;
        if(gameObject.name != "CoinImageObj") {
            Destroy(gameObject, 1f);
        }
        // StartCoroutine(destroyCoinObj());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator destroyCoinObj() {
        yield return new WaitForSeconds(0.6f); 
        Debug.Log("SINIS");
        
    }
}
