using UnityEngine;

public class boxSelection : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private Vector2 initialMousePosition, currentMousePosition;
    private BoxCollider2D boxCollider;

    /// <summary>
    /// This script is primarily taken from the Youtube Channel Alexander Zotov
    /// Link: https://www.youtube.com/watch?v=vZ0T7mExfhY&list=PL6yItMct2ybov1Z3InuFPpFmFY61NtOvH&index=66
    /// </summary>
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    private void Update()
    {
        // when left mouse button is pressed and  mouse pointer is not over any object
        // I create four points at mouse position
        if (Input.GetMouseButtonDown(0))// && !Object.mouseOverObject
        {
            lineRenderer.positionCount = 4;
            initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRenderer.SetPosition(1, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRenderer.SetPosition(2, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRenderer.SetPosition(3, new Vector2(initialMousePosition.x, initialMousePosition.y));

            // this boxSelection game object gets a box collider  which is set as a trigger
            // Center of this collider is at BoxSelection position
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
            boxCollider.isTrigger = true;
            boxCollider.offset = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
        }

        // while mouse button is being held down I can draw a rectangle 
        // those four points get corresponding coordinates depending on
        // mouse initial position when button was pressed for the first time
        // and its current position

        if (Input.GetMouseButtonDown(0)) // && !Object.mouseOverObject
        {
            currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRenderer.SetPosition(1, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRenderer.SetPosition(2, new Vector2(initialMousePosition.x, initialMousePosition.y));
            lineRenderer.SetPosition(3, new Vector2(initialMousePosition.x, initialMousePosition.y));

            // BoxSelection gameobjects position is at the middle of the box drawn

            transform.position = (currentMousePosition + initialMousePosition) / 2;

            // box colldier boundaries outline that  box drawn

            boxCollider.size = new Vector2(
                Mathf.Abs(initialMousePosition.x - currentMousePosition.x),
                Mathf.Abs(initialMousePosition.y - currentMousePosition.y));
        }

        // when mouse button is released box is wiped, collider is destroyed
        // and BoxSelection gameobject goes back to the center of the screen

        if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.positionCount = 0;
            Destroy(boxCollider);
            transform.position = Vector3.zero;
        }
    }
}
