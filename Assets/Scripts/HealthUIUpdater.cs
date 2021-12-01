using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIUpdater : MonoBehaviour
{
    public Player player;

    Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = player.maxHealth;
        slider.value = player.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        player.damaged += onTakeDamage;
    
    }

    private void OnDisable()
    {
        player.damaged -= onTakeDamage;
    }

    private void onTakeDamage(int damage)
    {
        slider.value = player.currentHealth;
    }


}
