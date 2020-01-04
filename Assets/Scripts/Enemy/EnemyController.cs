using Assets.Scripts;

using UnityEngine;

/// <summary> Clasa para gestionar a los enemigos </summary>
public class EnemyController : MonoBehaviour
{
    #region Fields

    /// <summary> The velocity. Velocidad de movimiento del enemigo </summary>
    private readonly float velocity = Speeds.ENEMY;

    /// <summary> The rb </summary>
    private Rigidbody2D rb;

    #endregion Fields

    #region Methods

    /// <summary> Called when [trigger enter2 d]. Colisionador con el destructor de enemigos </summary>
    /// <param name="collision"> The collision. </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }

    /// <summary> Starts this instance. </summary>
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * velocity;
    }

    #endregion Methods
}
