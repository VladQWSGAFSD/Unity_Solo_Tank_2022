using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowardMouse : MonoBehaviour
{
    [Header("References")]
    //[SerializeField] private Transform cameraHolder;
    [SerializeField] private Transform head;

    [Header("Look Settings")]
    [SerializeField] private float sensX = 10f;
    // [SerializeField] private float sensY = 10f;

    private float yRotation;
    //private float xRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        //float mouseY = Input.GetAxisRaw("Mouse Y");

        yRotation += mouseX * sensX;
        // xRotation -= mouseY * sensY;

        // xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        head.rotation = Quaternion.Euler(0f, yRotation, 0f);
        // cameraHolder.localRotation = Quaternion.Euler(0, yRotation, 0f);

    }

}
