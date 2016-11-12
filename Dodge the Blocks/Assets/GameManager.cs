using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float slowDownTime = 10f;

    // Reloads scene
	public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    // our slowdown effect after hitting block is made here by slowing up time but also have to make sure that
    // our game dosnt take 10 seconds to reload so the / is divinding our real time into our slowDownTime
    // so that it only takes one second to reload game after hitting block
    IEnumerator RestartLevel ()
    {
        // before 1 sec
        Time.timeScale = 1f / slowDownTime;
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowDownTime;

        yield return new WaitForSeconds(1f / slowDownTime);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowDownTime;

        //after 1 second
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
