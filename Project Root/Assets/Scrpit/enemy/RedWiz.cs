using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;// so can use the scene management in unity 
using UnityEngine;

public class RedWiz : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject myMagic;
    private bool isfiring;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (!isfiring)
        {
            
            StartCoroutine("Charge");
            isfiring = true;
        }

    }

    IEnumerator Charge()
    {

        yield return new WaitForSeconds(2.5f);
        Instantiate(myMagic, firePoint.position, firePoint.rotation);
        isfiring = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.tag == "GreenMagic")
        {
            SceneManager.LoadScene("MainMenu");

        }
    }

     private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Vines")
        {

            SceneManager.LoadScene("MainMenu");


        }

        if (collision.tag == "Punch")
        {

            SceneManager.LoadScene("MainMenu");


        }
    }
}

