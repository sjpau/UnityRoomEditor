using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteObject : MonoBehaviour
{
    public Tools cursorTools;
    public OutlineSelectable selection;
    private RaycastHit hit;

    void Update()
    {
        if (cursorTools.current == cursorTools.DELETE)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject toDelete = hit.collider.gameObject;
                        if (toDelete.CompareTag("Selectable"))
                        {
                            Destroy(toDelete);
                        }
               }
            }
        }
    }
}
