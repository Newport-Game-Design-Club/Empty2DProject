using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float movementSpeed = 9.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        Debug.Log(inputX);

        Vector2 velocity = new Vector2(inputX * movementSpeed, rb2D.velocity.y);
        
        rb2D.velocity = velocity;
        
    }
}
