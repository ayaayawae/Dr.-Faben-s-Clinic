using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerEnter() {
        transform.localScale = new Vector2(1.1f, 1.1f);
    }

    public void PointerExit() {
        transform.localScale = new Vector2(1f, 1f);
    }
}
