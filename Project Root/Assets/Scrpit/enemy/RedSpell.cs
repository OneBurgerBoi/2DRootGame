using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpell : MonoBehaviour
{
    private float bullerSpeed = 10;
    private Rigidbody2D rgb2;
    private RedWiz redWiz;
    

    // Start is called before the first frame update
    void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        redWiz = FindObjectOfType<RedWiz>();

        if (redWiz.transform.localScale.x < 0)
        {
            bullerSpeed = -bullerSpeed;
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        rgb2.velocity = new Vector3(-bullerSpeed, rgb2.velocity.y, 0f);
        Destroy(gameObject, 0.999f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Health.hpref -= 1;

        }
    }
}
