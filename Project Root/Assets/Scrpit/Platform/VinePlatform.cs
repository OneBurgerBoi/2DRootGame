using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VinePlatform : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D boxy;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        boxy = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GreenMagic")
        {
            anim.enabled = true;
            boxy.isTrigger = false;

        }
    }

    
}
