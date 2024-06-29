using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public Text loadingText;
    public Text tipsText;
    public Image progressBar;
    public string[] tips;
    public string firstTip;
    public float fadeDuration = 1.5f;
    public float minLoadTime = 3f;
    public float maxLoadTime = 6f;
    private bool firstLoad;

    private void Start()
    {
        firstLoad = PlayerPrefs.GetInt("FirstLoad", 1) == 1;
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        // Display the first tip if it's the first load
        if(firstLoad)
        {
            tipsText.text = firstTip;
            PlayerPrefs.SetInt("FirstLoad", 0);
        }
        else
        {
            tipsText.text = tips[Random.Range(0, tips.Length)];
        }

        StartCoroutine(FadeLoadingText());

        float loadTime = Random.Range(minLoadTime, maxLoadTime);
        float elapsedTime = 0f;

        while(elapsedTime < loadTime)
        {
            elapsedTime += Time.deltaTime;
            progressBar.fillAmount = Mathf.Clamp01(elapsedTime / loadTime);
            yield return null;
        }

        SceneManager.LoadScene("Level1");
    }

    IEnumerator FadeLoadingText()
    {
        while(true)
        {
            // Fade in
            for (float t = 0; t < fadeDuration; t += Time.deltaTime)
            {
                float alpha = t / fadeDuration;
                loadingText.color = new Color
                    (loadingText.color.r, loadingText.color.g, loadingText.color.b, alpha);
                yield return null;
            }
            // Fade out
            for(float t = fadeDuration; t > 0; t -= Time.deltaTime)
            {
                float alpha = t / fadeDuration;
                loadingText.color = new Color
                    (loadingText.color.r, loadingText.color.g, loadingText.color.b, alpha);
                yield return null;
            }
        }
    }
}