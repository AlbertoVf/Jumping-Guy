using Assets.Scripts;

using UnityEngine;

/// <summary> Gestiona el objeto encargado de generar los enemigos </summary>
public class EnemyGeneratorControler : MonoBehaviour
{
    #region Fields

    /// <summary> Prefab del enemigo que se generara </summary>
    public GameObject enemyPrefab;

    /// <summary> Tiempo en el que se genera cada enemigo </summary>
    private float generatorTimer = Times.ENEMYGENERATORNORMAL;

    #endregion Fields

    #region Methods

    /// <summary> Cancela el generador de enemigos </summary>
    public void CancellGenerator()
    {
        CancelInvoke("CreateEnemy");
    }

    /// <summary> Inicia el generador de enemigo cada generatorTimer tiempo. </summary>
    public void StartGenerator()
    {
        InvokeRepeating("CreateEnemy", 0f, generatorTimer);
    }

    /// <summary> Crea enemigos </summary>
    private void CreateEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    #endregion Methods
}
