using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToMainScene : MonoBehaviour
{

    public GameObject player;

    public bool isLib;

    public List<GameObject> gameObjectToStayAlive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Change()
    {
        GlobalScript.Instance.stage++;

        if (isLib)
        {
            player.transform.position = new Vector2(20, 13);

        }

        else
        {
            player.transform.position = new Vector2(-66,32);
        }

        
    }
}
