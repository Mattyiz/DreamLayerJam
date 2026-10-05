using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField] private Vector3 home;
    [SerializeField] private float radius;
    [SerializeField] private float moveSpeed;

    private Vector3 nextPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNextPos();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position != nextPos)
        {
            

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
