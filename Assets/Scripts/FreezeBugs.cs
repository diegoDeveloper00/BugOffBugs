using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FreezeBugs : MonoBehaviour
{
    [SerializeField]
    private float time;
    private bool isCharged;
    Image image;

    private bool isFreeze;


    private void Start()
    {
        time = 7f;
        isFreeze = false;
        image = GetComponent<Image>();
    }


    private void Update()
    {
        if (!isCharged)
        {
            if (time <= 0 && image.fillAmount == 1)
            {
                
                isCharged = true;
                image.fillAmount = 0;
            }
            else
            {
               
                image.fillAmount += (1 / time * Time.deltaTime);

                time -= Time.deltaTime;

            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A) && !isFreeze)
            {

                StartCoroutine(freezeAllBugs());
                
            }
           
        }
    }

    private IEnumerator freezeAllBugs()
    {
        var bugList = FindObjectsOfType<AbstractBug>();
        if(bugList != null)
        {
            foreach (var el in bugList)
            {
                el.moveSpeed = 0;
            }
        }
        isFreeze = true;


        yield return new WaitForSeconds(3f);

            foreach (var el in bugList)
            {
                el.moveSpeed = 3;
            }
        time = 7f;
        isCharged = false;
        isFreeze = false;
        

    }
}
