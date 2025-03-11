using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health = 10;
    //_invulnerability indica si el player es invulnerable o no
    [SerializeField] private bool _invulnerability = false; //Lo serializamos para poder verlo en el inspector y ver si funciona
    private int _invulnerableDelay = 3;//Tiempo de invulnerabilidad del player

    [SerializeField] GameStats _gameStats;

    public int Health { get => _health;
        set {
            _health = value;
            //Aprovechamos el setter del campo _health para actualizar el HUD cada vez que se 
            //produzca un cambio en ese campo.
            UIManager.Instance.UpdateUIHealth(_health);
        }  }

    private void Start()
    {
        UIManager.Instance.UpdateUIHealth(_health);
    }

    public void TakeDamage()
    {
        //Si el Player no es invulnerable se le resta vida y se convierte en invulnerable.
        if (_invulnerability) return;
        
            Health--;
            _invulnerability=true;
            StartCoroutine(MakeVulnerableAgain());

            if (Health <= 0)
            {
                Die();
            }
        
    }

    private void Die()
    {
        Debug.Log("Game Over");
        
        // Implementar lógica de fin de juego
        _gameStats.GameOver = true;
        //Mostramos la pantalla de GameOver cuando el Player muere
        UIManager.Instance.ShowGameOverScreen();

    }

    //toBeInvulnerableRoutine --> Devuelve la vulnerabilidad al player pasado el tiempo establecido por _invulnerableDelay
    IEnumerator MakeVulnerableAgain()
    {
        yield return new WaitForSeconds(_invulnerableDelay);
        _invulnerability = false ;
    }

    
}

