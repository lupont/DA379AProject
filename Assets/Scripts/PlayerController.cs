using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public CharacterController controller;

    public float walkSpeed = 10;
    public float runSpeed = 15;
    public float gravity;
    public float jumpForce;

    private float speed;
    private float y_velocity;

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
            y_velocity = jumpForce;
        }
       
        controller.Move(movement * Time.deltaTime);
    }

    private void FixedUpdate() {
        controller.Move(new Vector3(0, y_velocity * Time.deltaTime));
        y_velocity  -= gravity * Time.deltaTime;
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
