using System.Collections; //fucking need this for coroutines, best not to use components not in use.
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private BoxCollider2D hitbox;
    private Animator anim;


    void Awake()
    {
        hitbox = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hitbox.enabled = false; //Attack is not active
    }

    // Update is called once per frame
    void Update()
    {
        PosCheck();//Need this for hitbox to stay connected with player
        Attack();
    }

    void PosCheck()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            this.transform.localPosition = new Vector3(1f, 0, 0);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            this.transform.localPosition = new Vector3(-1f, 0, 0);
        }
    }

    void Attack()
    {
        if(Input.GetButtonDown("Fire1"))//Crtl on keyboard, button 0 on controller, whatever you set it to in editor
        {
            StartCoroutine("Cycle");
            
        }
    }

    IEnumerator Cycle()
    {
        hitbox.enabled = true; //some animation logic could go between here
        yield return new WaitForSeconds(1f);
        hitbox.enabled = false;
        
    }
    void OnCollisionEnter2D(Collision2D bax)
    {
        if(bax.gameObject.tag == "Hazard") //dumbass put a semicolon here, caused everything to be destroyed
        { 
            //could instantiate particle here
            Destroy(bax.gameObject);
        }
    }
}
