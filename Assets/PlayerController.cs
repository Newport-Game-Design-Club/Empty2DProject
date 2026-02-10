using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    BoxCollider2D coll2D;
    [SerializeField] LayerMask jumpableSurface;
    [SerializeField] float movementSpeed = 9.0f;
    [SerializeField] float jumpForce = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        coll2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Debug.Log(inputX);

        Vector2 velocity = new Vector2(inputX * movementSpeed, rb2D.velocity.y);

        rb2D.velocity = velocity;

        Debug.Log(isOnGround());
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround())
        {
            rb2D.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool isOnGround()
    {
        return Physics2D.BoxCast(coll2D.bounds.center, coll2D.bounds.size, 0f, Vector2.down, 0.1f, jumpableSurface);
    }
}
