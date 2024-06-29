using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}