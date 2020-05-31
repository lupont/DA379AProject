using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform player, gun;

    void Update() {
        if (AlexPauseMenu.GameIsPaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        } else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            RotateCamera();
        }
    }

    void RotateCamera() {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        Vector3 rotateGun = gun.transform.rotation.eulerAngles;
        Vector3 rotatePlayer = player.transform.rotation.eulerAngles;

        rotateGun.x -= rotAmountY;
        rotatePlayer.y += rotAmountX;

        gun.rotation = Quaternion.Euler(rotateGun);
        player.rotation = Quaternion.Euler(rotatePlayer);
    }


}
