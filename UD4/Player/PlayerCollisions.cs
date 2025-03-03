using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    PlayerHealth _playerHealth;
    // Start is called before the first frame update

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }
    
    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _playerHealth.TakeDamage();
        }
    }
}
