using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject pauseMenuUI;


    private bool isPauseMenuOpen = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputManager = InputManager.Instance;

        ExitPauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //if user pressed the toggle pause button and shop menu is NOT open,...
        if (inputManager.TogglePause)
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (isPauseMenuOpen)
        {
            ExitPauseMenu();
        }
        else
        {
            EnterPauseMenu();
        }
    }

    private void ExitPauseMenu()
    {
        Resume();

        pauseMenuUI.SetActive(false);
        isPauseMenuOpen = false;
    }

    private void EnterPauseMenu()
    {
        Pause();
        pauseMenuUI.SetActive(true);
        isPauseMenuOpen = true;
    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
