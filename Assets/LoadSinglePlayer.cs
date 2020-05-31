using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSinglePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadScene() {
        SceneManager.LoadScene("SinglePlayerScene", LoadSceneMode.Single);
    }
   
}
