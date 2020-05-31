using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    [SerializeField]
    private AlexUI ui;

    [SerializeField]
    private int amountOfDrones = 15;

    [SerializeField]
    private GameObject dronePrefab;
    
    private GameObject[] drones;

    private int dronesLeft;

    /// <summary>
    /// Carefully selected points on the map on which the drones should spawn
    /// </summary>
    private Vector3[] spawnPoints = {
        new Vector3(8.5f,  0.2f, -50f),
        new Vector3(51f , -5.5f, -60f),
        new Vector3(102f,  0.2f, -55f),
        new Vector3(70f ,  5.9f, -49f),
        new Vector3(34f ,  5.9f, -49f),
        new Vector3(104f,  0.3f, -16f),
        new Vector3(87f ,  0.3f, -16f),
        new Vector3(54f ,  4.8f, -16f),
        new Vector3(46f ,  4.8f, -16f),
        new Vector3(17f ,  0.1f, 0f  ),
        new Vector3(8.5f,  0.1f, 20f ),
        new Vector3(36f ,  5.9f, 15f ),
        new Vector3(70f ,  5.9f, 15f ),
        new Vector3(104f,  0.3f, 24f ),
        new Vector3(52f , -5.6f, 27f ),
    };

    void Start()
    {
        drones = new GameObject[amountOfDrones];
        var takenIndices = new List<int>();
        for (int i = 0; i < amountOfDrones; i++)
        {
            int index;
            do 
            {
                index = Random.Range(0, spawnPoints.Length);
            }
            while (takenIndices.Contains(index));
            takenIndices.Add(index);

            Vector3 pos = spawnPoints[index];

            drones[i] = Instantiate(dronePrefab, pos, Quaternion.identity);
        }

        dronesLeft = amountOfDrones;
        ui.SetDronesLeft(dronesLeft);
    }

    void Update() {}

    public void Kill(GameObject drone)
    {
        if (drones != null && drones.Length > 0 && drone != null)
        {
            if (drones.Contains(drone))
            {
                Destroy(drone);
                ui.SetDronesLeft(--dronesLeft);
            }
        }

        if (dronesLeft <= 0)
        {
            ui.SetEndMessage(AlexUI.WINNER);
            ui.DisplayEndMessage();
        }
    }
}
