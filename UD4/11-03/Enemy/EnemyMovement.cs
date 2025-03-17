using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] int _speed = 1;//velocidad del movimiento
    Transform _player;//Almacenar� la posici�n del player
                      // Start is called before the first frame update




    void Start()
    {
        //Para hacer que el enemigo se dirija hacia el player de forma automatizada
        //necesitamos conocer en todo momento la ubicaci�n del player para
        //definir un vector direccional entre su posici�n y la posici�n del Enemigo
        //Este vector definir� el movimiento del enemigo.
        //Necesitamos conocer la posici�n del enemigo desde el principio, por eso lo
        //incluimos en el m�todo Start
        //_player=FindObjectOfType<Player>().transform;//Localizar un objeto con FindOBjectOfType
        //Utilizamos el operador de propagaci�n de nulabilidad (?.) para evitar posibles errores si el objeto "Player" no se encuentra
        _player = GameObject.Find("Player")?.transform;


    }

    // Update is called once per frame
    void Update()
    {
        //movimiento autom�tico del Enemy hacia el Player.
        MoveToPlayer();
    }

    private void MoveToPlayer()
    {

        //Obtenemos el vector de direcci�n (destino - origen, si no se mover� en direcci�n contraria)
        Vector2 direction = _player.position - transform.position;

        //Aplicamos el vector de direcci�n a la posici�n del Enemy
        //Hay que hacer Casting porque el vector de direcci�n se ha definido como un Vector2 y necesitamos
        //un Vector3
        transform.position += (Vector3)direction.normalized * Time.deltaTime * _speed;
    }

}