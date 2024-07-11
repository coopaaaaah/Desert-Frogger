using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    float timer = 0f;
    float timeToLive = 1.6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > timeToLive) {
            Destroy(gameObject);
        } else {
            timer += Time.deltaTime;
        }
    }
}
