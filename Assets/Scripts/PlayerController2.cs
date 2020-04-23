using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour {
    private Rigidbody rb;
    private CapsuleCollider col;
    //  private Boolean isGrounded;

    public float walkSpeed = 10;
    public float runSpeed = 15;
    private float speed;

    public float jumpForce = 2;

    private int limit = 100;
    private int jumpTimer = 100;



    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        // isGrounded = true;
    }

    // Update is called once per frame
    void Update() {
        
        Move();
    }

    private void Move() {
        
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");
            Boolean jump = (Input.GetKeyDown(KeyCode.Space) ? true : false);

            checkRun();

            moveX = moveX * speed * Time.deltaTime;
            moveZ = moveZ * speed * Time.deltaTime;

            transform.Translate(moveX, 0, moveZ);

        if (isGrounded()) {
            if (jump && jumpTimer >= limit) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumpTimer = 0;
            }
            else {
                jumpTimer++;
            }

        }
    }

    private void checkRun() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = runSpeed;
        } else {
            speed = walkSpeed;
        }
    }

    private void checkCrouch() {
        if (Input.GetKey(KeyCode.C)) {
            
        }
    }

   

    private Boolean isGrounded() {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }
}
