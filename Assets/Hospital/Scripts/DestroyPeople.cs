using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPeople : MonoBehaviour
{
    public GameObject gameManagerObj;
    private GameManager gameManagerCs;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerCs = gameManagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider col){
        GameObject peopleExit = GameObject.Find(col.gameObject.name);
        // string peopleName = peopleExit.name;
        // int room = int.Parse(peopleName.Substring(peopleExit.name.Length-1, 1));
        Destroy(peopleExit);
        // if(peopleExit.name != "People"){
        // }
    }
}
