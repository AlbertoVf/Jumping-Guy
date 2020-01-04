using Assets.Scripts;
using UnityEngine;

/// <summary> Clase para controlar el personaje </summary>
public class PlayerController : MonoBehaviour
{
    #region Fields

    /// <summary> The animator </summary>
    private Animator animator;

    #endregion Fields

    #region Methods

    /// <summary> Updates the state. </summary>
    /// <param name="state"> The state. </param>
    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            animator.Play(state);
        }
    }

    /// <summary> Starts this instance. </summary>
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary> Updates this instance. Comprueba si se pulsa la tecla de salto </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyControllers.JUMP))
        {
            UpdateState("jump");
        }
    }

    #endregion Methods
}
