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
    public GameObject initRail; // We take the position, rotation and scale from the in world object to summon the others, so it must be within the level
    public GameObject brokenRail;
    public GameObject initSentry;
    public GameObject sentry;
    public int maxNumSentry = 3;
    public int maxBrokenRail = 3;
    public int immuneRails = 50; // Number of rails before broken rails spawn
    
    public int length = 80;

    public int interval = 3;
    // Start is called before the first frame update
    void Start()
    {
        generateWorld();
        Destroy(initSentry.gameObject);
    }

    void generateWorld()
    {
        for (int x = 0; x < length; x += interval)
        {
            // Ore
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
                
                // Select gold or steel
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
        
        // Rail procederal generation
        int lengthOfRailModule = 3;
        for (int x = 1; x < length; x++)
        {
            Vector3 position = new Vector3(initRail.transform.position.x + (x * lengthOfRailModule), initRail.transform.position.y,
                initRail.transform.position.z);
            if (x>immuneRails && Random.Range(0, 10) > 6) 
            {
                Debug.Log("Broken rail summoned");
                GameObject rail = Instantiate(brokenRail, position, initRail.transform.rotation);
                rail.transform.localScale = initRail.transform.localScale;
            }
            else
            {
                Instantiate(initRail, position, initRail.transform.rotation);
            }
        }
        
        // Sentry procedural generation
        int numSentry = Random.Range(1, maxNumSentry+1);
        for (int i = 0; i < numSentry; i++)
        {
            int posX = Random.Range(30, length);
            Vector3 position = new Vector3(Random.Range(30, length), 0, 10);
            Instantiate(sentry, position, initSentry.transform.rotation);
        }
        
    }
}
