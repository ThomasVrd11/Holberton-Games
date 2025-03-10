using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public Slider progressBar;
    public TextMeshProUGUI progressText;

    private void Start()
    {
        StartCoroutine(LoadSceneAsync("Menu Scene"));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        float loadTime = 3f;
        float elapsedTime = 0f;

        while (elapsedTime < loadTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / loadTime);

            progressBar.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";

            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
