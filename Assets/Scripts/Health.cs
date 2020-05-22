using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;
using TMPro;

public class Health : NetworkBehaviour {
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxShield = 100;
    [SerializeField] private AlexUI ui;
    private int health;
    private int shield;

    void Start() {
        ui.EnableShield(true);
        ui.SetMaxHealth(maxHealth);
        ui.SetMaxShield(maxShield);
        health = maxHealth;
        shield = maxShield;
        InvokeRepeating("Regenerate", 0, 1);
    }

    void Update() {
        if (health <= 0) {
            CmdSetDead(gameObject.transform.name);
            gameObject.SetActive(false);
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.transform.CompareTag("ShieldStation")) {
            shield = maxShield;
            ui.SetShield(shield);
        }
    }

    public void DealDamage() {
        if (shield > 1) {
            shield -= 50;
            ui.SetShield(shield);
        }
        else {
            health -= 20;
            ui.SetHealth(health);
        }
    }

    private void Regenerate() {
        if (health < maxHealth) {
            health += 2;
            ui.SetHealth(health);
        }
    }

    [Command]
    void CmdSetDead(string id) {
        Destroy(GameObject.Find(id));
    }
}
