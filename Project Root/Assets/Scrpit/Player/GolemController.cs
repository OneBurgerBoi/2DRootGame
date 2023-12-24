using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;// so can use the scene management in unity 
using UnityEngine;

public class GolemController : MonoBehaviour
{
    [SerializeField] private GameObject punch;
    private GameObject player;
    private PlayerScrpit playerScrpit;
    private PlayerMovement1 movement;
    private Rigidbody2D playBody;

    [SerializeField] private GameObject golem;
    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScrpit = player.GetComponent<PlayerScrpit>();
        movement = player.GetComponent<PlayerMovement1>();
        playBody = player.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Fire1"))
        {
            punch.SetActive(true);
            Debug.Log("works");
            StartCoroutine("Cycle");

        }

        if (Input.GetKeyDown(KeyCode.G)) 
        {
            
            movement.enabled = true;
            playerScrpit.enabled = true;
            PlayerScrpit.isGolem = false;
            playBody.bodyType = RigidbodyType2D.Dynamic;
            golem.SetActive(false);
            
        }



    }

    public void DeSummomGolem()
    {
        movement.enabled = true;
        playerScrpit.enabled = true;
        PlayerScrpit.isGolem = false;
        playBody.bodyType = RigidbodyType2D.Dynamic;
        golem.SetActive(false);
    }

    IEnumerator Cycle()
    {
        //some animation logic could go between here
        yield return new WaitForSeconds(0.5f);
        punch.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallPit")
        {
            DeSummomGolem();

        }
    }

   

}
