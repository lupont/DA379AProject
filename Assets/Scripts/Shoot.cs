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
    private string shooter;
    private int maxAmmo = 15;
    private float lastShot = 0;
    private int ammunition = 15;

    private void Start() {
        shooter = "Player " + gameObject.GetComponent<NetworkIdentity>().netId;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && (Time.time > fireRate + lastShot) && (ammunition > 0) && !AlexPauseMenu.GameIsPaused) {
            if (!isLocalPlayer) {
                return;
            }
            else {
                CmdFire(barrel.position, barrel.rotation, shooter);
                ammunition--;
                ammoText.text = ammunition.ToString();
            }
            lastShot = Time.time;
        }
    }

    [Command]
    void CmdFire(Vector3 pos, Quaternion rot, string shooter) {
        var go = Instantiate(bullet, pos, rot);
        go.GetComponent<BulletScript>().setShooter(shooter);
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
        Destroy(go, 3);
        NetworkServer.Spawn(go);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.transform.CompareTag("Restock")) {
            Debug.Log("Collided with " + hit.gameObject.name);
            ammunition = maxAmmo;
            ammoText.text = ammunition.ToString();
        }
    }
}
