using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class end_screen_script : MonoBehaviour
{
    public TextMeshProUGUI  text;
    private float timeMultiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        //TextMeshProUGUI.CrossFadeAlpha(1.0f, 0.05f, false);
        StartCoroutine(FadeInText(0.5f, text));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(0);
        }

    }

    private IEnumerator FadeInText(float timeSpeed, TextMeshProUGUI text)
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while (text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime * timeSpeed));
            yield return null;
        }
    }

    public void FadeInText(float timeSpeed = -1.0f)
    {
        if (timeSpeed <= 0.0f)
        {
            timeSpeed = timeMultiplier;
        }
        StartCoroutine(FadeInText(timeSpeed, text));
    }
}
