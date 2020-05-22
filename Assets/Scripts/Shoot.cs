using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class Shoot : NetworkBehaviour {
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private float bulletVel = 5;
    [SerializeField] private float fireRate;
    [SerializeField] private TextMeshProUGUI ammoText;
    private int maxAmmo = 15;
    private float lastShot = 0;
    private int ammunition = 15;


    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && (Time.time > fireRate + lastShot) && (ammunition > 0)) {
            if (!isLocalPlayer) {
                return;
            }
            else {
                CmdFire(barrel.position, barrel.rotation);
                ammunition--;
                ammoText.text = ammunition.ToString();
            }
            lastShot = Time.time;
        }
    }

    [Command]
    void CmdFire(Vector3 pos, Quaternion rot) {
        var go = Instantiate(bullet, pos, rot);
        NetworkServer.Spawn(go);
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
        Destroy(go, 3);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.transform.CompareTag("Restock")) {
            Debug.Log("Collided with " + hit.gameObject.name);
            ammunition = maxAmmo;
            ammoText.text = ammunition.ToString();
        }
    }
}
