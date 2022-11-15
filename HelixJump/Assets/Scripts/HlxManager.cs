using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HlxManager : MonoBehaviour
{
    [SerializeField] GameObject[] helixRings;
    [SerializeField] float ySpawn =0;
    [SerializeField] float ringDistance =5;
    [SerializeField] int numberOfRings = 7;
    
    void Start()
    {
        for (int i = 0; i < numberOfRings; i++)
        {
            if (i==0)
            {
                SpawnRing(0);
            }
            else
            {
                SpawnRing(Random.Range(0, helixRings.Length - 1));

            }

        }

        SpawnRing(helixRings.Length - 1);

    }
   
 

    public void SpawnRing(int ringIndex)
    {
       GameObject go = Instantiate(helixRings[ringIndex],transform.up * ySpawn,Quaternion.identity);
        go.transform.parent = transform;
        ySpawn -= ringDistance;
    }
}
