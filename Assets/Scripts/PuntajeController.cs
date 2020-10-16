using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeController : MonoBehaviour
{
    public int points = 0;
    public int vida = 0;
    public Text puntajeText;
    public Text vidaText;
    
    public void AddPoints(int points)
    {
        this.points += points;
        puntajeText.text = "Puntaje : " + GetPoints();
    }

    public int GetPoints()
    {
        return points;
    }

    public void AddVida(int vida)
    {
        this.vida += vida;
        vidaText.text = "Vida : " + GetVida();
    }

    public int GetVida()
    {
        return vida;
    }
}
