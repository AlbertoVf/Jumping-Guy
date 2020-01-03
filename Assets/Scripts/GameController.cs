using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Public Fields

    /// <summary>
    /// The background.
    /// Fondo del escenario
    /// </summary>
    public RawImage background;

    /// <summary>
    /// The platform.
    /// Escenario sobre el que se moveran los personajes.
    /// </summary>
    public RawImage platform;

    #endregion Public Fields

    #region Private Methods

    // Start is called before the first frame update
    private void Start()
    {
    }

    /// <summary>
    /// Updates this instance.
    /// Ejecucion de un efecto paralax al fondo y la plataforma
    /// </summary>
    private void Update()
    {
        float finalSpeed = Speeds.PARALAX * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 2f, 0f, 1f, 1f);
    }

    #endregion Private Methods
}