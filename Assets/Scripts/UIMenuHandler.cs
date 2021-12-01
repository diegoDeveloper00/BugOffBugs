using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMenuHandler : MonoBehaviour
{

    public Player player;

    public GameObject gameOverPanel;

    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        player.kill += GameOverOnPlayerKilled;
    }

    private void OnDisable()
    {
        player.kill += GameOverOnPlayerKilled;
    }


    public void GameOverOnPlayerKilled()
    { 
        gameOverPanel.SetActive(true);

    }

}
