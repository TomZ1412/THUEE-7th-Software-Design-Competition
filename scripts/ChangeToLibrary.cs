using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToLibrary : MonoBehaviour
{
    
    
    
    private Rigidbody2D _rigidbody2D;
    public List<GameObject> gameObjectToStayAlive;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }

      private void OnCollisionEnter2D(Collision2D collision)
       {
           if(GlobalScript.Instance.stage == 1)
        {
            GlobalScript.Instance.stage++;
            collision.transform.position = new Vector2(-557, -223);
        }
    }
          
}
