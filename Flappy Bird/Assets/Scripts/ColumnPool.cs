using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//We use the Object Pool pattern here, where a pool of objectsis instantiated and ready for use by the client, whenever requested. 
//Significantly improves the performance of games
public class ColumnPool : MonoBehaviour
{

    public int poolSize = 5;
    public GameObject columnPrefab;
    public float spawnRate = 3f; // How long before next column is spawned
    public float colMin = -4.2f; //Min y value of column position
    public float colMax = 2f; //Max y value of column position

    private GameObject[] columns;
    private Vector2 objectPoolPosition = new Vector2(-20, -25);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f; //X position is fixed while spawning. Outside frame
    private int currentColumn = 0; //To keep track of what column from the array are we repositioning

    void Start()
    {
        timeSinceLastSpawned = 0f;
        columns = new GameObject[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            //Instantiate column prefab, at position objectpoolposition and use the rotation of the prefab object (Quaternion.identity)
            columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity); 
        }
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime; //Time taken to render the last frame
        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(colMin, colMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if(currentColumn >= poolSize)
            {
                currentColumn = 0; //Reset column position
            }
        }
    }
}
