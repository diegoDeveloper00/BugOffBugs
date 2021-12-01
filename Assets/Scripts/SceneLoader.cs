using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{

    public LevelManager levelManager;

    public GameObject levelCompletePanel;

    private TextMeshProUGUI levelCompleteText;
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
        levelManager.levelComplete += onLevelComplete;
    }

    private void OnDisable()
    {
        levelManager.levelComplete -= onLevelComplete;
    }

   public void onLevelComplete()
    {
        StartCoroutine(showLevelCompletePanel());
        
    }

    public void tryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator showLevelCompletePanel()
    {
        levelCompletePanel.SetActive(true);
        levelCompleteText = levelCompletePanel.GetComponentInChildren<TextMeshProUGUI>();
        levelCompleteText.text = "Level " + (SceneManager.GetActiveScene().buildIndex+1) + " Complete";
        yield return new WaitForSeconds(2F);
        levelCompletePanel.SetActive(false);
        GameManager.instance.level += 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void CreditScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public void HowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
