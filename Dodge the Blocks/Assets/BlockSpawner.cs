using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    //Storing our blocks into array so its easier for us to call them to spawn
    public Transform[] spawnPoints;

    public GameObject blockPreFab;

    public float timeBetweenWaves = 1f;

    private float timeToSpawn = 2f;

	// Use this for initialization
	void Update () {
        
        // This if statement checks real time vs timeToSpawn so if the statement is true blocks will spawn thanks to 
        // SpawnBlocks (). then the line under SpawnBlock() will make the time to spawn Time.time + 1. Since Time.time
        // will keep going up the timeBetweenWaves will add 1 to it so that the timeToSpawn will always go up too
        // so heres what i mean after statement has been hit once

        // 4 = 3 + 1
        // 6 = 5 + 1

        //I.E. SpawnBloacks will always be called after 2 seconds from last one and will be random
        if(Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }

	}

    void SpawnBlocks()
    {
        // this line will produce a number between 1 and 5 
        int randomIndex = Random.Range(0, spawnPoints.Length);


        // This for loop will spawn blocks in every index of array except for the value of randomIndex and since
        // our timer calls the SpawnBlocks method every 2 seconds we will most likely have a different gap in the blocks 
        // for us to go through which is why the movement has to be limited

        // Quaternion from my knowledge stops rotating of some sorts. All i know is that its a must in this peice of code
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPreFab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }

}
