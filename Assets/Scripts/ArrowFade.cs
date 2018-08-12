using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ArrowFade : MonoBehaviour
{
    [SerializeField]
    private float AnimationSensitivity = 50f;
    [SerializeField]
    private float AnimationSpeed = 0.2f;
    [SerializeField]
    private float AnimationDuration = 2f;
    [SerializeField]
    private float FadeSpeed = 1f;
    [SerializeField]
    private float FadeIntensivity = 0.5f;
    [SerializeField]
    private GameObject Arrows;

    private Image fadeImage;
    private bool fading = false;
    private float timer = 0f;
    private float animTimer = 0f;
    private float orgY;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
        orgY = Arrows.transform.localPosition.y;
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, FadeIntensivity);
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer < AnimationDuration)
        {
            Animate();
        }
        else
        {
            Fade();
        }
    }

    private void Fade()
    {
        if (fadeImage.color.a > 0f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, fadeImage.color.a - (FadeSpeed * Time.deltaTime));

            foreach (Transform child in Arrows.transform)
            {
                child.gameObject.GetComponent<Image>().color = new Color(
                    child.gameObject.GetComponent<Image>().color.r,
                    child.gameObject.GetComponent<Image>().color.g,
                    child.gameObject.GetComponent<Image>().color.b,
                    child.gameObject.GetComponent<Image>().color.a - (FadeSpeed * Time.deltaTime));
            }


        }
        else
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
            Arrows.SetActive(false);
            gameObject.SetActive(false);
            enabled = false;
        }        
    }

    private void Animate()
    {
        animTimer += Time.deltaTime;

        if (animTimer > AnimationSpeed)
        {
            if (Arrows.transform.localPosition.y == orgY)
            {
                Arrows.transform.localPosition = new Vector3(
                    Arrows.transform.localPosition.x,
                    Arrows.transform.localPosition.y + AnimationSensitivity,
                    Arrows.transform.localPosition.z);
            }
            else
            {
                Arrows.transform.localPosition = new Vector3(
                    Arrows.transform.localPosition.x,
                    orgY,
                    Arrows.transform.localPosition.z);
            }
            animTimer = 0f;
        }
    }

}
