using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Play : MonoBehaviour
{

    Character personaje;

//Fase 6
     Player player;
    //Creamos un nuevo objeto de tipo Player para probar los atributos estáticos.
    Player player2;

//Fase 7
    Enemy enemy;

   

    //Es conveniente evitar los "valores mágicos" asignados literalmente. Por eso definimos campos públicos que
    //pueden ser serializados.
    public string namePersonnaje = "General";
    public int healthPersonaje=10;
    public int speedPersonaje = 5;
    public int levelPersonaje = 0;

    public string namePlayer = "Hero";
    public int healthPlayer = 20;
    public int speedPlayer = 15;
    public int levelPlayer = 0;
    public int strength = 5;

    public string nameEnemy = "Enemy";
    public int healthEnemy = 2;
    public int speedEnemy = 2;
    public int levelEnemy = 0;
    public int bullets = 100;

    //Creamos un nuevo objeto de tipo 
    public string namePlayer2 = "Hero2";
    public int healthPlayer2 = 20;
    public int speedPlayer2 = 10;
    public int levelPlayer2 = 0;
    public int strength2 = 2;

    //Configuración para un enemigo genérico
   
    public int healthEnemyG = 10;
    public int speedEnemyG = 5;
    public int levelEnemyG = 1;
    public int bulletsG = 100;


  


    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el jugador
        //Los valores que se pasan al constructor se pueden pasar como "valores mágicos" (lo cual es conveniente evitar)
        //o bien como campos que pueden ser configurados mediante serialización.

        //Constructor en Fase 1
        //personaje = new Character(namePersonaje);

        //Constructor en Fase 2
        //personaje = new Character(namePersonnaje,healthPersonaje);

        //Constructor en Fase 3
        //personaje = new Character(namePersonnaje, healthPersonaje,speedPersonaje);

        //Constructor en Fase 4
        //INICIALIZACIÓN DEL PERSONAJE BÁSICO***********************************************
        personaje = new Character(namePersonnaje, healthPersonaje, speedPersonaje, levelPersonaje);



        //Podemos mostrar por consola directamente el nombre del player porque es un campo público.
        Debug.Log("Nombre del personaje: "+ personaje.playerName);

        //Debug.Log(player.health);//Esta línea produce un error de compilación porque health es un campo private
        Debug.Log("El personaje comienza con Health: "+ personaje.Health); //Accedemos al campo privado health mediante la propiedad Health (getter)

        Debug.Log("Velocidad inicial del personaje: "+ personaje.speed);

        Debug.Log("Nivel inicial del personaje: " + personaje.Level);

        //Se llama a la implementación del método ShowMessage definida en la clase Character
        personaje.ShowMessage();

        //INICIALIZACIÓN DEL PLAYER ************************************************************
        player = new Player(namePlayer, healthPlayer, speedPlayer, levelPlayer, strength);

        Debug.Log("Name player: " + player.playerName);
        Debug.Log("Health player: " + player.Health); //Accedemos al campo privado health mediante la propiedad Health (getter)
        Debug.Log("Speed player: " + player.speed);
        //Debug.Log("Level player: " + player._level);//Esta línea produce un error ya que _level es protected
        Debug.Log("Level player: " + player.Level);

        //Se llama a la REDEFINICIÓN del método ShowMessage() (método virtual)
        player.ShowMessage();

        //INICIALIZACIÓN DEL ENEMY ************************************************************
        enemy = new Enemy(nameEnemy, healthEnemy, speedEnemy, levelEnemy, bullets);
        //Como Enemy no redefine el método ShowMessage, utiliza el de la clase base
        enemy.ShowMessage();
        Statistics.enemies.Add(enemy);//Para que estén todos los enemigos en la lista hay que meterlo


        player2 = new Player(namePlayer2, healthPlayer2, speedPlayer2, levelPlayer2, strength2);
        //Uso de clase estática VectorUtils***********************************************
        //Vector3 pointA = new Vector3(0, 0, 0);
        //Vector3 pointB = new Vector3(3, 4, 0);

        //float distance = VectorUtils.CalculateDistance(pointA, pointB);
        //Debug.Log("Distancia entre los puntos: " + distance);

        //Vector3 direction = VectorUtils.CalculateDirection(pointA, pointB);
        //Debug.Log("Dirección de A --> B: " + direction);

        //Vector3 randomPoint = VectorUtils.GetRandomPoint(Vector3.zero, 5.0f);
        //Debug.Log("Punto aleatorio alrededor de un punto: " + randomPoint);
        //************************************************************************************

    }

    // Update is called once per frame
    void Update()
    {
        //Cuando pulsemos la tecla X se incrementa la salud del personaje.
        if (Input.GetKey(KeyCode.X))
        {
            personaje.Health++;//Hace uso del setter
            Debug.Log(personaje.Health);
        }
        
        //Incrementaremmos el nivel del personaje en cada Frame (así probamos getter y setter)
        //personaje.Level+=100;
        //Debug.Log("Nivel actual del personaje: "+ personaje.Level);

        //Probamos el método TakeDamage implementado en la clase base Character.
        if (Input.GetKey(KeyCode.Space))
        {
            enemy.TakeDamage(1);
        }
        //Probamos el método Shoot implementado en la clase derivada Enemy
        if (Input.GetKey(KeyCode.Backspace))
        {
            enemy.Shoot();  
        }

        //Cada vez que pulsemos la tecla E se crea un nuevo enemigo hasta alcanzar el máximo.
        if (Input.GetKeyDown(KeyCode.E))
        {
                if (Enemy.nEnemies < Statistics.MaxEnemies)
                {
                    Statistics.enemies.Add(new Enemy("Enemigo" + Enemy.nEnemies, healthEnemyG, speedEnemyG, levelEnemyG, bulletsG));
                    Debug.Log(Statistics.enemies[Enemy.nEnemies - 1].playerName);    
                }
                else
                {
                    Debug.Log("No se pueden crear más enemigos");
                }         
        }

       




        //player.Interact();
        //enemy.Interact();


    }
}
