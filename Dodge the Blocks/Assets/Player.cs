using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 15f;

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

        // This line will make sure that we can go left and right but not up. We can go either -1 to the left or 1 to thr right and 0 up
        // Also MovePosition already includes the w a s d keys as well as the arrw keys for movement. 
        rb.MovePosition( rb.position + Vector2.right * x);
	}
}
