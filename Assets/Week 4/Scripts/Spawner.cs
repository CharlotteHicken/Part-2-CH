using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timer = 0;
    public float spawnRate;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= spawnRate)
        {
            Instantiate(prefab);
            timer = 0;
            spawnRate = Random.Range(1, 5);
        }
    }
}
