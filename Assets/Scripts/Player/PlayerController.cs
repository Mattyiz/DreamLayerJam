using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public InputManager input; // Include the input system
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movementAxis;

    [SerializeField] private float movementSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (input == null) input = InputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        //Input detection
        movementAxis = input.MoveInput;

    }

    void FixedUpdate()
    {
        //player movement
        rb.linearVelocity = new Vector2(movementAxis.x * movementSpeed, movementAxis.y * movementSpeed);
    }
}
