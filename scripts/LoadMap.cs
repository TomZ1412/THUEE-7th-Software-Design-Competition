using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMap : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obj;

    void Start()
    {
        obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openMap()
    {
        obj.SetActive(true);
    }

    public void closeMap()
    {
        obj.SetActive(false);
    }
}
