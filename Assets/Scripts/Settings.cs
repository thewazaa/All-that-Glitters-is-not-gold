using System;
using UnityEngine;
using UnityEngine.Audio;

public class Settings
{
    private static Settings _instance;
    public static Settings Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Settings();
            return _instance;
        }
    }

    private readonly AudioMixer mixer = Resources.Load("AudioMixer") as AudioMixer;

    public bool Music
    {
        get
        {
            bool tmp = Convert.ToBoolean(PlayerPrefs.GetInt("music", 1));
            SetMusic(tmp);
            return tmp;
        }
        set
        {
            PlayerPrefs.SetInt("music", Convert.ToInt32(value));
            SetMusic(value);
        }
    }

    public bool Sound
    {
        get
        {
            bool tmp = Convert.ToBoolean(PlayerPrefs.GetInt("sound", 1));
            SetSound(tmp);
            return tmp;
        }
        set
        {
            PlayerPrefs.SetInt("sound", Convert.ToInt32(value));
            SetSound(value);
        }
    }

    private Settings() { }

    private void SetMusic(bool check)
    {
        mixer.SetFloat("MusicVol", check ? 0f : -80f);
    }

    private void SetSound(bool check)
    {
        mixer.SetFloat("SoundVol", check ? 0f : -80f);
    }
}
