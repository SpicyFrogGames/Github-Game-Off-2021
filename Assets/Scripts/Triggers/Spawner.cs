using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;

    private GameObject currentInstance;

    // Update is called once per frame
    void Update()
    {
        if (currentInstance == null)
        {
            currentInstance = Instantiate(objectToSpawn);
            currentInstance.transform.position = transform.position;
        }
    }
}
