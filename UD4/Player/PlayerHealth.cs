using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _health;

    public int Health { get => _health; 
        set
        {
            _health = value;
            UIManager.Instance.UpdateUIHealth(value);
        }
    }


    // Start is called before the first frame update

    private void Start()
    {
        UIManager.Instance.UpdateUIHealth(Health);
    }
    public void TakeDamage()
    {
        Health--;

        if (Health <=0)
        {
            UIManager.Instance.ShowGameOverScreen();
        }
    }
}
