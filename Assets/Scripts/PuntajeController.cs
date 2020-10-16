using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeController : MonoBehaviour
{
    public int points = 0;
    
    public void AddPoints(int points)
    {
        this.points += points;
    }

    public int GetPoints()
    {
        return points;
    }
}
