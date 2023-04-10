using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text ammoText; // Para saber la municion que tiene y mostrala en el camvas.
    public Text healthText;


    // Es una manera sencilla de poder usarlo desde otros scripts
    public static GameManager Instance { get; private set; }    // Para poder usarlo.

    public int gunAmmo = 20;
    public int health = 100;

    private void Awake()
    {
        // La instancia sea igual a la que hemos creado.
        Instance = this;
    }
    private void Update()
    {
        // Paso las variables a ToString()
        // El update es para que vaya actualizando tanto la vida
        // como la municion en el CAMVAS todo el rato.
        ammoText.text = gunAmmo.ToString(); 
        healthText.text = health.ToString();
    }

}
