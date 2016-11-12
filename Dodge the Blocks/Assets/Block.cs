using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    
    // Makies the blocks fall down faster the longer u play
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f;
    }


	// Destroys Blocks after they go past -2 on the y axis
	void Update () {

        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
	}
}
