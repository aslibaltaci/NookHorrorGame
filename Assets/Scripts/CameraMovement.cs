using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float sensitivity_x;
    public float sensitivity_y;

    public Transform body;

    float xRotation;
    float yRotation;
    

    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    private void FixedUpdate()
    {
        if(!PauseMenu.isPaused)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivity_x;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensitivity_y;


            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            body.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }

    void Update()
    {
    }
}
