using System;
using System.Collections.Generic;
using UnityEngine;

public class Parameters : MonoBehaviour
{
    public static float _musicVolume {get; private set;} = 0.5f;
    public static float _soundVolume {get; private set;} = 0.4f;

    public static string _question {get; private set;} = "";

    public static Dictionary<string,string> _logs{get; private set;} = new Dictionary<string,string>();
    public static List<string> _questions{get; private set;} = new List<string>();
    

    void Start()
    {
        DontDestroyOnLoad(this);
    }
    public static void SetMusicVolume(float volume)
    {
        _musicVolume = volume;
    }
    public static void SetSoundVolume(float volume)
    {
        _soundVolume = volume;
    }

    public static void SetQuestion(string question)
    {
        _question = question;
    }
    public static void AddLog(string question,string log)
    {
        _logs.Add(question, log);
    }
    public static void ClearLog()
    {
        _logs.Clear();
    }
}
