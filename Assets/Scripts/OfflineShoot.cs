using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OfflineShoot : MonoBehaviour {
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform barrel;
    [SerializeField] private float bulletVel = 5;
    [SerializeField] private float fireRate;
    [SerializeField] private TextMeshProUGUI ammoText;
    private string shooter = "OfflinePlayer";
    private int maxAmmo = 15;
    private float lastShot = 0;
    private int ammunition = 15;

    private void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1") && (Time.time > fireRate + lastShot) && (ammunition > 0) && !AlexPauseMenu.GameIsPaused) {
            Fire(barrel.position, barrel.rotation, shooter);
            ammunition--;
            ammoText.text = ammunition.ToString();
            lastShot = Time.time;
        }
    }

    private void Fire(Vector3 pos, Quaternion rot, string shooter) {
        var go = Instantiate(bullet, pos, rot);
        go.GetComponent<BulletScript>().setShooter(shooter);
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

