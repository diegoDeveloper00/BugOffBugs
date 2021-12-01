using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractBug : MonoBehaviour
{

    public new string name;

    [SerializeField]
    protected Bugs bug;

    public string description;

    public int damage;

    public int moveSpeed;

    private Vector3 screenPoint;
    private Vector3 offset;

    int totalBugs;

    protected GameObject player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.collider.GetComponent<Player>();

        if (player)
        {
            player.takeDamage(damage);
        }
    }

    public virtual void OnMouseDown()
    {
        if (GameManager.instance.isDead)
        {
            this.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
        else
        {
            Destroy(gameObject);
        }  
       

    }

    public virtual void OnDestroy()
    {
        if (FindObjectOfType<LevelManager>().totalBugsPerLevel > 0)
        {
            FindObjectOfType<LevelManager>().totalBugsPerLevel--;
        }

    }

    public virtual void OnMouseDrag()
    {

    }

    protected virtual void Start()
    {
        player = GameObject.Find("Player");
        damage = bug.damage;
        name = bug.name;
    }

    protected virtual void Update()
    {
        if (player != null)
        {
            transform.LookAt(player?.transform);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            transform.position = Vector2.MoveTowards(transform.position, (Vector3)player?.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
