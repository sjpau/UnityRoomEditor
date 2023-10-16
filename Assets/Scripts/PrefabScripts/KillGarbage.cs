using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGarbage : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "DestroyField")
        {
            Destroy(this.gameObject);
        }
    }

    void Update()
    {
        if (this.gameObject != null)
        {
            Vector3 position = this.gameObject.transform.position;
            if (position.x > 500 || position.x < -500 ||
                position.y > 500 || position.y < -500 ||
                position.z > 500 || position.z < -500)
            {
               Destroy(this.gameObject); 
            }
        }
    }
}
