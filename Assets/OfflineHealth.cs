using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfflineHealth : MonoBehaviour {
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int maxShield = 100;
    [SerializeField] private AlexUI ui;
    [SerializeField] private Animator animator;
    private int health;
    private int shield;

    void Start() {
        ui.EnableShield(true);
        ui.SetMaxHealth(maxHealth);
        ui.SetMaxShield(maxShield);
        health = maxHealth;
        shield = maxShield;
        InvokeRepeating("Regenerate", 0, 0.5f);
    }

    void Update() {
        if (health <= 0) {
            setDead();
        }
        else if (gameObject.transform.position.y < -100f) {
            setDead();
        }
    }


    private void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.transform.CompareTag("ShieldStation")) {
            shield = maxShield;
            ui.SetShield(shield);
        }
    }

    public void DealDamage() {
        if (shield > 0) {
            shield -= 20;
            ui.SetShield(shield);
        }
        else {
            health -= 40;
            ui.SetHealth(health);
        }
        animator.Play("Hit Reaction", 0, 0.2f);
    }

    private void gotHit() {
        animator.Play("Hit Reaction", 0, 0.2f);
    }

    private void Regenerate() {
        if (health < maxHealth) {
            health += 1;
            gameObject.SetActive(false);
        }
    }

    private void setDead() {
        ui.SetEndMessage(1);
        ui.DisplayEndMessage();
    }
}
