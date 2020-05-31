using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DroneSpawnerMP : NetworkBehaviour {
    [SerializeField] private GameObject drone;
    private Vector3 pos = new Vector3(50, 5, -16);

    // Start is called before the first frame update
    void Start() {
        CmdSpawnDrone();
    }

    // Update is called once per frame
    void Update() {

    }

    [Command]
    void CmdSpawnDrone() {
        var go = Instantiate(drone, pos, new Quaternion(0,0,0,0));
        NetworkServer.Spawn(go);
        Debug.Log("Spawning drone");
    }

}
