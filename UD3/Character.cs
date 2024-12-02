using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{

    //Character Fase 1*************************

    //El nombre de player será una propiedad pública que puede ser accedida desde fuera de la clase.
    public string playerName;
    
    /*Character Fase 2 (incluimos el campo _health PRIVATE***************************
     * Esto requiere:
     * - modificar el constructor de Character
     * - Crear propiedad Health con los getters y los setters
     * - Cambiar la llamada al constructor en la clase Play para incluir el nuevo campo _health.
     * - Cambiar el método Start de la clase Play para ostrar el valor del campo _health usando la propiedad
    */

    //El campo health es privado por lo que sólo puede ser accedido desde el interior de la clase.
    //Para poder acceder a su valor es necesaria la definición de getters y setters mediante una propiedad.
    private int _health;

    /*Character Fase 3 (incluimos el campo speed INTERNAL***************************
    * Esto requiere:
    * - modificar el constructor de Character
    * - Cambiar la llamada al constructor en la clase Play para incluir el nuevo campo speed.
    * - Cambiar el método Start de la clase Play para Mostrar el valor del campo SPEED
   */

    //internal indica que sólo es accesible dentro del mismo ensamblado
    internal int speed;

    /*Character Fase 4 (incluimos el campo _level PROTECTED***************************
   * Esto requiere:
   * - modificar el constructor de Character
   * - Cambiar la llamada al constructor en la clase Play para incluir el nuevo campo _level.
   * - Crear la propiedad Level con los getters y los setters
   * - Cambiar el método Start de la clase Play para Mostrar el valor del campo _level usando la propiedad
  */

    //Protected es accesible desde dentro de la clase y de sus clases derivadas. 
    //ESto lo probaremos cuando veamos la herencia
    protected int _level;

    //Definimos el constructor de la clase Player para inicializar los campos
    public Character(string playerName, int health,int speed, int level)
    {
        this.playerName = playerName;
        this._health = health;
        this.speed = speed;
        this._level = level;
    }


    //La propiedad Health define los getters y los setters de acceso al campo privado health.
    //Las propiedades deben definirse como públicas para poder utilizarlas fuera de la clase.
    public int Health
    {
        //El getter devuelve el valor de la propiedad.
        get { return _health; }
        //El setter establece el valor de la propiedad
        set
        {
            _health = Mathf.Max(0, value); // Asegura que la salud no sea negativa (si el valor es negativo,le asignará 0)
            if (_health == 0)
                Die();
        }
    }
    //La propiedad Level define los getters y setters de acceso al campo protected _level.
    public int Level
    {
        get { return _level; }
        set
        {
            _level = Mathf.Max(0, value);
        }
    }

    //El método Die sólo es accesible desde el interior de la clase. Se llama en el setter de health
    private void Die()
    {
        Debug.Log($"{playerName} has died.");
       
    }
    
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    //Se define un método virtual que se reescribirá en las clases derivadas
    public virtual void ShowMessage()
    {
        Debug.Log("**********************INFORME DE PERSONAJE *****************************");
    }

   
}
