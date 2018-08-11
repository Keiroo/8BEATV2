using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DebugFileWriter : MonoBehaviour {

    private string filename;
    private float oldTimer = 0f;

    private void Awake()
    {
        DateTime dt = DateTime.Now;
        filename = "DebugTimers\\" +  dt.Year + dt.Month + dt.Day + "_" + dt.Hour + dt.Minute + dt.Second + ".txt";
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }
        using (File.Create(filename)) { }
    }

    public void WriteLevel(int level)
    {
        using (StreamWriter sw = File.AppendText(filename))
        {
            sw.WriteLine("Stage " + level);
        }
        oldTimer = 0f;
    }

    public void WriteTimer(float timer)
    {
        using (StreamWriter sw = File.AppendText(filename))
        {
            sw.WriteLine(timer.ToString("n3") + "\t" + (timer - oldTimer).ToString("n3"));
        }
        oldTimer = timer;
    }

}
