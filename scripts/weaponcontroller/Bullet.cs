using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Rigidbody2D rigidbody2d;
    public GameObject elementsystem;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(rigidbody2d,2.0f);
        elementsystem = GameObject.Find("ElementSystem");
    }

    public void Launch(Vector3 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if (enemy.tag == "player") return;
        if (enemy.tag == "enemy")
        {
            enemycontroller enemycontroller=enemy.GetComponent<enemycontroller>();
            if (!enemycontroller.elementAttathed)
            {
                enemycontroller.WaterAttathed = true;
                enemy.GetComponent<enemycontroller>().ChangeHealth(-1);
                enemycontroller.elementAttathTimer+=Time.deltaTime;
            }
            else
            {
                if (enemycontroller.WaterAttathed) enemy.GetComponent<enemycontroller>().ChangeHealth(-1,1,enemycontroller.waterresistance); 
                if (enemycontroller.FireAttathed)
                {
                    enemycontroller.FireAttathed = false;
                    enemycontroller.ChangeHealth(-1, 2,enemycontroller.waterresistance);
                    enemycontroller.elementAttathTimer = 0;
                }
                if (enemycontroller.IceAttathed)
                {
                    enemycontroller.ChangeHealth(-3,1.2f, enemycontroller.waterresistance);
                    enemycontroller.IceAttathed = false;
                    enemycontroller.elementAttathTimer = 0;
                    return;
                }
            }
            
            
        }
        if(enemy.tag != "enemy") Destroy(gameObject,2.0f);
    }


}
