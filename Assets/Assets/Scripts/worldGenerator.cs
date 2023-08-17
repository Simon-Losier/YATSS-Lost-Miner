using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class worldGenerator : MonoBehaviour
{
    public GameObject gold;
    public GameObject steel;
    public GameObject rails;

    public int length = 80;

    public int interval = 3;
    // Start is called before the first frame update
    void Start()
    {
        generateWorld();
    }

    void generateWorld()
    {
        // 
        for (int x = 0; x < length; x += interval)
        {
            int verticalHeight = 10;
            int amountOfOre = Random.Range(2, 5);
            for (int i = 0; i < amountOfOre; i++)
            {
                int z = UnityEngine.Random.Range(0, 13);
                //6-8
                if (z < 10 && z > 6)
                {
                    continue;
                }
                Vector3 position = new Vector3(x, 0, z);
                
                Debug.Log("Instace at: x:" + x + "z: " + z);
                GameObject objectToSpawn = gold; // Default is gold

                if (Random.Range(0, 3) < 1)
                {
                    Instantiate(steel, position, Quaternion.identity);
                }
                else
                {
                    Instantiate(gold, position, Quaternion.identity);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
