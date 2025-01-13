using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        // Incrementar el contador global cuando el jugador presione la tecla espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.IncrementCounter();
        }
    }
}
