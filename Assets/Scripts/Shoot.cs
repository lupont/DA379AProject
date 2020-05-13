using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private float bulletVel = 5;
    [SerializeField] private float fireRate;
    private float lastShot = 0;
    

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Fire();
        }
    }

    private void Fire() {
        if (Time.time > fireRate + lastShot) {
            var go = Instantiate(bullet, gun.position, gun.rotation);
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
            Destroy(go, 3);
            lastShot = Time.time;
        }
    }
}
