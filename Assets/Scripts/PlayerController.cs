using Assets.Scripts;

using UnityEngine;

/// <summary> Clase para controlar el personaje </summary>
public class PlayerController : MonoBehaviour
{
    #region Fields

    /// <summary> Clip de audio de mueste </summary>
    public AudioClip dieClip;

    /// <summary> The enemy generator </summary>
    public GameObject enemyGenerator;

    /// <summary> The game controller </summary>
    public GameController gameController;

    /// <summary> Clip de audio de salto </summary>
    public AudioClip jumpClip;

    /// <summary> The particle. Particulas de polvo cuando corre </summary>
    public ParticleSystem particle;

    /// <summary> Clip de audio de obtener punto </summary>
    public AudioClip pointClip;

    /// <summary> The player animator </summary>
    private Animator playerAnimator;

    /// <summary> The player audio. </summary>
    private AudioSource playerAudio;

    #endregion Fields

    #region Methods

    /// <summary> Updates the state. </summary>
    /// <param name="state"> The state. </param>
    public void UpdateState(string state = null)
    {
        if (state != null)
        {
            playerAnimator.Play(state);
        }
    }

    private void Dead()
    {
        ParticulasStop();
        UpdateState("dead");
        gameController.GetComponent<GameController>().gameState = GameController.GameState.Ended;
        enemyGenerator.SendMessage("CancellGenerator");

        gameController.GetComponent<AudioSource>().Stop();
        playerAudio.Play();
    }

    /// <summary> Games the ready. Establece que el nivel esta listo para reiniciar </summary>
    private void GameReady()
    {
        gameController.GetComponent<GameController>().gameState = GameController.GameState.Ready;
    }

    /// <summary> Ejecuta el salto del personaje </summary>
    private void Jump()
    {
        Audio.EstablecerAudio(playerAudio, jumpClip);
        UpdateState("jump");
    }

    /// <summary> Called when [trigger enter2 d]. Comprueba si colisiono con un enemigo </summary>
    /// <param name="collision"> The collision. </param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerAudio.clip = dieClip;
        if (collision.gameObject.tag == "Enemy")
        {
            Dead();
        }
        else if (collision.gameObject.tag == "Point")
        {
            gameController.SendMessage("IncreasePoints");
            Audio.EstablecerAudio(playerAudio, pointClip);
        }
    }

    /// <summary> Iniciars the particulas. </summary>
    private void ParticulasIniciar()
    {
        particle.Play();
    }

    /// <summary> Stops the particulas. </summary>
    private void ParticulasStop()
    {
        particle.Stop();
    }

    /// <summary> Starts this instance. </summary>
    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    /// <summary> Updates this instance. Comprueba si se pulsa la tecla de salto </summary>
    private void Update()
    {
        //Comprueba si esta jugando
        bool gamePlaying = gameController.GetComponent<GameController>().gameState == GameController.GameState.Playing;
        if (gamePlaying && Input.GetKeyDown(KeyControllers.JUMP))
        {
            Jump();
        }
    }

    #endregion Methods
}
