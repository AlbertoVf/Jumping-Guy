using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// Clase para gestionar las teclas.
    /// </summary>
    public class KeyControllers
    {
        #region Public Fields

        /// <summary>
        /// The jump
        /// Tecla para realizar un salto
        /// </summary>
        public const KeyCode JUMP = KeyCode.Space;

        /// <summary>
        /// The start
        /// Tecla para iniciar el juego.
        /// </summary>
        public const KeyCode START = KeyCode.Return;

        #endregion Public Fields
    }

    public class MouseControllers
    {
        #region Public Fields

        /// <summary>
        /// The start.
        /// Boton primario del raton.
        /// </summary>
        public const int START = 0;

        #endregion Public Fields
    }

    /// <summary>
    /// Clase para gestionar las velocidades del juego.
    /// </summary>
    public class Speeds
    {
        #region Public Fields

        /// <summary>
        /// The paralax.
        /// Velocidad delfondo
        /// </summary>
        public const float PARALAX = 0.05f;

        #endregion Public Fields
    }
}