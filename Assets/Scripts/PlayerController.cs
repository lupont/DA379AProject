using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public CharacterController controller;

    public float walkSpeed = 10;
    public float runSpeed = 15;
    private float speed;
    public float gravity;
    public float jumpForce;

    private Vector3 movement = Vector3.zero;

    // Start is called before the first frame update
    void Start() {
      
    }

    // Update is called once per frame
    void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        checkRun();
        
        movement = (transform.right * moveHorizontal + moveVertical * transform.forward);
        movement *= speed;

        if (controller.isGrounded && Input.GetKey(KeyCode.Space)) {
            movement.y = jumpForce;
        }

        movement.y -= gravity * Time.deltaTime;
        controller.Move(movement * Time.deltaTime);
    }

    private void checkRun() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;
        }
        else {
            speed = walkSpeed;
        }
    }
}
