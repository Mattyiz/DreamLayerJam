using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private Vector3 home;
    [SerializeField] private float radius;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Vector3 nextPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        home = this.transform.position;

        SetNextPos();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = (nextPos - this.transform.position);

        if (Mathf.Abs(distance.x + distance.y) > moveSpeed)
        {
            rb.linearVelocity = (distance.normalized * moveSpeed);
        }
        else
        {
            SetNextPos();
        }
    }

    private void SetNextPos()
    {
        nextPos = new Vector3(home.x + Random.Range(radius * -1, radius), home.y + Random.Range(radius * -1, radius), 0);
    }
}
