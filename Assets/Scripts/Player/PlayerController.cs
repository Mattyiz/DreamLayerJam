using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public InputManager input; // Include the input system
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movementAxis;

    [SerializeField] private float movementSpeed;
    [SerializeField] private CameraZoom cameraZoom;


    public float size;
    private float velocity = 0;


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

        if (this.transform.localScale.x == size) return;

        this.transform.localScale = new Vector3(Mathf.SmoothDamp(this.transform.localScale.x, size, ref velocity, .5f),
            Mathf.SmoothDamp(this.transform.localScale.x, size, ref velocity, .5f),
            1);
    }

    public void Grow(float sizeToAdd)
    {
        size += sizeToAdd;
        movementSpeed += sizeToAdd;
        cameraZoom.Grow(sizeToAdd);

        //this.transform.localScale = new Vector3(size, size, size);
    }
}
