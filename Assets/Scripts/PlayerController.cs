using Assets.Scripts;
using UnityEngine;

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

    // Start is called before the first frame update
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyControllers.JUMP))
        {
            UpdateState("jump");
        }
    }

    #endregion Methods
}
