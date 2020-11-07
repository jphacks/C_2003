using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class inT : MonoBehaviour
{

    InputField inputField;


    /// <summary>
    /// Startメソッド
    /// InputFieldコンポーネントの取得および初期化メソッドの実行
    /// </summary>
    void Start()
    {

        inputField = GetComponent<InputField>();

        InitInputField();
    }

    public void OnValueChanged()
    {
        string value = this.GetComponent<InputField>().text;
        if (value.IndexOf("\n") != -1)
        {
            this.GetComponent<InputField>().text = value;
        }
    }



    /// <summary>
    /// Log出力用メソッド
    /// 入力値を取得してLogに出力し、初期化
    /// </summary>


    public void InputLogger()
    {

        string inputValue = inputField.text;
        if (inputValue.Length >= 2)
        {
            int pn = Feel.Get(inputValue);
            //if(pn==2)FileStr.InputStr(inputValue + "@" + pn);
            //Only Positive & Sentence
            if (pn == 2) FileStr.InputStr(inputValue);
        }
        //  Debug.Log(inputValue);
        

        InitInputField();
    }



    /// <summary>
    /// InputFieldの初期化用メソッド
    /// 入力値をリセットして、フィールドにフォーカスする
    /// </summary>


    void InitInputField()
    {

        // 値をリセット
        inputField.text = "";

        // フォーカス
        inputField.ActivateInputField();
    }

}