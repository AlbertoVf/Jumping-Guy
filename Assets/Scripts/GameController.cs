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

    public GameState gameState = GameState.Idle;

    /// <summary>
    /// The platform.
    /// Escenario sobre el que se moveran los personajes.
    /// </summary>
    public RawImage platform;

    public GameObject uiIdle;

    #endregion Public Fields

    #region Public Enums

    public enum GameState { Idle, Playing };

    #endregion Public Enums

    #region Private Methods

    /// <summary>
    /// Paralaxes this instance.
    /// Ejecucion de un efecto paralax al fondo y la plataforma.
    /// </summary>
    private void Paralax()
    {
        float finalSpeed = Speeds.PARALAX * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 2f, 0f, 1f, 1f);
    }

    /// <summary>
    /// Pausars the iniciar.
    /// Comprueba si el juego se inicia.
    /// </summary>
    /// <returns>true si se inicia el juego</returns>
    private bool PausarIniciar()
    {
        if (Input.GetKeyDown(KeyControllers.START) || Input.GetMouseButtonDown(MouseControllers.START))
        {
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    /// <summary>
    /// Updates this instance.
    /// Iniciar el juego.
    /// </summary>
    private void Update()
    {
        if (gameState == GameState.Idle && PausarIniciar())
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
        }

        if (gameState == GameState.Playing)
        {
            Paralax();
        }
    }

    #endregion Private Methods
}