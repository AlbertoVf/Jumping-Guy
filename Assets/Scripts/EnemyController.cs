using Assets.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Fields

    private readonly float velocity = Speeds.ENEMY * 2;
    private Rigidbody2D rb;

    #endregion Fields

    #region Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * velocity;
    }

    #endregion Methods
}
