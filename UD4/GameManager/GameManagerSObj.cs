using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSObj : MonoBehaviour
{

    [SerializeField] GameStats gameStats;
   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountDownRoutine());
        gameStats.ResetState();
    }

    // Update is called once per frame
   
    IEnumerator CountDownRoutine()
    {
        while (gameStats.time > 0)
        {
            yield return new WaitForSeconds(1);
            gameStats.time--;
        }
        Debug.Log("Game over");
    }

}
