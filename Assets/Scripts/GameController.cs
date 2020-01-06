using System;
using Assets.Scripts;

using UnityEngine;
using UnityEngine.SceneManagement;
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

    /// <summary> The point text. Texto con la puntuacion actual </summary>
    public Text pointText;

    /// <summary> The record text. Texto con el record de puntos </summary>
    public Text recordText;

    /// <summary> The UI idle. Interfaz visible durante la pausa </summary>
    public GameObject uiIdle;

    /// <summary> The UI score. Interfaz con la puntuacion </summary>
    public GameObject uiScore;

    /// <summary> The background audio </summary>
    private AudioSource backgroundAudio;

    /// <summary> The points. Puntos actuales </summary>
    private int points = 0;

    #endregion Fields

    #region Enums

    /// <summary>
    ///  Posibles estados del juego. Pausado o Jugando, muerto, preparado para el reinicio
    /// </summary>
    public enum GameState { Idle, Playing, Ended, Ready };

    #endregion Enums

    #region Methods

    /// <summary> Gets the record. </summary>
    /// <returns> record actual </returns>
    public int GetRecord()
    {
        return PlayerPrefs.GetInt("record", 0);
    }

    public void IncreasePoints()
    {
        points++;
        pointText.text = "Points: " + points.ToString();
        if (points > GetRecord())
        {
            SetRecordText();
            SetRecord(points);
        }
    }

    public void ResetTimeScale(float timeScale = 1f)
    {
        CancelInvoke("IncrementTimeScale");
        Time.timeScale = timeScale;
    }

    /// <summary> Restarts the game. </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        ResetTimeScale();
    }

    /// <summary> Sets the record. Actualiza el record actual </summary>
    /// <param name="points"> The points. </param>
    public void SetRecord(int points)
    {
        PlayerPrefs.SetInt("record", points);
    }

    /// <summary> Aumenta the dificultad. </summary>
    private void AumentarDificultad()
    {
        InvokeRepeating("IncrementTimeScale", Times.SCALETIME, Times.SCALETIME);
    }

    /// <summary> Games the time scale. Aumenta la velocidad del juego </summary>
    private void IncrementTimeScale()
    {
        Time.timeScale += Times.SCALEINCREMENT;
    }

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

    /// <summary> Sets the record text. </summary>
    private void SetRecordText()
    {
        recordText.text = "Record: " + GetRecord().ToString();
    }

    /// <summary> Starts this instance. </summary>
    private void Start()
    {
        backgroundAudio = GetComponent<AudioSource>();
        SetRecordText();
    }

    /// <summary> Starts the player. Da inicio a la partida </summary>
    private void StartPlayer()
    {
        gameState = GameState.Playing;
        backgroundAudio.Play();
        uiIdle.SetActive(false);
        uiScore.SetActive(true);
        player.SendMessage("UpdateState", "run");
        player.SendMessage("ParticulasIniciar");
        enemyGenerator.SendMessage("StartGenerator");
    }

    /// <summary> Updates this instance. Iniciar el juego. </summary>
    private void Update()
    {
        if (gameState == GameState.Idle && Iniciar())
        {
            StartPlayer();
            AumentarDificultad();
        }
        else if (gameState == GameState.Playing)
        {
            Paralax();
        }
        else if (gameState == GameState.Ready)
        {
            if (Iniciar())
            {
                RestartGame();
            }
        }
    }

    #endregion Methods
}
