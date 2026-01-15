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

            if (childObj != null && childObj.GetComponent<Image>() != null)
            {
                if (childObj.GetComponent<Image>().sprite != null)
                { 
                    confirmation= true;
                    return;
                }
                else
                {
                    confirmation = false;
                }
            }
        }
        if (confirmation == true)
        {

        }
    }
    

}
