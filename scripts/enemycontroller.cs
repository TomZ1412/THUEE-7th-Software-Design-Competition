using Cinemachine.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class enemycontroller : MonoBehaviour
{
    public float maxhealth = 2;
    float speed;
    public float timeInvincible = 1.0f;
    public float health { get { return currenthealth; } }
    float currenthealth;
    Rigidbody2D rigidbody2d;
    public GameObject target;
    public GameObject self;
    float horizontal;
    float vertical;
    float distance;
    bool isInvincible;
    float invincibleTimer;
    float angle;
    public int harm=-2;
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    public float slowtime=0.6f;
    private float slowtimer=0;
    public bool is_slowed=false;
    private float speedtemp;

    public bool WaterAttathed=false;
    public bool FireAttathed=false;
    public bool IceAttathed = false;
    public bool is_Frozen=false;
    public bool elementAttathed;
    public float elementAttathTimer = 0;

    public bool is_Reactioned = false;
    public float reactionTimer = 0;

    public float fireresistance=1;
    public float waterresistance=1;
    public float Iceresistance = 1;


    
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currenthealth = maxhealth;
        animator = GetComponent<Animator>();
        
    }

   
    void Update()
    {
        if (currenthealth < 0.01f)
        {
            animator.SetTrigger("died");
            Destroy(self,2.7f);
        }
        horizontal =target.transform.position.x - rigidbody2d.position.x;
        vertical = target.transform.position.y - rigidbody2d.position.y;
        distance =(float)Math.Sqrt((horizontal * horizontal + vertical * vertical));
        Vector2 move = new Vector2(horizontal, vertical);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            
            
                if (distance > 10.0f) speed = 0.0f;
                else
                if (distance > 5.0f) speed = 6.0f;
                else speed = 3.0f;
        }
        else
        {
            speed = 0.0f;
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", speed);
         if (isInvincible)
          {
              invincibleTimer -= Time.deltaTime;
              if (invincibleTimer < 0)
                  isInvincible = false;

          }

        elementAttathed = WaterAttathed || FireAttathed || IceAttathed;
        if (elementAttathTimer > 0)
        {
            elementAttathTimer += Time.deltaTime;
            if (elementAttathTimer >= 4.0)
            {
                elementAttathTimer = 0;
                WaterAttathed = false;
                FireAttathed = false;
                IceAttathed = false;
            }
        }
    }
    void FixedUpdate
        ()
    {
        Vector2 position = rigidbody2d.position;
        
        
        position.x = position.x + speed * lookDirection.x * Time.deltaTime;
        position.y = position.y + speed * lookDirection.y* Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        ascontroller player = other.gameObject.GetComponent<ascontroller>();
        if (player != null)
        {
            player.ChangeHealth(harm);
        }

    }
    public void ChangeHealth(float amount,float reactionmagnification=1, float resistance = 1)
    {
        if (amount < 0)
        {


            if (isInvincible)
                return;
            animator.SetTrigger("hit");
            isInvincible = true;
            invincibleTimer = timeInvincible;

        }
        Debug.Log(currenthealth);
        currenthealth = Mathf.Clamp(currenthealth + amount*reactionmagnification*resistance, 0, maxhealth);
    }   

    public void AttathWater()
    {

    }

    public void AttatheFire()
    {

    }

    public void AttathIce()
    {

    }
    void attack()
    {
        animator.SetTrigger("attack");
       
    }
}
