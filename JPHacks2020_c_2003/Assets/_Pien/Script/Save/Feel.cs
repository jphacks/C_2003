using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

public class Feel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // " + str + "
    public static int Get(string str)
    {
        // 第1引数がコマンド、第2引数がコマンドの引数
        ProcessStartInfo processStartInfo = null ;

        if(Application.platform == RuntimePlatform.WindowsEditor)
        {
            processStartInfo = new ProcessStartInfo("\"cmd.exe\"", " \"/c python Feel.py " + str + " \"");
        }
        else
        {
            processStartInfo = new ProcessStartInfo("/bin/bash", "-c python Feel.py " + str);
        }

        // ウィンドウを表示しない
        processStartInfo.CreateNoWindow = true;
        processStartInfo.UseShellExecute = false;

        // 標準出力、標準エラー出力を取得できるようにする
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;

        //processStartInfo.StandardOutputEncoding = Encoding.GetEncoding("shift_jis");

        // コマンド実行
        Process process = Process.Start(processStartInfo);

        // 標準出力・標準エラー出力・終了コードを取得する
        string standardOutput = process.StandardOutput.ReadToEnd();
        string standardError = process.StandardError.ReadToEnd();
        int exitCode = process.ExitCode;

        process.Close();

        // MessageBoxに標準出力を表示
        //MessageBox.Show(standardOutput);
        //MessageBox.Show(standardError);
        int ans;
        if(int.TryParse(standardOutput, out ans))
        {
            return ans;
        }
        else
        {
            return -1;
        }
    }

    public static int LS()
    {

        // 第1引数がコマンド、第2引数がコマンドの引数
        //ProcessStartInfo processStartInfo = new ProcessStartInfo("\"cmd.exe\"", "\"/c dir\"");
        ProcessStartInfo processStartInfo = null;
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            processStartInfo = new ProcessStartInfo("\"cmd.exe\"", "\"/c dir\"");
        }
        else
        {
            processStartInfo = new ProcessStartInfo("/bin/bash", "-c ls");
        }
        // ウィンドウを表示しない
        processStartInfo.CreateNoWindow = true;
        processStartInfo.UseShellExecute = false;

        // 標準出力、標準エラー出力を取得できるようにする
        processStartInfo.RedirectStandardOutput = true;
        processStartInfo.RedirectStandardError = true;

        // コマンド実行
        Process process = Process.Start(processStartInfo);

        // 標準出力・標準エラー出力・終了コードを取得する
        string standardOutput = process.StandardOutput.ReadToEnd();
        string standardError = process.StandardError.ReadToEnd();
        int exitCode = process.ExitCode;

        process.Close();

        // MessageBoxに標準出力を表示
        UnityEngine.Debug.Log("LS : "+ standardOutput);



        return 0;
    }

}