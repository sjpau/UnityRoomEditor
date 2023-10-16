using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPoint3D : MonoBehaviour
{
    public Vector3 CursorToWorldPoint3D()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.point;
        } else {
            return Vector3.zero;
        }
    }
}
