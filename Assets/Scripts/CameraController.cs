using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform player, gun;
    private float minY = -45f;
    private float maxY = 45f;

    void Update() {
        Cursor.lockState = CursorLockMode.Locked;
        RotateCamera();
    }

    void RotateCamera() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        Vector3 rotateGun = gun.transform.rotation.eulerAngles;
        Vector3 rotatePlayer = player.transform.rotation.eulerAngles;

        rotateGun.z -= rotAmountY;
        // rotateGun.z = Mathf.Clamp(rotateGun.z, minY, maxY);
        rotateGun.x = 0;
        rotatePlayer.y += rotAmountX;

        gun.rotation = Quaternion.Euler(rotateGun);
        player.rotation = Quaternion.Euler(rotatePlayer);
    }


}
