using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeController : MonoBehaviour
{
    public Text puntajeText;
    public Text vidaText;
    
    public void AddPoints(int points)
    {
        puntajeText.text = "Puntos : " + points;
    }


    public void AddVida(int vida)
    {
        vidaText.text = "Vida : " + vida;
    }

}
