using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class DroneSpawnerMP : NetworkBehaviour {
    [SerializeField] private GameObject drone;
    // Start is called before the first frame update
    void Start() {
        CmdSpawnDrone();
    }

    // Update is called once per frame
    void Update() {

    }

    [Command]
    void CmdSpawnDrone() {
        var go = Instantiate(drone, gameObject.transform.position, gameObject.transform.rotation);
        NetworkServer.Spawn(go);
        Debug.Log("Spawning drone");
    }

}
