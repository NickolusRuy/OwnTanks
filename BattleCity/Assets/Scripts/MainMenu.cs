using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    private const int START_LEVEL = 1;


    public void StartGame()
    {
        SceneManager.LoadScene(START_LEVEL);
    }
}
