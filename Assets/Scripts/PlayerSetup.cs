using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerSetup : NetworkBehaviour {
    [SerializeField] private Behaviour[] disables;
    [SerializeField] private GameObject[] doNotRender;


    // Disable scripts for non-local players and disable rendering for body parts of local player
    void Start() {
        if (!isLocalPlayer) {
            for (int i = 0; i < disables.Length; i++) {
                disables[i].enabled = false;
            }
        }
        else {
            for (int i = 0; i < doNotRender.Length; i++) {
                doNotRender[i].layer = 8;
            }

        }

        string id = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = id;
    }
}
