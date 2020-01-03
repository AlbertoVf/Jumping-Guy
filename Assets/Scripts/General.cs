using UnityEngine;

namespace Assets.Scripts
{
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
        public const float ENEMY = 0.2f;

        /// <summary> The paralax. Velocidad delfondo </summary>
        public const float PARALAX = 0.05f;

        #endregion Fields
    }
}
