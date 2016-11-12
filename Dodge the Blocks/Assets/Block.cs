using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {

	// Destroys Blocks after they go past -2 on the y axis
	void Update () {

        if (transform.position.y < -2f)
        {
            Destroy(gameObject);
        }
	}
}
