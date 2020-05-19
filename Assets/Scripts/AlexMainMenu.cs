
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlexMainMenu : MonoBehaviour
{

    [SerializeField]
    private string gameSceneName = null;

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
