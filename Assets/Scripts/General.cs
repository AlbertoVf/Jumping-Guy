using UnityEngine;

namespace Assets.Scripts
{
    /// <summary> Clase para gestionar el audio </summary>
    public class Audio
    {
        #region Methods

        /// <summary> Establecers the audio. </summary>
        /// <param name="audioSource"> The audio source. </param>
        /// <param name="clip">        The clip. </param>
        public static void EstablecerAudio(AudioSource audioSource, AudioClip clip)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }

        #endregion Methods
    }

    /// <summary> Clase para gestionar las teclas. </summary>
    public class KeyControllers
    {
        #region Fields

        /// <summary> The jump. Tecla para realizar un salto </summary>
        public const KeyCode JUMP = KeyCode.Space;

        /// <summary> The start. Tecla para iniciar el juego. </summary>
        public const KeyCode START = KeyCode.Space;

        #endregion Fields
    }

    /// <summary> Clase para gestionar los controles a traves de un raton </summary>
    public class MouseControllers
    {
        #region Fields

        /// <summary> The jump. Boton para realizar el salto. </summary>
        public const int JUMP = 0;

        /// <summary> The start. Boton primario del raton. </summary>
        public const int START = 0;

        #endregion Fields
    }

    /// <summary> Clase para gestionar las velocidades del juego. </summary>
    public class Speeds
    {
        #region Fields

        /// <summary> The enemy. Velocidad del enemigo. </summary>
        public const float ENEMY = 3.25f;

        /// <summary> The paralax. Velocidad delfondo </summary>
        public const float PARALAX = 0.04f;

        #endregion Fields
    }

    /// <summary> Clase para gestionar los tiempos de aparicion del enemigo </summary>
    public class Times
    {
        #region Fields

        /// <summary> The enemygeneratorfast. EL enemigo aparece cada 0.75s. </summary>
        public const float ENEMYGENERATORFAST = 0.75f;

        /// <summary> The enemygeneratornormal. El enmigo aparece cada 2s. </summary>
        public const float ENEMYGENERATORNORMAL = 2f;

        /// <summary> The enemygeneratorslow. El enmigo aparece cada 5s. </summary>
        public const float ENEMYGENERATORSLOW = 5f;

        #endregion Fields
    }
}
