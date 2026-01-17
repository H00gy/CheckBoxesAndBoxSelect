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
        
        foreach(Transform checkBoxTransform in checkBoxes) // looks for if checkbox is checked and sets confirmation value
        {
            GameObject childObj = checkBoxTransform.gameObject;
            Transform grandChildObj = childObj.transform.GetChild(0);
            
            if(grandChildObj.GetComponent<Image>().sprite != null)
            {
                confirmation++;
                Debug.Log("false");
                
            }
        }
        if (confirmation == 0 && ObjectSelected.currentSelection != null) // real (no checkmarks)
        {
            
            GameObject thisRTag = Instantiate(real);
            thisRTag.transform.parent = ObjectSelected.currentSelection.transform;
        }
        else if(confirmation > 0 && ObjectSelected.currentSelection != null) // fake (at least 1 checkmark)
        {
            GameObject thisFTag = Instantiate(fake);
            thisFTag.transform.parent = ObjectSelected.currentSelection.transform;
        }
    }
    

}
