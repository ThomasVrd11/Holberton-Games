using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ToLoadingScene()
    {
        SceneManager.LoadScene("Loading Scene");
    }

    public void ToGameSelectorScene()
    {
        SceneManager.LoadScene("Game Selector Scene");
    }
}