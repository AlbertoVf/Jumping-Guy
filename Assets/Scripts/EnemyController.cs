using Assets.Scripts;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region Fields

    private Rigidbody2D rb;
    private float velocity = Speeds.ENEMY;

    #endregion Fields

    #region Methods

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * velocity;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #endregion Methods
}
