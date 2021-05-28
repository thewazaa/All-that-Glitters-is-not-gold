using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class to gestionate languages
/// Usage:
/// - Fill in the class language all the variables language dependent. It can include sprites, but this version is thought for texts
///   to manage images in need some changes to avoid memory problems
/// - use these two functions:
///    LanguageManager.ListLanguages();
///    LanguageManager.Language = "Spanish"
///    LanguageManager.Text.VariableName
/// </summary>
public class LanguageManager
{
    private const string LANGUAGE = "language";
    private const string DEFAULT_LANGUAGE = "English";

    private static LanguageManager _instance;
    public static LanguageManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new LanguageManager();
            return _instance;
        }
    }

    private Language _text;
    public Language Text
    {
        get
        {
            if (_text == null || _text.languageName != Language)
                _text = Resources.LoadAll<Language>("Languages").First(item => item.languageName == Language);
            return _text;
        }
    }

    public string Language
    {
        get
        {
            string tmp = PlayerPrefs.GetString(LANGUAGE);
            if (tmp == null || tmp == "") {
                Language = Application.systemLanguage.ToString();
                tmp = PlayerPrefs.GetString(LANGUAGE);
            }
            return tmp;
        }
        set
        {
            if (ListLanguages().Contains(Application.systemLanguage.ToString()))
                PlayerPrefs.SetString(LANGUAGE, value);
            else
                PlayerPrefs.SetString(LANGUAGE, DEFAULT_LANGUAGE);
        }
    }

    private LanguageManager() { }

    public string[] ListLanguages() => Resources.LoadAll<Language>("Languages").Select(item => item.languageName).ToArray();
}
