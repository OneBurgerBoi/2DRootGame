using UnityEngine;

public class PlayerMovementAB : MonoBehaviour
{

    [SerializeField] private float speed, height;
    [SerializeField] private Rigidbody2D rb; //reference for the movement
    [SerializeField] private int hp; //player health reference
    [SerializeField] private bool air; //Jumping limit

    //[SerializeField] private StatusUI UI; //Reference to the health bar, need to update the numbers so the leaves can go.
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") > 0f) //axis should have built in controller compatibility
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0f); //right movement
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0f); //left movement
        }
        if(Input.GetButtonDown("Jump") && !air)
        {
            rb.velocity = new Vector3(rb.velocity.x, height, 0f); //jumping
        }
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        air = false;
        if(hit.gameObject.tag == "Hazard")//Tag is reference to enemies or objects which hurt you, if different - rename it
        {
            hp--; //health go down
        }
        if(hit.gameObject.tag == "Restore")
        {
            hp++; //health go up
            Destroy(hit.gameObject);
        }
    }
    void OnCollisionExit2D()
    {
        air = true;
    }
}
