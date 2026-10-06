using UnityEngine;

public class Object : MonoBehaviour
{

    [SerializeField] private float size;
    [SerializeField] private float neededSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(size == 0)
        {
            size = (this.transform.localScale.x + this.transform.localScale.y) / 2.0f;
        }

        if(neededSize == 0)
        {
            neededSize = size * 1.1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player == null) return;
        if (player.size < neededSize) return;

        //Debug.Log(player.size + " - " + neededSize);

        player.Grow(size * .66f);
        Destroy(this.gameObject);
    }
}
