using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterR3:IAttackable
{
    protected string _name;
    protected int _health;
    protected int _level;

    public CharacterR3(string name, int health)
    {
        _name = name;
        _health = Mathf.Max(0, health);
        _level = 1;
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Health
    {
        get { return _health; }
        set { _health = Mathf.Max(0, value); }
    }
    public int Level
    {
        get { return _level; }
        set { _level = Mathf.Max(1, value); }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health < 0)
        {
            _health = 0;
        }
    }

    public virtual void LevelUp()
    {
        Debug.Log("Subiendo de nivel");
    }

    public bool IsAlive()
    { 
        return _health > 0;
    }
}
