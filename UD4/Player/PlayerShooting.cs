using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private float fireRate = 5f;
    private bool gunLoaded = true;
    private PlayerAiming playerAiming;

    //Se utiliza Awake para inicializar variables que NO DEPENDEN dde otros objetos.
    //En este caso, como PlayerAiming pertenece al mismo objeto, lo inicializamos
    //en el Awake. 
    //Si la inicialización depende de la existencia de otro objeto se utilizará el método Start()
    private void Awake()
    {
        playerAiming = GetComponent<PlayerAiming>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && gunLoaded)
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        gunLoaded = false;
        float angle = Mathf.Atan2(playerAiming.GetFacingDirection().y, playerAiming.GetFacingDirection().x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Instantiate(bulletPrefab, transform.position, targetRotation);
        StartCoroutine(ReloadGun());
    }

    private IEnumerator ReloadGun()
    {
        yield return new WaitForSeconds(1 / fireRate);
        gunLoaded = true;
    }
}

