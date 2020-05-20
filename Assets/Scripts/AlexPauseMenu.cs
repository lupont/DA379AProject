using UnityEngine;
using UnityEngine.SceneManagement;

public class AlexPauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playerUI;
    public GameObject pauseMenu;
    public GameObject optionsMenu;
    public string menuSceneName;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        playerUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // TODO should only pause time in single player mode
        GameIsPaused = false;
    }

    void Pause()
    {
        playerUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
        Time.timeScale = 0f; // TODO should only pause time in single player mode
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menuSceneName);
    }

    public void Options()
    {
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
