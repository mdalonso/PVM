using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;
    // Start is called before the first frame update
    

    public void TakeDamage()
    {
        _health--;

        if (_health <=0)
        {
            //Game Over
        }
    }
}
