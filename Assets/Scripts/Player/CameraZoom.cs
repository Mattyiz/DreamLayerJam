using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    private float cameraSize;
    private float velocity = 0f;

    [SerializeField] private Camera cam;
    [SerializeField] private float zoomModifier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraSize = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (cam.orthographicSize == cameraSize) return;

        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, cameraSize, ref velocity, .5f);
    }

    public void Grow(float sizeToAdd)
    {
        cameraSize += sizeToAdd * zoomModifier;
    }
}
