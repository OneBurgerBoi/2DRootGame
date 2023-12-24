using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private Image un;
    [SerializeField] private Image two;
    [SerializeField] private Image tree;

    public static int hpref;
    private int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        hpref = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (hpref == 2) un.enabled = false;
        if (hpref == 1) two.enabled = false;
        if (hpref == 0) tree.enabled = false;

        if(hpref <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
