using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerR4 : CharacterR3,IObserver
{
    private int _experience;

    public PlayerR4(string name, int health, int xp) : base(name, health)
    {
        _experience = Mathf.Max(0, xp);
    }

    public int Experience
    {
        get { return _experience; }
        set { _experience = Mathf.Max(0, value); }
    }


    public void GainExperience(int xp)
    {
        int aux = _experience;

        _experience += xp;

        if ((int)(aux / Utilities.EXPERIENCEPERLEVEL) < (int)(_experience / Utilities.EXPERIENCEPERLEVEL))
        {
            LevelUp();
        }
    }

    public void Attack(EnemyR4 enemy)
    {
        System.Random random = new System.Random();
        int numeroAleatorio = random.Next(Utilities.MINRANGEATTACK, Utilities.MAXSTRENGH); // El límite superior es exclusivo
        Debug.Log("¿Atacamos?: " + numeroAleatorio);
        if (numeroAleatorio > 0)
        {

            Debug.Log("Estamos atacando");
            Debug.Log("Le quitamos vida: " + 6 / enemy.Strength);

            enemy.TakeDamage(6 / enemy.Strength);

            Debug.Log("El enemigo ahora tiene de vida: " + enemy.Health);

            if (!enemy.IsAlive())
            {

                Debug.Log("El enemigo ha muerto, así que subimos la experiencia");
                int previousXP = this.Experience;
                this.Experience += 50;
                Debug.Log("Experiencia previa:" + previousXP + " Experiencia actual:" + this.Experience);
                if (Math.Floor((float)previousXP / Utilities.EXPERIENCEPERLEVEL) < Math.Floor((float)this.Experience / Utilities.EXPERIENCEPERLEVEL))
                {

                    LevelUp();
                }
            }

        }
        else
        {
            Debug.Log("Fallamos el ataque");
            enemy.LevelUp();
            ObserverManager.Instance.NotifyLevelUpEvent();
        }
    }



    public override void LevelUp()
    {
        this.Level++;
        Debug.Log("El jugador ha subido de nivel");
    }

    public void OnAttack()
    {
        
    }
    public void OnLevelUp()
    {
        Debug.Log(_name+" dice: Tengo miedo");
    }
   


}
