using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;




public class PlayerScrpit : MonoBehaviour
{
    private int maxHealth = 3;
    [SerializeField] public static int currentHealth;


    //attack
    [SerializeField] private GameObject vines;
    [SerializeField] private GameObject vines1;
    [SerializeField] private GameObject vines2;



    public static bool isGolem;
    private bool magicStam;

    [SerializeField] private GameObject greenGolem;
   
    private GolemController golemScrpit;
    public float golemTimer = 200;

    //shooting
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject myMagic;
    private bool isfiring;

    


    private Animator anim;
    private Rigidbody2D rgbd2;

    private PlayerMovement1 movement;

    


    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement1>();
        rgbd2 = GetComponent<Rigidbody2D>();
        
        golemScrpit = gameObject.GetComponent<GolemController>();

        currentHealth = maxHealth;
    }

    private void FixedUpdate()
    {

        if (isGolem)
        {
            golemTimer -= 1;

            if (golemTimer <= 0)
            {
                golemScrpit.DeSummomGolem();
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        GolemSummon();

        
        

        VineAttack();
        SpellCast();


        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }


    private void SpellCast()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isfiring)
            {
                anim.SetBool("isShoot", true);
                StartCoroutine("Charge");
                isfiring = true;
            }



        }
    }


    IEnumerator Charge()
    {
        
        yield return new WaitForSeconds(0.3f);
        Instantiate(myMagic, firePoint.position, firePoint.rotation);
        anim.SetBool("isShoot", false);
        isfiring = false;
    }





    private void VineAttack()
    {
        if (Input.GetButtonDown("Fire2") && movement.IsGrounded())//Crtl on keyboard, button 0 on controller, whatever you set it to in editor
        {
            


            StartCoroutine("Cycle");
            vines.SetActive(true);
            vines1.SetActive(true);
            vines2.SetActive(true);
            anim.SetBool("isAttack", true);
            movement.enabled = false;
        }


    }

    IEnumerator Cycle()
    {
        //some animation logic could go between here
        yield return new WaitForSeconds(1f);
        vines.SetActive(false);
        vines1.SetActive(false);
        vines2.SetActive(false);
        anim.SetBool("isAttack", false);
        movement.enabled = true;

    }

    private void GolemSummon()
    {

        if(Input.GetKeyDown(KeyCode.G))
        {
            if(!isGolem)
            {

                if(!magicStam)
                {
                    greenGolem.SetActive(true);
                    movement.enabled = false;
                    this.enabled = false;
                    isGolem = true;
                    rgbd2.bodyType = RigidbodyType2D.Static;
                    StartCoroutine("MagicStam");

                    
                }
               
                  
                

               

            }
            


        }
    }

    IEnumerator MagicStam()
    {
        
        yield return new WaitForSeconds(3f);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallPit")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
