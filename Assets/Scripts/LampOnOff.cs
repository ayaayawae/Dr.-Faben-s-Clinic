using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOnOff : MonoBehaviour
{
    public GameObject Sun;
    private Light myLight;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {

        var xRotation = Sun.transform.eulerAngles.x;
        Debug.Log(xRotation);
        
        if (xRotation > 270 && xRotation < 360) {
            myLight.enabled = true;
        }else{
            myLight.enabled = false;
        }
    }
}
