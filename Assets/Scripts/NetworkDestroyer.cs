using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkDestroyer : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        NetworkRoomManager manager = FindObjectOfType<NetworkRoomManager>();
        if (manager != null) {
            manager.StopClient();
            manager.StopHost();
        }

        Destroy(GameObject.Find("NetworkRoom"));
    }

    // Update is called once per frame
    void Update() {

    }
}
