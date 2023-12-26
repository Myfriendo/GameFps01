using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    
    public float xSensitivty = 30f;
    public float ySensitivty = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x * xSensitivty * Time.deltaTime;
        float mouseY = input.y * ySensitivty * Time.deltaTime;
        
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
