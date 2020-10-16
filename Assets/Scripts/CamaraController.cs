using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject Player;
    private Transform _transform;
    private float x, y = 0f;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        x = Player.transform.position.x;
        y = Player.transform.position.y;
        _transform.position = new Vector3(x , y, _transform.position.z );
    }

}
