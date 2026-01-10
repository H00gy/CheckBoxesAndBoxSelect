using Unity.VisualScripting;
using UnityEngine;

public class ObjectSelected : MonoBehaviour
{
    private SpriteRenderer sr;

    private bool objectSelected;

    public static bool dragSelectedObjectAllowed, mouseOverObject;

    private Vector2 mousePos;

    private float dragOffSetX, dragOffSetY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        objectSelected = false;
        dragSelectedObjectAllowed = false;
        mouseOverObject = false;
    }

    // when BoxSelections collider meets an object, object changes its color tint to red
    // and object is marked as selected now

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<boxSelection>())
        {
            sr.color = new Color(1f, 0f, 0f, 1f);
            objectSelected = true;
        }
        
    }

    // when BoxSelection collider stops touching an object while left mouse button is still
    // being held down then object gets its normal color tint and marked as not selected

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent <boxSelection>() && Input.GetMouseButton(0))
        {
            sr.color = new Color(1f, 1f, 1f, 1f);
            objectSelected = false;
        }
    }

    private void Update()
    {
        // when left mouse button is clicked I need to get an offset between mouse position
        // and an object. This offset will help me to  drag Object/Objects from
        // its/their initial positions depending on mouse position without any "jumping" issues

        if (Input.GetMouseButtonDown(0))
        {
            dragOffSetX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
            dragOffSetY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
        }

        // and of course need to get mouse position

        if (Input.GetMouseButton(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (objectSelected && dragSelectedObjectAllowed)
        {
            transform.position = new Vector2(mousePos.x - dragOffSetX, mousePos.y - dragOffSetY);
        }

        // if Right Mouse button is pressed then selection is reset

        if (Input.GetMouseButtonDown(1))
        {
            objectSelected = false;
            dragSelectedObjectAllowed = false;
            sr.color = new Color(1f,1f,1f, 1f);
        }
    }

    private void OnMouseDown()
    {
        mouseOverObject = true; 
    }

    private void OnMouseUp()
    {
        mouseOverObject = false;
        dragSelectedObjectAllowed = false; 
    }

    private void OnMouseDrag()
    {
        dragSelectedObjectAllowed = true; 

        if (!objectSelected)
        {
            dragSelectedObjectAllowed = false; 
        }

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePos.x - dragOffSetX, mousePos.y - dragOffSetY);
    }


}
