using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeToHospital : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    public Canvas main;
    public Canvas lib;
    public Canvas hos;

    public GameObject player;
    //public GameObject hospital;

    public GameObject spotcontroller;

    public List<GameObject> gameObjectToStayAlive;

    public Text _text;

    public Text text1;
    public Text text2;

    public GameObject libImage;
    public GameObject hosImage;
    public GameObject libNPCImage;
    public GameObject hosNPCImage;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        player.SetActive(true);

        spotcontroller.SetActive(false);
        GameObject.Find("Canvas").transform.Find("taskPanel").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("说明button").gameObject.SetActive(true);

    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) )
        {
            GameObject.Find("Canvas").transform.Find("ResumeMenu").gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject.Find("Canvas").transform.Find("ResumeMenu").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("Map").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("Start").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("说明").gameObject.SetActive(false);
        }

        if (ascontroller.Gtimer!=0)
        {
            text1.text = "手枪剩余子弹：" + "正在换弹";
        }
        else
        {
            text1.text = "手枪剩余子弹：" + (8 - ascontroller.magnitude1);

        }

        if (ascontroller.Rtimer!=0)
        {
            text2.text = "步枪剩余子弹：" + "正在换弹" ;
        }
        else
        {
            text2.text = "步枪剩余子弹：" + (30 - ascontroller.magnitude2);
        }
        
        

        if (GlobalScript.Instance.stage >= 3)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                GameObject.Find("Canvas").transform.Find("Map").gameObject.SetActive(true);
            }
        }

        if (GlobalScript.Instance.stage == 1)
        {
            main.enabled = true;
            lib.enabled = false;
            hos.enabled = false;

            libImage.SetActive(true);
            hosImage.SetActive(false);
            libNPCImage.SetActive(false);
            hosNPCImage.SetActive(false);

            GameObject.Find("Canvas").transform.Find("taskPanel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("intro").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip1").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip2").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip3").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("背包").gameObject.SetActive(false);
            //GameObject.Find("Canvas").transform.Find("说明").gameObject.SetActive(false);


            //GameObject.Find("library").transform.Find("UI/Back").gameObject.SetActive(false);
            // GameObject.Find("hospital").transform.Find("UI/Back").gameObject.SetActive(false);
            //GameObject.Find("Canvas").transform.Find("Start").gameObject.SetActive(true);
            //GameObject.Find("Canvas").transform.Find("Start/Button(Legacy)/Image").gameObject.SetActive(true);
            spotcontroller.SetActive(false);
            //Invoke("isImage", 18f);
        }
        else if(GlobalScript.Instance.stage == 2)
        {
            main.enabled = false;
            lib.enabled = true;
            hos.enabled = false;

            libImage.SetActive(false);
            hosImage.SetActive(false);
            libNPCImage.SetActive(true);
            hosNPCImage.SetActive(false);

            GameObject.Find("Canvas").transform.Find("taskPanel").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip1").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip2").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip3").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("背包").gameObject.SetActive(false);
           
            //GameObject.Find("library").transform.Find("UI/Back").gameObject.SetActive(true);
            //GameObject.Find("hospital").transform.Find("UI/Back").gameObject.SetActive(false);
        }
        else if (GlobalScript.Instance.stage == 3)
        {
            main.enabled = true;
            lib.enabled = false;
            hos.enabled = false;

            libImage.SetActive(false);
            hosImage.SetActive(true);
            libNPCImage.SetActive(false);
            hosNPCImage.SetActive(false);

            GameObject.Find("Canvas").transform.Find("taskPanel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip1").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip2").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip3").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("背包").gameObject.SetActive(false);
           
            spotcontroller.SetActive(false);
        }

        else if(GlobalScript.Instance.stage == 4)
        {
            main.enabled = false;
            lib.enabled = false;
            hos.enabled = true;

            libImage.SetActive(false);
            hosImage.SetActive(false);
            libNPCImage.SetActive(false);
            hosNPCImage.SetActive(true);

            GameObject.Find("Canvas").transform.Find("taskPanel").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip1").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip2").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip3").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("背包").gameObject.SetActive(false);
        }
        else if (GlobalScript.Instance.stage == 5)
        {
            main.enabled = true;
            lib.enabled = false;
            hos.enabled = false;

            libImage.SetActive(false);
            hosImage.SetActive(false);
            libNPCImage.SetActive(false);
            hosNPCImage.SetActive(false);

            GameObject.Find("Canvas").transform.Find("taskPanel").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip1").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip2").gameObject.SetActive(false);
            GameObject.Find("Canvas").transform.Find("taskPanel/Tip3").gameObject.SetActive(true);
            GameObject.Find("Canvas").transform.Find("背包").gameObject.SetActive(true);
            
            spotcontroller.SetActive(true);

            _text.text = "任务进度:" + (GlobalScript.Instance.num - 1) + "/11";



        }




    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
  
           



         if (GlobalScript.Instance.stage == 3)
         {
            GlobalScript.Instance.stage++;
            collision.transform.position = new Vector2(283, -326);
         }
        
    }
}
