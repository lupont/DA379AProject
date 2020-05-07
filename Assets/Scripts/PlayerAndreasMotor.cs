using UnityEngine;
using System;

public class PlayerAndreasMotor : MonoBehaviour
{
    [SerializeField] float m_pivoxMax = 50;
    [SerializeField] float m_pivoxMin = -40;
    [SerializeField] float m_sensitivity = 4;
    private float pivot;
    private void Start()
    {
        pivot = transform.localRotation.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        pivot -= Input.GetAxis("Mouse Y") * m_sensitivity;
        pivot = Mathf.Clamp(pivot, m_pivoxMin, m_pivoxMax);
        transform.localRotation = Quaternion.Euler(pivot, 0, 0);
    }

}
