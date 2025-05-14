using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("GameOver/Image2/Text2").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver/Image2/Image").gameObject.SetActive(false);
        Invoke("isText", 19f);
    }


    void isText()
    {
        GameObject.Find("Canvas").transform.Find("GameOver/Image2/Text2").gameObject.SetActive(true);
        Invoke("isQuit", 1f);
    }

    void isQuit()
    { 
        GameObject.Find("Canvas").transform.Find("GameOver/Image2/Image").gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
