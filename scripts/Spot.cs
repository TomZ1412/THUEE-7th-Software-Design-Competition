using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spot : MonoBehaviour
{
    public int selfNum;
    public GameObject obj;

    private void Awake()
    {
        obj.SetActive(false);
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ascontroller controler = collision.GetComponent<ascontroller>();

        if (selfNum == GlobalScript.Instance.num)
        {
        if (controler)
        {
            obj.SetActive(true);
            SpotController.addNum();
                GlobalScript.Instance.num++;
                gameObject.SetActive(false);
        }

        }
        
    }
}
