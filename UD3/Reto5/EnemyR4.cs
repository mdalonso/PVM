using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyR4 : CharacterR3,IObserver
{
    private int _strength;

    public EnemyR4(string name, int health, int strength) : base(name, health)
    {
        if (strength < 1 || strength > Utilities.MAXSTRENGH)
        {
            _strength = 1;
        }
        else
        {
            _strength = strength;
        }
    }

    public int Strength
    {
        get { return _strength; }
        set
        {
            if (value < 1 || value > Utilities.MAXSTRENGH)
            {
                _strength = 1;
            }
            else
            {
                _strength = value;
            }
        }
    }

    public override void LevelUp()
    {
        _strength++;
        if (_strength > Utilities.MAXSTRENGH)
        {
            _strength = Utilities.MAXSTRENGH;
        }
        else
        {
            Debug.Log("El enemigo ha subido de nivel");
        }
    }

    public void OnAttack()
    {
        Debug.Log(_name + " dice: SOCORRO!!!");
    }

    public void OnLevelUp() { 
    }

}

