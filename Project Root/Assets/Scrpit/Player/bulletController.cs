using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletController : MonoBehaviour
{
    private float bullerSpeed = 10;
    private Rigidbody2D rgb2;
    private PlayerMovement1 player;

    
    


    // Start is called before the first frame update
    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<PlayerMovement1>();

        if(player.transform.localScale.x < 0)
        {
            bullerSpeed = -bullerSpeed;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        
        
    }

    // Update is called once per frame
    void Update()
    {
        rgb2.velocity = new Vector3(bullerSpeed, rgb2.velocity.y, 0f);
        Destroy(gameObject, 0.4f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //sDestroy(gameObject, 0.1f);


    }

   



}
