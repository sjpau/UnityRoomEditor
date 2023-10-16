using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineSelectable : MonoBehaviour
{

  private Transform highlight;
  private Transform selection;
  private RaycastHit hit;
  public Tools cursorTools;
  public float outlineThicc = 7.0f;
  public Color outlineColor = Color.magenta;
  public RaycastHit currentHit;

    void Update()
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))//!EventSystem.current.IsPointerOverGameObject() &&  
        {
            highlight = hit.transform;
            currentHit = hit;
            if (highlight.CompareTag("Selectable") && highlight != selection)
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = outlineColor;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = outlineThicc;
                }
            }
            else
            {
                highlight = null;
            }
        }

        if (Input.GetMouseButtonDown(0) )
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
                selection = hit.transform;
                currentHit = hit;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
            if (highlight && cursorTools.current != cursorTools.SELECT)
            {
                    selection = null;
                    highlight = null;
            }
            Debug.Log(selection);
            Debug.Log(highlight);
        }
    }
}
