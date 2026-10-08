using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu Instance;

    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject winScreenUI;


    private bool isPauseMenuOpen = false;
    private bool isWinScreenOpen = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

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
        if (isWinScreenOpen) return;

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

    public void Win()
    {
        Pause();
        winScreenUI.SetActive(true);
        isWinScreenOpen = true;
    }
}
