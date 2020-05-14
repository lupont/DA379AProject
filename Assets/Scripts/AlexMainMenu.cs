
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlexMainMenu : MonoBehaviour
{

    [SerializeField]
    private string gameSceneName;

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
