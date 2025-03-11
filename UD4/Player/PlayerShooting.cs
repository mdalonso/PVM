using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private float _fireRate = 5f;
    private bool gunLoaded = true;
    private PlayerAiming playerAiming;


    //_powerShotEnabled determinará si el proyectil instanciado es un powerShot o no .Inicialmente se instanciarán proyectiles normales.
    //Esta variable se establece a true cuando el Player colisiona con un PowerUp de tipo PowerShot.
    private bool _powerShotEnabled = false;

    [SerializeField] GameStats _gameStats;
    //PROPIEDADES DE ACCESO A CAMPOS PRIVADOS
    public float FireRate { get { return _fireRate; } set { _fireRate = value; } }
    public bool PowerShotEnabled {  get { return _powerShotEnabled; } set { _powerShotEnabled = value; } }
    private void Awake()
    {
        playerAiming = GetComponent<PlayerAiming>();
    }

    private void Update()
    {
        //Pulsación del botón izquierdo del ratón y arma cargada
        if (Input.GetMouseButtonDown(0) && gunLoaded)
        {
            ShootBullet();
        }
        if (_gameStats.GameOver) StopAllCoroutines();
    }

    private void ShootBullet()
    {
        //Cuando disparamos, imposibilitamos un nuevo disparo hasta que el arma vuelva a recargarse
        //para que el player pueda emitir disparos según la cadencia de tiro configurada.
        gunLoaded = false;

        // Cálculo del ángulo entre el eje x (movimiento del proyectil hacia la derecha) y el vector que marca la dirección
        //hacia donde se apunta la mira. Obtenemos el ángulo en radianes y lo pasamos a grados.
        float angle = Mathf.Atan2(playerAiming.GetFacingDirection().y, playerAiming.GetFacingDirection().x) * Mathf.Rad2Deg;
        //conversión del álgulo obtenido en Quateriones.
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);


        //Debemos mantener la referencia al proyectil instanciado para poder gestionar si es o no un PowerShot.
        Transform bulletClone=Instantiate(bulletPrefab, transform.position, targetRotation);
        //Si tenemos poweShotEnabled el proyectil es un "superproyectil"
        //Esto va a cambiar el comportamiento del proyectil cuando coliisione con un enemigo.
        if (_powerShotEnabled)
        {
            //Si se trata de un "superproyectil" debemos indicarlo en el proyectil
            //el efecto de este superproyectil se gestiona en la colisión con el enemy.
            bulletClone.GetComponent<Bullet>().PowerShot = true;
        }

        //Recargamos el arma para que pueda volver a ser disparada.
        StartCoroutine(ReloadGun());
    }

    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / _fireRate);
        gunLoaded = true;
    }
}

