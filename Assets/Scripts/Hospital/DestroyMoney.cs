using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
