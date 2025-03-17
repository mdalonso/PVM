using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] Transform bulletPrefab;

    bool gunLoaded = true;//Indica si el arma está cargada

    [SerializeField] int fireRate = 5; //Nº de proyectiles por segundo
    [SerializeField] bool _powerShotEnabled = false;


    PlayerAiming playerAiming;

    public int FireRate { get => fireRate; set => fireRate = value; }
    public bool PowerShotEnabled { get => _powerShotEnabled; set => _powerShotEnabled = value; }



    // Start is called before the first frame update

    private void Awake()
    {
        playerAiming = GetComponent<PlayerAiming>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gunLoaded)
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        gunLoaded = false;
        //float angle=Mathf.Atan2(seno,coseno)

        float angle = Mathf.Atan2(playerAiming.GetFacingDirection().y, playerAiming.GetFacingDirection().x) * Mathf.Rad2Deg;
        Vector3 eje = new Vector3(0, 0, 1);
        Quaternion targetRotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));

        Transform bulletClone=Instantiate(bulletPrefab, transform.position, targetRotation);
        if (_powerShotEnabled)
        {
            bulletClone.GetComponent<Bullet>().PowerShot = true;
            _powerShotEnabled=false;
        }

        StartCoroutine(ReloadGun());
    }

    IEnumerator ReloadGun()
    {
        
        yield return new WaitForSeconds(1 / (float)fireRate);
        gunLoaded = true;
    }
}
