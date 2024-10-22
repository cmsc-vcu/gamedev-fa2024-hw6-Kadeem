using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
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
        //move sideways
        float horiz = Input.GetAxis("Horizontal") * speed;
        rb.velocity = new Vector3(horiz, rb.velocity.y, 0);

        //boing boing! this currently jumps infinitely haha
        if(Input.GetKeyDown(KeyCode.UpArrow)) rb.AddForce(new Vector3(0, jumpHeight, 0));
    }

    bool Grounded()
    {
        RaycastHit downInfo;
        return Physics.Raycast(transform.position, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z), out downInfo, 0.1f, 2);
    }
}
