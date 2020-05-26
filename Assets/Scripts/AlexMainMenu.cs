
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlexMainMenu : MonoBehaviour
{

    [SerializeField]
    private string gameSceneName = null;

    public void Start()
    {
        Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
