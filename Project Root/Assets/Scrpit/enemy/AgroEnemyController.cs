using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgroEnemyController : MonoBehaviour
{
    
    private Rigidbody2D rgbd2; //to store dater about the enermy Rigidbody2D

    [SerializeField] private Transform leftPoint; // to store dater about the transform called left point
    [SerializeField] private Transform rightPoint; // t store dater about the transform called right point 

    private bool movingRight; // to store is moving right is true or false 


    [SerializeField]  private Transform player;
    private float agroRange =5;
    private float moveSpeed =0.9f;

    private Rigidbody2D rb2d;

    private Animator anim;

    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //.Log("distToPlayer:" + distToPlayer);

        if(distToPlayer < agroRange)
        {
            if(!isAttacking)
            {
                // go to chase player
                ChasePlayer();
            }
            
           
        }
        else
        {
            // stop chaing player 
            
            EnemyPF();
            anim.SetTrigger("isIdle");
            moveSpeed = 0.9f;
        }

        if(distToPlayer < 2)
        {
            anim.SetTrigger("isAttacking");
            isAttacking = true;

            //attack thow the fire ball scrpit
        }
        else
        {
            anim.SetTrigger("isIdle");
            isAttacking = false;
            
        }

    }

   

    

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            //enemy on left of player to make it move right 
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(-1, 1);

        }
        else if (transform.position.x > player.position.x)
        {
            //enmy on the right of player to make it move left 
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(1, 1);
        }

        moveSpeed = 2;
    }

    

    private void EnemyPF()
    {
        if (movingRight && transform.position.x > rightPoint.position.x) //if moving right and position on x axis more then right point position x axis
        {
            movingRight = false; // if the enamy is moving right then right point positest it turn around 
            transform.localScale = new Vector3(1, 1, 1); // the X,Y,Z on the enermy game object 
        }
        // ! mean  Not 
        if (!movingRight && transform.position.x < leftPoint.position.x) // moving right and transform poition on teh x axis  is less then the left point position on the x axis
        {
            movingRight = true; // set movingRight si equal to true 
            transform.localScale = new Vector3(-1, 1, 1); // trun the emermy sprit to turn around 

        }

        if (movingRight) // if moving right is true 
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y); //Rigidbody2D velocity equal to movespeed, Rigidbody2D . velocity on y axis 

        }

        else // else if 
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y); // Rigidbody2D velocity equal to - movespepd (moven negitve of the x so moven left )
        }

    }

    
}
