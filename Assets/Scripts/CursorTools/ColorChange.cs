using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Tools cursorTools;
    private RaycastHit hit;

    void Update()
    {
        if (cursorTools.current == cursorTools.COLOR)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject toColor = hit.collider.gameObject;
                    Renderer render = toColor.GetComponent<Renderer>();
                    Color convertedColor;
                    if (ColorUtility.TryParseHtmlString(cursorTools.prefabColorToChangeHex, out convertedColor))
                    {
                        render.material.color = convertedColor;
                    }
                    else
                    {
                        Debug.LogWarning("Failed to convert hex color: " + cursorTools.prefabColorToChangeHex);
                    }
               }
            }
        }
    }

   
}
