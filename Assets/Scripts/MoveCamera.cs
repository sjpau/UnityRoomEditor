using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 0.5f;

    void Update()
    {
        
        if (!Input.GetKey(KeyCode.Space))
        {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical);
        moveDirection.Normalize(); 

        transform.Translate(moveDirection * speed * Time.deltaTime); 
        }
    }
}
