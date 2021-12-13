using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPeople : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider col){
        GameObject peopleExit = GameObject.Find(col.gameObject.name);
        if(peopleExit.name != "People"){
            Destroy(peopleExit);
        }
    }
}
