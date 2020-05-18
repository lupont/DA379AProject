using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    private int health = 100;
   [SerializeField] private Slider healthbar;

    void Start() {
        healthbar.value = health;
    }

    void Update() {

    }

    void OnCollisionEnter(Collision collision) {
        if (collision.transform.CompareTag("Bullet")) {
            Debug.Log("I was hit " + gameObject.name);
            health -= 10;
            healthbar.value = health;
            if (health <= 0) {
                gameObject.SetActive(false);
            }
        }
    }
}
