using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BT1 : MonoBehaviour
{

    public Text boxtext ;
    public GameObject text;
    private List<string> strArray = null ;

    // Start is called before the first frame update
    void Start()
    {
        boxtext = text.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
       // boxtext.text = "AAAAAAA";
    }

    public void Drop()
    {
        setStrArr(FileStr.getStringArr());
        Debug.Log("Clicked!");
        Feel.LS();
        if(strArray != null)
        {
            foreach(var a in strArray)
            {
                boxtext.text += a+"\n";
            }
        }
        // テキストボックスに文字入れる関数
        
        
    }

    public void setStrArr(List<string> arr)
    {
        strArray = arr;
    }
}
