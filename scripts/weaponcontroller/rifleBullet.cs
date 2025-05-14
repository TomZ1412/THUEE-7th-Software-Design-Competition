using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleBullet : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    //enemycontroller Enemy;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        Destroy(rigidbody2d, 3.0f);
    }

    public void Launch(Vector3 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject enemy = collision.gameObject;
        if (collision.gameObject.tag == "player") return;
        if (collision.gameObject.tag == "enemy")
        { 
            enemycontroller enemycontroller = enemy.GetComponent<enemycontroller>();
            if (!enemycontroller.elementAttathed)
            {
                enemycontroller.IceAttathed = true;
                enemy.GetComponent<enemycontroller>().ChangeHealth(-3,1,enemycontroller.Iceresistance);
            }
            else
            {
                if (enemycontroller.IceAttathed) enemy.GetComponent<enemycontroller>().ChangeHealth(-3);
                if (enemycontroller.FireAttathed)
                {
                    enemycontroller.FireAttathed = false;
                    enemycontroller.ChangeHealth(-3, 1.5f,enemycontroller.Iceresistance);
                }
                if (enemycontroller.WaterAttathed)
                {
                    enemycontroller.ChangeHealth(-3, 1.1f,enemycontroller.Iceresistance);
                    enemycontroller.WaterAttathed = false;
                    return;
                }
            }

        }
        if (collision.gameObject.tag != "enemy") Destroy(gameObject, 2.0f);
    }

}
