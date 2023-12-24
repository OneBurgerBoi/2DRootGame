using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform player;
    [SerializeField] private Transform golem;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (PlayerScrpit.isGolem)
        {
            Vector3 targtPosition = golem.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targtPosition, ref velocity, smoothTime);
        }
        else
        {
            Vector3 targtPosition = player.position + offset;
            transform.position = Vector3.SmoothDamp(transform.position, targtPosition, ref velocity, smoothTime);
        }
    }
}
