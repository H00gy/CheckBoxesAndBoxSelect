using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class checkBoxes : MonoBehaviour, IPointerDownHandler
{
    public Image checkMarkImage;
    public Sprite checkMarkSprite;
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("clicked");
        if (checkMarkImage.sprite == null)
        {
            checkMarkImage.sprite = checkMarkSprite;
        }
        else
        {
            checkMarkImage.sprite = null;
        }
    }

    void Start()
    {
        checkMarkImage.sprite = null;
    }

    
}
