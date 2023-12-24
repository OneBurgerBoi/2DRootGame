using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    private float horizontal;
    private float playerSpeed = 4f;
    private float jumpingPower = 6f;
    

    private Rigidbody2D rb2d;
    [SerializeField] private Transform goundCheck;
    [SerializeField] private LayerMask groundLayer;

    static bool onFloor;

    
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        FLip();

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpingPower);
        }

        


    }
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontal * playerSpeed, rb2d.velocity.y);



    }
    private void FLip()
    {
        if(horizontal < 0f )
        {
            transform.localScale = new Vector2(-1, 1);
            anim.SetBool("iswalking", true);
            
            
        }
        else if(horizontal > 0f)
        {
            transform.localScale = new Vector2(1, 1);
            anim.SetBool("iswalking", true);
            
        }
        else
        {
            anim.SetBool("iswalking", false);
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(goundCheck.position, 0.2f, groundLayer);
        
    }

    

 



    
}
