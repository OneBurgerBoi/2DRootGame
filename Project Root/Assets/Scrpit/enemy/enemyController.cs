using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class enemyController : MonoBehaviour
{
    private float moveSpeed = 2f; // to store dater about the enermy move speed
    private Rigidbody2D rgbd2; //to store dater about the enermy Rigidbody2D

    [SerializeField] private Transform leftPoint; // to store dater about the transform called left point
    [SerializeField] private Transform rightPoint; // t store dater about the transform called right point 

    private bool movingRight; // to store is moving right is true or false 

    private bool hasAttack;

    // Start is called before the first frame update
    void Start()
    {
        rgbd2 = GetComponent<Rigidbody2D>();// To get the component Rigidbody2D



    }

    // Update is called once per frame
    void Update()
    {


        EnemyMovement();

    }

    private void EnemyMovement()
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
            rgbd2.velocity = new Vector3(moveSpeed, rgbd2.velocity.y, 0); //Rigidbody2D velocity equal to movespeed, Rigidbody2D . velocity on y axis 

        }

        else // else if 
        {
            rgbd2.velocity = new Vector3(-moveSpeed, rgbd2.velocity.y, 0); // Rigidbody2D velocity equal to - movespepd (moven negitve of the x so moven left )
        }

    }

    

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Vines")
        {

            Destroy(gameObject, 0.5f);


        }

        if (collision.tag == "Punch")
        {

            Destroy(gameObject, 0.1f);


        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !hasAttack)
        {
            StartCoroutine("Charge");
            hasAttack = true;
            Debug.Log("has Attack");
            Health.hpref -= 1;
        }           
    }

    IEnumerator Charge()
    {

        yield return new WaitForSeconds(1);
        hasAttack = false;
        Debug.Log("can Attack");
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "GreenMagic")
        {
            Destroy(gameObject, 0.2f);

        }
    }

}
