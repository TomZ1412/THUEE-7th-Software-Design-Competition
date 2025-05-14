using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Lerp = 0.3f;
    public float lerp;
    public float speed=20;

    public GameObject explosionPrefab;
    new private Rigidbody2D rigidbody;

    private Vector3 targetPos;
    private Vector3 direction;

    public bool arrived;

    public void Awake()
    {
        rigidbody=GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
        lerp = Lerp;
    }

    public void SetTarget(Vector3 _target)
    {
        arrived=false;
        targetPos=_target;

    }

    private void FixedUpdate()
    {
        direction=(targetPos-transform.position).normalized;
        if(!arrived)
        {
            transform.right=Vector3.Slerp(transform.right,direction,lerp/Vector3.Distance(transform.position,targetPos));
            rigidbody.velocity = transform.right * speed;
        }
        if(Vector3.Distance(transform.position,targetPos)<1f&&!arrived)
        {
            arrived=true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision!");
        GameObject enemy = other.gameObject;
        explosionPrefab.transform.position = transform.position;

        if (other.gameObject.tag == "player") return;
        if (other.gameObject.tag == "enemy")
        {
            enemycontroller enemycontroller = enemy.GetComponent<enemycontroller>();
            if (!enemycontroller.elementAttathed)
            {
                enemycontroller.FireAttathed = true;
                enemy.GetComponent<enemycontroller>().ChangeHealth(-3);
            }
            else
            {
               
                if (enemycontroller.FireAttathed) enemy.GetComponent<enemycontroller>().ChangeHealth(-3,1f,enemycontroller.fireresistance);
                if (enemycontroller.FireAttathed)
                {
                    enemycontroller.IceAttathed = false;
                    enemycontroller.ChangeHealth(-3, 2.0f,enemycontroller.fireresistance);
                }
                if (enemycontroller.WaterAttathed)
                {
                    enemycontroller.ChangeHealth(-3, 1.5f, enemycontroller.fireresistance);
                    enemycontroller.WaterAttathed = false;
                    return;
                }
                Destroy(gameObject);
                Destroy(explosionPrefab, .3f);
            }

        }

    }


}
