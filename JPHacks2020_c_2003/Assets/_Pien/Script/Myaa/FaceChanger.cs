using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaceChanger : MonoBehaviour
{
    public Sprite pien;
    public Sprite yeah;

    public void faceChange(int feel)
    {
        if (feel == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = pien;
            
        }
        else if(feel == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = yeah;
            
        }
    }
}
