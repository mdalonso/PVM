using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSObj : MonoBehaviour
{

    [SerializeField] GameStats gameStats;
   
    // Start is called before the first frame update
    void Start()
    {
        gameStats.ResetState();

        StartCoroutine(CountDownRoutine());

        UIManager.Instance.UpdateUITime(gameStats.Time);
    }

    // Update is called once per frame
   
    IEnumerator CountDownRoutine()
    {
        while (gameStats.Time > 0)
        {
            yield return new WaitForSeconds(1);
            gameStats.Time--;
        }

        Debug.Log("Game over");

        UIManager.Instance.ShowGameOverScreen();
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
