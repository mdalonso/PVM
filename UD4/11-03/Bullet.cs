using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int _speed = 5;
    [SerializeField] int _delay = 2;

    [SerializeField] int _health = 3;
    [SerializeField] bool powerShot = false;

    public int Health { get => _health; set => _health = value; }
    public bool PowerShot { get => powerShot; set => powerShot = value; }


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _delay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * _speed*Time.deltaTime;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        collision.GetComponent<Enemy>()?.TakeDamage();
    //        Destroy(gameObject);
    //    }
    //}
}
