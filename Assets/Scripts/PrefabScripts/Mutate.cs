using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutate : MonoBehaviour
{
    private Rigidbody rb;
    public Tools cursorTools;
    public bool hasJoint;
    public bool attach = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();        
        cursorTools = GameObject.Find("Watcher").GetComponent<Tools>();
    }

    void OnCollisionEnter (Collision collision)
    {
        if (attach)
        {
            Debug.Log("Attach object: " + attach);
            if (collision.gameObject.GetComponent<Rigidbody>() != null && !hasJoint) {
                gameObject.AddComponent<FixedJoint> ();  
                gameObject.GetComponent<FixedJoint>().connectedBody = collision.rigidbody;
                hasJoint = true;
            }
        }
    }

    private void OnMouseDrag()
    {
        Debug.Log(cursorTools.current);
        if (cursorTools.current == cursorTools.SELECT) 
        {
            float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToScreen);
            Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
            rb.isKinematic = true;
        }
        
    }

    private void OnMouseUp()
    {
        rb.isKinematic = false;
    }
}
