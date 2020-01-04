using Assets.Scripts;

using UnityEngine;
using UnityEngine.UI;

/// <summary> Clase para controlar todos los elementos en escena </summary>
public class GameController : MonoBehaviour
{
    #region Fields

    /// <summary> The background. Fondo del escenario </summary>
    public RawImage background;

    /// <summary> The enemy generator. Accede al generador de enemigos </summary>
    public GameObject enemyGenerator;

    /// <summary> The game state. Indica si el juego esta pausado </summary>
    public GameState gameState = GameState.Idle;

    /// <summary> The platform. Escenario sobre el que se moveran los personajes. </summary>
    public RawImage platform;

    /// <summary> The player. Elemento jugador </summary>
    public GameObject player;

    /// <summary> The UI idle. Interfaz visible durante la pausa </summary>
    public GameObject uiIdle;

    #endregion Fields

    #region Enums

    /// <summary> Posibles estados del juego. Pausado o Jugando </summary>
    public enum GameState { Idle, Playing };

    #endregion Enums

    #region Methods

    /// <summary> Pausars the iniciar. Comprueba si el juego se inicia. </summary>
    /// <returns> true si se inicia el juego </returns>
    private bool Iniciar()
    {
        if (Input.GetKeyDown(KeyControllers.START) || Input.GetMouseButtonDown(MouseControllers.START))
            return true;
        return false;
    }

    /// <summary> Paralaxes this instance. Ejecucion de un efecto paralax al fondo y la plataforma. </summary>
    private void Paralax()
    {
        float finalSpeed = Speeds.PARALAX * Time.deltaTime;
        background.uvRect = new Rect(background.uvRect.x + finalSpeed, 0f, 1f, 1f);
        platform.uvRect = new Rect(platform.uvRect.x + finalSpeed * 2f, 0f, 1f, 1f);
    }

    /// <summary> Updates this instance. Iniciar el juego. </summary>
    private void Update()
    {
        if (gameState == GameState.Idle && Iniciar())
        {
            gameState = GameState.Playing;
            uiIdle.SetActive(false);
            player.SendMessage("UpdateState", "run");
            enemyGenerator.SendMessage("StartGenerator");
        }

        if (gameState == GameState.Playing)
        {
            Paralax();
        }
    }

    #endregion Methods
}
