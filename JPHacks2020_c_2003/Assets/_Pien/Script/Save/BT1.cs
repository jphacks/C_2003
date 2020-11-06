using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class BT1 : MonoBehaviour
{

    public Text boxtext ;
    public GameObject text;

    public Text msgtxt;
    public GameObject mtext;

    public UnityEngine.UI.Image fukidasiImg;
    public GameObject fukidashi;

    private List<string> strArray = null ;

    // Start is called before the first frame update
    void Start()
    {
        boxtext = text.GetComponent<Text>();
        msgtxt = mtext.GetComponent<Text>();

        fukidasiImg = fukidashi.GetComponent<UnityEngine.UI.Image>();
        fukidashi.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       // boxtext.text = "AAAAAAA";
    }

    public void Drop()
    {

        Debug.Log("Your OS "+Application.platform);

        setStrArr(FileStr.getStringArr());
        Debug.Log("Clicked!");
        Feel.LS();
        if(strArray != null)
        {
            boxtext.text = "";
            foreach(var a in strArray)
            {
                Debug.Log("show :" + a);
                if(a.Length>2)boxtext.text += a+"\n";
            }
        }
        // テキストボックスに文字入れる関数

        showMessage();
    }

    public void setStrArr(List<string> arr)
    {
        strArray = arr;
    }

    public void showMessage()
    {
        fukidashi.SetActive(true);
        msgtxt.text = "そいつぁあ大変やったなあ\n";
        List<string> sArr = Shuffle( FileStr.getStringArr() );
        int i = 0;
        foreach(var a in sArr)
        {
            i++;
            msgtxt.text += "・"+a + "\n";
            if (i == 3) break;
        }
        msgtxt.text += "元気だしてや";
    }

    // シャッフル
    public static  List<string> Shuffle(List<string> list)
    {

        for (int i = 0; i < list.Count; i++)
        {
            string temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;
    }

}
