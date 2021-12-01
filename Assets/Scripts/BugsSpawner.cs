using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsSpawner : MonoBehaviour
{

    public List<GameObject> bugList = new List<GameObject>();
    public List<GameObject> spawnerList = new List<GameObject>();
    public GameObject bug;

    public List<int> totalBugsPerHorde;

    int j;

    [SerializeField]
    private int totalHordes;

    public int getTotalHordes
    {
        get
        {
            return this.totalHordes;
        }
    }

    float time = 2f;

    private void Awake()
    {
        totalHordes = FindObjectOfType<LevelManager>().getHorde;
        totalBugsPerHorde = GetNumberOfBugsPerHorde();
    }

    private void Start()
    {
        
        InvokeRepeating("spawnObject",2.0f,3.0f);
    }

    public void Update()
    {
        if (time < 0f)
        {
            //spawnObject();
            time = 2f;
        }
        else
        {
            time -= Time.deltaTime;
        }

        
    }

    private void spawnObject()
    {

        if (totalHordes > 0) {
            
            StartCoroutine(spawnObjectInHorde());
            totalHordes--;
        }
        
        //GameObject g = Instantiate(bug, spawner.transform.position, Quaternion.identity);
    }

    private List<GameObject> GetBugsPerHorde(List<GameObject> bugList)
    {
        List<GameObject> bugsPerHorde = new List<GameObject>();
        
        if (j  <= totalBugsPerHorde.Count)
        {
            var index = totalBugsPerHorde[j];
            Debug.Log("totalBugsPerHorde.Count: "+totalBugsPerHorde.Count);
            Debug.Log("index: " + index);
            j++;
            Debug.Log("j: " + j);

            for (int i = 0; i < index ; i++)
            {
                var bugListIndex = UnityEngine.Random.Range(0, bugList.Count);
                bugsPerHorde.Add(bugList[bugListIndex].gameObject);
            }
        }
        foreach (var item in bugsPerHorde)
        {
            Debug.Log("bugs per Horde:" + item);
        }
        return bugsPerHorde;
        
    }

    private List<int> GetNumberOfBugsPerHorde()
    {
        List<int> bugsPerHorde = new List<int>();
        Debug.Log("Bu list count: " + bugList.Count);
        System.Random r = new System.Random();
        for (int i = 0; i < totalHordes; i++)
        {
            int index = UnityEngine.Random.Range(0,5);
            Debug.Log("index: " + index);
            bugsPerHorde.Add(index);
        }
        return bugsPerHorde;

    }


    private GameObject chooseSpawner(List<GameObject> spawnerList)
    {
        UnityEngine.Random.InitState(new System.Random().Next(15)*10);
        int random = UnityEngine.Random.Range(0, spawnerList.Count);
        Debug.Log("Spawnr Found: " + spawnerList.Find(g => spawnerList[random].Equals(g)));
        return spawnerList.Find(g => spawnerList[random].Equals(g));
    }

    IEnumerator spawnObjectInHorde()
    {
        List<GameObject> bugsToSpawn = GetBugsPerHorde(bugList);
        float time=2f;
        Debug.Log(bugsToSpawn.Count);
        System.Random r = new System.Random();
        foreach (var bug in bugsToSpawn)
        {
            GameObject spawner = chooseSpawner(spawnerList);
            yield return new WaitForSeconds(1f);
            Instantiate(bug, spawner.transform.position, Quaternion.identity);
        }
        
    }

    

}
