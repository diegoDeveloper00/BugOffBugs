using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        player.kill += onPlayerKilled;
    }

    private void OnDisable()
    {
        player.kill -= onPlayerKilled;
    }


    public void onPlayerKilled()
    {
        Destroy(player.gameObject);
        GameManager.instance.isDead = true;
    }

}
