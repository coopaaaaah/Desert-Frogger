using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DIRECTION 
{
    LEFT = -1,
    RIGHT = 1
}

public class SnakeSpawner : MonoBehaviour
{
    public GameObject snake;
    public DIRECTION spawnDirection;
    float edgeOfSpawner = 8.8f;
    float spawnRate = 0.6f;
    float timer = 0;
    int tile = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        } else 
        {
            spawnSnake(tile);
            tile += 1;
            timer = 0;
        }
    }

    void spawnSnake(int tile)
    {
        float currentPosition = transform.position.x + ((int) spawnDirection * tile);
        if (exceedBounds(currentPosition, spawnDirection, edgeOfSpawner))
        {
            return;
        } else 
        {
            Instantiate(snake, new Vector3(currentPosition, transform.position.y), transform.rotation);
        }
    }

    bool exceedBounds(float currentPosition, DIRECTION spawnDirection, float edgeOfSpawner)
    {
        return exceeedRightBounds(currentPosition, spawnDirection, edgeOfSpawner) || exceeedLeftBounds(currentPosition, spawnDirection, edgeOfSpawner);
    }

    bool exceeedLeftBounds(float currentPosition, DIRECTION spawnDirection, float edgeOfSpawner)
    {
        return spawnDirection == DIRECTION.RIGHT && currentPosition > (int) spawnDirection * edgeOfSpawner;
    }

    bool exceeedRightBounds(float currentPosition, DIRECTION spawnDirection, float edgeOfSpawner)
    {
        return spawnDirection == DIRECTION.LEFT && currentPosition < (int) spawnDirection * edgeOfSpawner;
    }
}
