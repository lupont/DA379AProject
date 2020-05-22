﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BulletScript : NetworkBehaviour {
    [SyncVar] private string shooter;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {

    }
    
    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Player") && collision.transform.name != shooter) {
            CmdPlayerShot(collision.transform.name);
        }
    }

    void CmdPlayerShot(string id) {
        Debug.Log(id + " has been shot");
        GameObject.Find(id).SendMessage("DealDamage", SendMessageOptions.DontRequireReceiver);
    }

    public void setShooter(string shooter) {
        this.shooter = shooter;
    }

}
