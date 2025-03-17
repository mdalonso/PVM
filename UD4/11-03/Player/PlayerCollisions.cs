using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    PlayerHealth _playerHealth;
    PlayerShooting _playerShooting;

    [SerializeField] GameStats _gameStats;

    // Start is called before the first frame update

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerShooting = GetComponent<PlayerShooting>();
    }
    
    // Update is called once per frame
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _playerHealth.TakeDamage();
        }

        if (collision.CompareTag("PowerUp"))
        {
            switch (collision.GetComponent<PowerUp>().powerUpType)
            {
                case PowerUp.PowerUpType.FireRateIncrease:
                    _playerShooting.FireRate++;
                    Debug.Log(_playerShooting.FireRate);
                    break;

                case PowerUp.PowerUpType.PowerShot:
                    _playerShooting.PowerShotEnabled = true;
                    break;

            }
            Destroy(collision.gameObject);
        }
       
    }
}
