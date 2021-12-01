using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private int totalHorde;

    public int totalBugsPerLevel;

    public event Action levelComplete;

    public TextMeshProUGUI levelNumberText;

    public int getHorde
    {
        get
        {
            return this.totalHorde;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        levelNumberText.text = GameManager.instance.level.ToString();

        foreach (var item in FindObjectOfType<BugsSpawner>().totalBugsPerHorde)
        {
            totalBugsPerLevel += item;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if (totalBugsPerLevel <= 0)
        {
            onLevelComplete();
        }
    }

    public void onLevelComplete()
    {
        levelComplete.Invoke();
    }
}
