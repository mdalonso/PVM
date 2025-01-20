using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Translate : MonoBehaviour
{

  

    public float speed=5.0f;
    private Vector3 origen;
    private GameObject nuevo;
    // Start is called before the first frame update
    void Start()
    {
      origen=transform.position;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveForward();
            Debug.Log(DistanceCalculator(origen, transform.position));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveBack();
            Debug.Log(DistanceCalculator(origen, transform.position));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft();
            Debug.Log(DistanceCalculator(origen, transform.position));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight();
            Debug.Log(DistanceCalculator(origen, transform.position));
        }

        if (Input.GetKeyDown(KeyCode.N)) {
            nuevo=GameObject.CreatePrimitive(PrimitiveType.Cube);
            nuevo.transform.position=origen;
            nuevo.GetComponent<Renderer>().material.color = Color.red;
        }



    }
   

    void moveForward()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void moveBack()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);

    }

    void moveLeft()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
    void moveRight()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    float DistanceCalculator(Vector3 origen, Vector3 destino)
    {
        return Vector3.Distance(origen, destino);
    }


}
