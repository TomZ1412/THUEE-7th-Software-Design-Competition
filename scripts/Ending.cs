using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("GameOver/Image1").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("GameOver/Image1/yes").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver/Image1/no").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver/Image2").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver/yesImage").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver/noImage").gameObject.SetActive(false);
        GlobalScript.Instance.stage++;
        GlobalScript.Instance.Sound();

        Invoke("isButton",35f);
    }



    public void isButton()
    {
        GameObject.Find("Canvas").transform.Find("GameOver/Image1/yes").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("GameOver/Image1/no").gameObject.SetActive(true);
    }

    public void buttonOn()
    {
        GameObject.Find("Canvas").transform.Find("GameOver/Image2").gameObject.SetActive(true);

    }


    public void choice_y()
    {
        GameObject.Find("Canvas").transform.Find("GameOver/Image1").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver/yesImage").gameObject.SetActive(true);
    }

    public void choice_n()
    {
        GameObject.Find("Canvas").transform.Find("GameOver/Image1").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameOver/noImage").gameObject.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
