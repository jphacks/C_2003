using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// co py pe
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows;
using System.Data;



/// <summary>
/// /////////////////////////////////////////////////////////////////////////
/// 
/// How To Use FileStr library made by Masaccccch
/// 
/// 1 Write Txt file
/// →use public static int InputStr(string text);
/// ex: FileStr.InputStr("Hello");
/// there is a Log.txt in your repo
/// 
/// 2 Read txt file 
/// →use public static List<string> getStringArr()
/// ex: List a = FileStr.getStringArr();
/// 
/// 
/// 
/// 
/// </summary>











public class FileStr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static string filename = "Log.txt";
    public static string filefullname = cdup2() + "/" + filename;

    public static string cdup2()
    {
        string dir = System.Environment.CurrentDirectory;
        return Path.GetDirectoryName(Path.GetDirectoryName(dir));
    }

    public static string getToday()
    {
        DateTime dt = DateTime.Now;
        return dt.ToShortDateString();
    }

    public static bool checkLogExist()
    {
        if (File.Exists(filefullname))
        {
            return true;
        }
        else
        {
            StreamWriter streamWriter = new StreamWriter(filefullname, true, Encoding.UTF8);
            DateTime dt = DateTime.Now;
            streamWriter.WriteLine("FIRST#" + dt.ToString());
            streamWriter.Close();
            return false;
        }
    }

    public static void write(string str)
    {
        Debug.Log(filefullname);
        StreamWriter streamWriter = new StreamWriter(filefullname, true, Encoding.UTF8);
        streamWriter.WriteLine(str);
        streamWriter.Close();
    }

    public static void writeDate()
    {
        DateTime dt = DateTime.Now;
        write(dt.ToString());
    }

    public static int countToday()
    {
        StreamReader Reader = new StreamReader(filefullname, Encoding.UTF8);
        DateTime today = DateTime.Now;
        int dayCount = 0;

        while (Reader.Peek() != -1)
        {
            string line = Reader.ReadLine();
            // System.Diagnostics.Debug.WriteLine("line= "+line);
            DateTime lineDate;
            if (DateTime.TryParse(line, out lineDate))
            {
                lineDate = DateTime.Parse(line);
                if (today.Date == lineDate.Date)
                {
                    dayCount++;
                }
            }

        }

        Reader.Close();
        return dayCount;
    }

    // add mthod
    public static int InputStr(string text)
    {
        if (text.Length >= 2)
        {
            write(text);
        }
        else
        {
            return -1;
        }

        return 0;
    }

    public static List<string> getStringArr()
    {
        StreamReader Reader = new StreamReader(filefullname, Encoding.UTF8);
        var strList = new List<string>();

        while (Reader.Peek() != -1)
        {
            string line = Reader.ReadLine();
            strList.Add(line);
            Debug.Log(line);
        }

        Reader.Close();
        return strList;
    }

}


