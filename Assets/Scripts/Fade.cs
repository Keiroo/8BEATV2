using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public string SceneName = "MainMenuScene";
    public float FadeSpeed = 0.005f;
    private Image fadeImage;

    private void OnEnable()
    {
        fadeImage = GetComponent<Image>();
        Time.timeScale = 0f;
        StartCoroutine(FadeScreen());
    }

    IEnumerator FadeScreen()
    {
        while (fadeImage.color.a < 1f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a + FadeSpeed);
            yield return null;
        }
        SceneManager.LoadScene(SceneName);
        Time.timeScale = 1f;
        yield return null;
    }
}
