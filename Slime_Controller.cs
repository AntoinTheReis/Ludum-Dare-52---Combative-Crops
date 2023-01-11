using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Controller : MonoBehaviour
{
    public Vector3 player;
    public Player_Controller killer;
    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 movement;

    public float initialHealth = 3;
    public float health;

    public bool awake = false;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
        awake = false;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform.position;
        killer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();

        if (killer.onField)
        {
            awake = true;
            Debug.Log("awake");
        }

        if (awake)
        {
            Vector3 direction = player - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb2d.rotation = angle;
            direction.Normalize();
            movement = direction;

            if (health <= 0)
            {
                if (gameObject.tag == "slime")
                {
                    killer.seeds += 2;
                }
                else
                {
                    killer.blueSeeds += 2;
                }
                Destroy(gameObject);
            }
        }

    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
        
    }

    void moveCharacter(Vector2 direction)
    {
        rb2d.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "scythe")
        {
            health--;

            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
       if (collision.tag == "scythe2")
        {
            health -= 2;

            Vector2 difference = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
}
