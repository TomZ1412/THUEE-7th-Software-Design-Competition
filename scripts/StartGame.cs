using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    //Animator animator;
    
    public float n;
    public GameObject[] Object;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        /*animator = GetComponent<Animator>();
        animator.SetBool("Start", false);
        
        //GameObject.Find("Canvas").transform.Find("Start/Button").gameObject.SetActive(false);
        Invoke("Start", 18f);*/
        //Object = GetComponent<GameObject>();
        animator = GetComponent<Animator>();
        //Object.SetActive(true);
        if (n > 0)
        {
            Invoke("show", n);
        }
        
    }

    public void show()
    {
        animator.SetBool("isStart", true);
    }

    /*public void button()
    {
        GameObject.Find("Canvas").transform.Find("Start/Button").gameObject.SetActive(true);
    }*/

    public void start()
    {
        //animator.SetBool("Start", true);
        Invoke("istip", 1f);
    }

    public void istip()
    {
        GameObject.Find("Canvas").transform.Find("Tip1").gameObject.SetActive(true);
    }

    public void destroy() { 
         for(int i = 0; i <5; i++)
        {
            Object[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
