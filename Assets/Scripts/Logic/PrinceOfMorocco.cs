using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrinceOfMorocco : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string textToShow;

    private void Awake() => text = GetComponentInChildren<TextMeshProUGUI>();

    private void Start() => textToShow = LanguageManager.Instance.Text.allThatGlittersIsNotGold;

    public IEnumerator CoroutineWriteText()
    {
        for (int i = 1; i <= textToShow.Length; i++)
        {
            text.text = textToShow.Substring(0, i);
            yield return new WaitForFixedUpdate();
        }
        GameManager.Instance.SetGlitterOn();
    }
}
