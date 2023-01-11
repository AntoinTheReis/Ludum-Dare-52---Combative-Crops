using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{

    public float moveSpeed;
    public Rigidbody2D rb2d;
    private Vector2 moveInput;
    private Vector2 mousePos;
    public Camera cam;
    SpriteRenderer sprite;
    public GameObject playerSprite;
    public GameObject wannaSleep;
    public GameObject seller;
    public GameObject buyer;
    public GameObject buyer2;
    public float waitTime = 3f;
    public Attacking attacking;

    public float initialHealth = 5;
    public float health;

    public float seeds = 2;
    public float blueSeeds = 0;
    public bool onField = false;
    public bool invincible = false;
    public bool hasBlue;

    public bool awake;
    public float sleepTime = 2;

    public float coins;

    // Start is called before the first frame update
    void Start()
    {
        sprite = playerSprite.GetComponent<SpriteRenderer>();
        health = initialHealth;
        coins = 0;
        awake = true;
        attacking = GetComponent<Attacking>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if(health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
    }

    private void FixedUpdate()
    {
        if (!awake)
        {
            rb2d.velocity = moveInput * 0;
        }
        if (awake)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");

            moveInput.Normalize();
            rb2d.velocity = moveInput * moveSpeed;
        }

        Vector2 lookDirection = mousePos - rb2d.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        rb2d.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!invincible)
        {
            if (collision.tag == "slime")
            {
                health--;
                Debug.Log("Damage done!");
                sprite.color -= new Color(0, 0, 0, 0.5f);
                StartCoroutine(IFrames());
                invincible = true;

                // Vector2 difference = transform.position - collision.transform.position;
                // transform.position = new Vector2 (transform.position.x + difference.x, transform.position.y + difference.y);
            }
            if (collision.tag == "blueSlime")
            {
                health -= 2;
                Debug.Log("Damage done!");
                sprite.color -= new Color(0, 0, 0, 0.5f);
                StartCoroutine(IFrames());
                invincible = true;
            }
        }

        if (collision.tag == "garden")
        {
            onField = true;
            Debug.Log("onfield");
        }

        if(collision.tag == "bed")
        {
            rb2d.velocity = moveInput * moveSpeed;
            awake = false;
            
                Instantiate(wannaSleep);
                Debug.Log("nappy");
            
        }

        if (collision.tag == "buy")
        {
            if (!attacking.boosted)
            {
                Instantiate(buyer);
            }
            else
            {
                Instantiate(buyer2);
            }
            awake = false;
        }

        if (collision.tag == "sell")
        { 
            
                Instantiate(seller);
            
            awake = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "garden")
        {
            onField = false;
            Debug.Log("off field");
        }
    }

    IEnumerator IFrames()   
    {
        yield return new WaitForSeconds(waitTime);
        invincible = false;
        sprite.color += new Color(0, 0, 0, 0.5f);
    }
}
