using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Es una manera sencilla de poder usarlo desde otros scripts
    public static GameManager Instance { get; private set; }    // Para poder usarlo.

    public int gunAmmo = 20;

    private void Awake()
    {
        // La instancia sea igual a la que hemos creado.
        Instance = this;
    }

}
