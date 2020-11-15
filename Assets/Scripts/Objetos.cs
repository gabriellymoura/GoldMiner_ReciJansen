using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    //public int xRange = 10;
    //public int yRange = 3;
    public int numObjects = 16;
    public GameObject[] objects;


    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn(){
        for(int i=0; i<numObjects; i++){
            Vector3 spawnLocal = new Vector3 (Random.Range (-10, 10), Random.Range (1, 4), 0);
            int objectPick = Random.Range (0,objects.Length);
            Instantiate(objects[objectPick], spawnLocal, Random.rotation);
        }
    }
}
