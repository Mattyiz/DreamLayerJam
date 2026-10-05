using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    public Vector2 MoveInput { get; private set; }
    public bool TogglePause { get; private set; }


    private PlayerInput _playerInput;

    private InputAction _moveAction;
    private InputAction _togglePauseAction;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();

        SetupInputActions();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {
        _moveAction = _playerInput.actions["Move"];
        _togglePauseAction = _playerInput.actions["TogglePause"];
    }

    private void UpdateInputs()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        TogglePause = _togglePauseAction.WasPressedThisFrame();
    }

}
