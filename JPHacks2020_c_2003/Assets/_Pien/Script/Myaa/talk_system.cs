﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Text;
using DigitalRuby.RainMaker;

public class talk_system : MonoBehaviour
{ 
    string url = "https://api.a3rt.recruit-tech.co.jp/talk/v1/smalltalk";
    string apikey = "DZZmVR5SaItxI9ghKkabqWTjkxdpN1dt";

    private int feel;
    public Text text;
    public InputField inputField;
    public GameObject replyPanel;
    public GameObject face;
    FaceChanger faceChanger;
    public GameObject maincamera;
    Rain2D rain2D;
    public Material sunny;
    public Material rain;
    public Material cloud;
    public Button topreturn;
    public FileStr filestr;

    // Start is called before the first frame update
    void Start()
    {
        faceChanger = face.GetComponent<FaceChanger>();
        rain2D = maincamera.GetComponent<Rain2D>();        
    }

    public void Initialize()
    {
        faceChanger.faceChange(0);
        text.text = "";
        inputField.text = "";
        replyPanel.SetActive(false);
        topreturn.gameObject.SetActive(false);
        inputField.gameObject.SetActive(true);
        RenderSettings.skybox = cloud;
        rain2D.RainScript.RainIntensity = 0f;
        rain2D.RainScript.WindSoundVolumeModifier = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            inputField.gameObject.SetActive(false);
            if (inputField.text != "")
            {
                text.text = "";
                replyPanel.SetActive(true);
                //判定
                feel = Feel.Get(inputField.text);                
                faceChanger.faceChange(feel);                
                if (feel == 2)
                {
                    RenderSettings.skybox = sunny;
                    FileStr.InputStr(inputField.text);
                }
                else if (feel == 1)
                {
                    RenderSettings.skybox = rain;
                    rain2D.RainScript.RainIntensity = 0.5f;
                    rain2D.RainScript.WindSoundVolumeModifier = 0.5f;
                }
                StartCoroutine(Chat());
                inputField.text = "";
            }
            topreturn.gameObject.SetActive(true);
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
                        text.text += "。";
                        if (feel == 2)
                        {                           
                            text.text += "\nちゃんと覚えておきますね！";
                        }
                        else if (feel == 1)
                        {                            
                            text.text += "\nぴえん。。。\n";
                            text.text += Feel.getMessage();
                        }                        
                    }
                    //Debug.Log(jsnode["results"][0]["reply"].Get<string>());
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
