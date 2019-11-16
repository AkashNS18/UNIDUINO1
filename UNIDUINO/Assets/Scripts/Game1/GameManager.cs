using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool GameHasEnded = false;

    public float restartdelay = 2f;

    public GameObject completeLevelUI;

    public void EndGame()
    {
        if(GameHasEnded==false)
        {
            GameHasEnded = true;
            Debug.Log("Game Over!");
            Invoke("Restart", restartdelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
	
    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
    }

}
