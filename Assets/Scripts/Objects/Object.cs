using UnityEngine;

public class Object : MonoBehaviour
{

    [SerializeField] private float size;
    [SerializeField] private float neededSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.transform.localScale = new Vector3(size, size, size);

        if(neededSize == 0)
        {
            neededSize = size * 1.01f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player == null) return;
        if (player.size < neededSize) return;

        //Debug.Log(player.size + " - " + neededSize);

        player.Grow(size);
        Destroy(this.gameObject);
    }
}
