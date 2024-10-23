using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public bool dying;
    private Vector3 velocity;

    // Update is called once per frame
    void Start()
    {
        dying = false;
        velocity = new Vector3(0, 0, 0);
    }

    void Update()
    {
        if(!dying)
        {
            FollowPlayer();
        }
        else
        {
            DeathGlide();
            if(transform.position.x == player.position.x && transform.position.y == player.position.y) dying = false;
        }
    }
    void DeathGlide()
    {        
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(player.position.x, player.position.y, -10), ref velocity, 0.3f);
    }

    void FollowPlayer()
    {
        transform.position = new Vector3 (player.position.x, player.position.y, -10);
    }
}
