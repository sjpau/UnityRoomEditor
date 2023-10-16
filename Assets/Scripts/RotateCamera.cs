using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float senY = 5f;
    public float senX = 5f;
    float rotateX = 0f;
    float rotateY = 0f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float mouseX = Input.GetAxisRaw("Horizontal") * senX;
            float mouseY = Input.GetAxisRaw("Vertical") * senY;

            rotateX += mouseX;
            rotateY -= mouseY;
            rotateX = Mathf.Clamp(rotateX, -90f, 90f);

            transform.rotation = Quaternion.Euler(rotateY, rotateX, 0);
            
        }    
    }
}