using UnityEngine;

public class Endpoint : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();  
    }
}
