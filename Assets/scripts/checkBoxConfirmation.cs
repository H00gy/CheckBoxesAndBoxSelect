using UnityEngine;
using UnityEngine.UI;

public class checkBoxConfirmation : MonoBehaviour
{
    
    public Transform checkBoxes;
    public GameObject fake;
    public GameObject real;
    int confirmation = 0;
    

    public void onClick()
    {
        
        foreach(Transform checkBoxTransform in checkBoxes) // Looks through Checkboxes
        {
            GameObject childObj = checkBoxTransform.gameObject; 
            Transform grandChildObj = childObj.transform.GetChild(0); // sets grandchild checkmark 
            
            if(grandChildObj.GetComponent<Image>().sprite != null) // if there is a checkmark, increase the confirmation value
            {
                confirmation++;
                //Debug.Log("false");
                
            }
        }
        if (confirmation == 0 && ObjectSelected.currentSelection != null && ObjectSelected.currentSelection.transform.childCount < 1) // real (no checkmarks)
        {
            Debug.Log("real");
            GameObject thisRTag = Instantiate(real); // adds real tag (green triangle) 
            thisRTag.transform.parent = ObjectSelected.currentSelection.transform;
            thisRTag.transform.position = ObjectSelected.currentSelection.transform.position; // locks child position to parent
        }
        else if(confirmation > 0 && ObjectSelected.currentSelection != null && ObjectSelected.currentSelection.transform.childCount < 1) // fake (at least 1 checkmark)
        {
            Debug.Log("fake");
            GameObject thisFTag = Instantiate(fake); // adds fake tag (red triangle) 
            thisFTag.transform.parent = ObjectSelected.currentSelection.transform;
            thisFTag.transform.position = ObjectSelected.currentSelection.transform.position;
        }
        Reset();
    }

    private void Reset() // resets checkmarks to null and confirmation to 0
    {
        confirmation = 0; 
        foreach (Transform checkBoxTransform in checkBoxes) 
        {
            GameObject childObj = checkBoxTransform.gameObject;
            Transform grandChildObj = childObj.transform.GetChild(0); 
            grandChildObj.GetComponent<Image>().sprite = null;
        }
    }


}
