using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera theCamera;
    float xRotation = 0f;
    public float xSentivity = 30f;
    public float ySentivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySentivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        theCamera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate((mouseX * Time.deltaTime) * xSentivity * Vector3.up);
    }
}
