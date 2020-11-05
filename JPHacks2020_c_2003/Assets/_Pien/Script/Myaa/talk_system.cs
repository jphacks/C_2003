using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Text;

public class talk_system : MonoBehaviour
{ 
    string url = "https://api.a3rt.recruit-tech.co.jp/talk/v1/smalltalk";
    string apikey = "DZZmVR5SaItxI9ghKkabqWTjkxdpN1dt";

    private int feel = 0;
    public Text text;
    public InputField inputField;
    public GameObject replyPanel;
    GameObject face;
    FaceChanger faceChanger;

    // Start is called before the first frame update
    void Start()
    {
        face = GameObject.Find("face");
        faceChanger = face.GetComponent<FaceChanger>();
}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {           
            if (inputField.text != "")
            {
                text.text = "";
                replyPanel.SetActive(true);
                //判定
                //feel = Feel.Get(inputField.text);
                feel = 2;
                StartCoroutine(Chat());
                inputField.text = "";
                
            }
        }
    }

    internal IEnumerator Chat()
    {
        // ChatAPIに送る情報を入力
        WWWForm form = new WWWForm();

        form.AddField("apikey", apikey);
        form.AddField("query", inputField.text, Encoding.UTF8);

        // 通信
        using (UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();

            //Debug.Log(inputField.text);
            if (request.isNetworkError)
            {
                Debug.Log(request.error);
            }
            else
            {
                try
                {
                    // 取得したものをJsonで整形
                    string itemJson = request.downloadHandler.text;
                    JsonNode jsnode = JsonNode.Parse(itemJson);
                    // Jsonから会話部分だけ抽出してTextに代入
                    if (text.text != null)
                    {
                        text.text += jsnode["results"][0]["reply"].Get<string>();
                        if (feel == 2)
                        {
                            faceChanger.faceChange(feel);
                            text.text += "\nちゃんと覚えておきますね！";
                        }
                        else if (feel == 1)
                        {
                            faceChanger.faceChange(feel);
                            text.text += "\nぴえん。。。";                                              
                        }
                }
                Debug.Log(jsnode["results"][0]["reply"].Get<string>());
                }
                catch (Exception e)
                {
                    //エラーが出たらこれがログに吐き出される
                    Debug.Log("JsonNode:" + e.Message);
                }
            }
        }
    }
}
