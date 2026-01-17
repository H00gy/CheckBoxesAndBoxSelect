using UnityEngine;
using UnityEngine.UI;

public class checkBoxConfirmation : MonoBehaviour
{
    
    public Transform checkBoxes;
    public GameObject fake;
    public GameObject real;
    bool confirmation;
    

    public void onClick()
    {

        foreach(Transform checkBoxTransform in checkBoxes) // looks for if checkbox is checked and sets confirmation value
        {
            GameObject childObj = checkBoxTransform.gameObject;

            if (childObj.GetComponentInChildren<Image>().sprite == null) // if no checkmarks
            {
                confirmation = true; 
            }
            else
            {
                confirmation = false;
            }
        }
        if (confirmation == true && ObjectSelected.currentSelection != null)
        {
            
            GameObject thisRTag = Instantiate(real);
            thisRTag.transform.parent = ObjectSelected.currentSelection.transform;
        }
        else if(confirmation == false && ObjectSelected.currentSelection != null)
        {
            GameObject thisFTag = Instantiate(fake);
            thisFTag.transform.parent = ObjectSelected.currentSelection.transform;
        }
    }
    

}
