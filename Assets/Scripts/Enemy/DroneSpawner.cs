using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject drone;

    // Start is called before the first frame update
    void Start()
    {
        float[] xs = { 20, 40, 60, 80 };
        float[] zs = { 0 , 20, 40, 60 };

        foreach (var x in xs) {
            foreach (var z in zs) {
                Instantiate(drone, new Vector3(x, 0, z), Quaternion.identity);
            }
        }
        // Instantiate(drone, new Vector3(20, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
