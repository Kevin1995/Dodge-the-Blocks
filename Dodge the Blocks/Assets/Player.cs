using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 15f;
    public float sceneWidth = 5f;

    // Reference for rigidbody on Player. rb = RigidBody
    private Rigidbody2D rb;

    void Start ()
    {
        // Finds a RigidBody2D Component in Player
        rb = GetComponent<Rigidbody2D>();
    }

	void FixedUpdate ()
    {
        // Better than doing input key cause i want the Players movement to be smooth.
        // Time.fixedDeltaTime must be called with the float of speed since we are using FixedUpdate
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        // New Variable to store information of movement
        Vector2 newPosition = rb.position + Vector2.right * x;


        // Here we are editing just the x value so that we limit our movement thanks to mathf.Clamp.
        // the scenceWidth can be changed depending on width of game but for now this will limit our movement to how far
        // we can go left and right ( -5 to 5)
        newPosition.x = Mathf.Clamp(newPosition.x, -sceneWidth, sceneWidth);
        
        // Also MovePosition already includes the w a s d keys as well as the arrw keys for movement. 
        rb.MovePosition(newPosition);
	}

    // When player hits a block this will access the GameManager script and called the EndGame method
    void OnCollisionEnter2D ()
    {
        FindObjectOfType<GameManager>().EndGame();
    }

}
