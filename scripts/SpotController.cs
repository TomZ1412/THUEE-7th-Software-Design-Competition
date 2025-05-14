using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotController : MonoBehaviour
{
    
    public static int Num = 0;
    int maxNum=11;    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Num >= maxNum)
        {
            GameObject.Find("Canvas").transform.Find("GameOver").gameObject.SetActive(true);
    
            
        }
    }

    public static void addNum()
    {
        Num++;
    }

}
