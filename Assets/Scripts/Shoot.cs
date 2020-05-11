using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    // [SerializeField] private Transform barrel;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform gun;
    [SerializeField] private float bulletVel = 5;
    


    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Fire1")) {

            // Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            // if (Physics.Raycast(ray, out RaycastHit hit, 100)) {
            //     Debug.LogFormat(hit.collider.gameObject.name);
            // hit.transform.SendMessage("Fire", SendMessageOptions.DontRequireReceiver);
            // }

            var go = Instantiate(bullet, gun.position, gun.rotation);
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletVel;
            Destroy(go, 3);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Träff");
    }
}
