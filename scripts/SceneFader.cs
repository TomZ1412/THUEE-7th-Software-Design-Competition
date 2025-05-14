using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image blackImage;
    public float alpha;

    private void Start()
    {
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    public void FadeTo(int index)
    {
        StartCoroutine(FadeOut(index));
    }

    IEnumerator FadeOut(int index)
    {
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        SceneManager.LoadScene(index);
    }
}
