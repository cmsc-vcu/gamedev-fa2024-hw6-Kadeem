using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementIntro : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        float x = player.position.x;
        if(x< -16.3f) x = -16.3f;
        if(x > 4.9f) x = 4.9f;
        transform.position = new Vector3 (x, 0, -10);
    }
}
