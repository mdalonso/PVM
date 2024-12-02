using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Play : MonoBehaviour
{

    Character personaje;

//Fase 2
    //Player player;
    //Enemy enemy;

   

    //Es conveniente evitar los "valores mágicos" asignados literalmente. Por eso definimos campos públicos que
    //pueden ser serializados.
    public string namePersonnaje = "General";
    public int healthPersonaje=10;
    public int speedPersonaje = 5;
    public int levelPersonaje = 0;

   // public string namePlayer = "Hero";
   // public int healthPlayer = 20;
   // public int speedPlayer = 15;
   // public int levelPlayer = 0;
   // public int strength = 5;

    //public string nameEnemy = "Enemy";
    //public int healthEnemy = 10;
    //public int speedEnemy = 2;
    //public int levelEnemy = 0;
    //public int bullets = 100;


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
        personaje = new Character(namePersonnaje, healthPersonaje, speedPersonaje, levelPersonaje);



        //Podemos mostrar por consola directamente el nombre del player porque es un campo público.
        Debug.Log("Nombre del persoaje: "+ personaje.playerName);

        //Debug.Log(player.health);//Esta línea produce un error de compilación porque health es un campo private
        Debug.Log("El personaje comienza con Health: "+ personaje.Health); //Accedemos al campo privado health mediante la propiedad Health (getter)

        Debug.Log("Velocidad inicial del personaje: "+ personaje.speed);

        Debug.Log("Nivel inicial del personaje: " + personaje.Level);
        //personaje.ShowMessage();

        //Inicializamos el player
        //player = new Player(namePlayer, healthPlayer, speedPlayer, levelPlayer, strength);

        //Debug.Log("Name player: " + player.playerName);
        //Debug.Log("Health player: " + player.Health); //Accedemos al campo privado health mediante la propiedad Health (getter)
        //Debug.Log("Speed player: " + player.speed);
        //Debug.Log("Score player: " + player.Level);
        //player.ShowMessage();

        //Inicializamos el enemigo
        //enemy = new Enemy(nameEnemy, healthEnemy, speedEnemy, levelEnemy, bullets);
        //enemy.ShowMessage();

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
        if (Input.GetKey(KeyCode.X))
        {
            personaje.Health++;//Hace uso del setter
            Debug.Log(personaje.Health);
        }
        
        //Incrementaremmos el nivel del personaje en cada Frame (así probamos getter y setter)
        personaje.Level+=100;
        Debug.Log("Nivel actual del personaje: "+ personaje.Level);

        //enemy.TakeDamage(1);
        //enemy.Shoot();

        //Player.AddScore(10);
        //Debug.Log("Puntuación players: "+Player.Score);

        //player.Interact();
        //enemy.Interact();
        
       
    }
}
