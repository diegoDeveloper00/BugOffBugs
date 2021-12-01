using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHordesCountUpdater : MonoBehaviour
{

    TextMeshProUGUI counter;


    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<TextMeshProUGUI>();
        counter.text = FindObjectOfType<LevelManager>().getHorde.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = FindObjectOfType<BugsSpawner>().getTotalHordes .ToString();   
    }

}
