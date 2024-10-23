using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flythroughcontrol : MonoBehaviour
{
    public float flySpeed = 5f; // Speed of flying

    void Update()
    {
        // Get input from arrow keys or WASD
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * flySpeed * Time.deltaTime;

        // Move the player
        transform.Translate(movement);
    }
}
