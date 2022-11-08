using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PauseController : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

    public UnityEvent GamePaused;
    public UnityEvent GameResumed;

    private bool _isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0;
                GamePaused.Invoke();
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                GameResumed.Invoke();
            }
        }
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        _isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
    static void OnBeforeSplashScreen()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
