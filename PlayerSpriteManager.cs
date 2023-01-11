using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteManager : MonoBehaviour
{

    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;

    public SpriteRenderer rendering;
    public SpriteRenderer reference;

    public GameObject player;
    public Player_Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = player.GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        rendering.color = reference.color;
    }

    private void FixedUpdate()
    {
        if (controller.awake)
        {
            if (Input.GetKey(KeyCode.W))
            {
                rendering.sprite = back;
            }
            if (Input.GetKey(KeyCode.A))
            {
                rendering.sprite = left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rendering.sprite = front;
            }
            if (Input.GetKey(KeyCode.D))
            {
                rendering.sprite = right;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    rendering.sprite = left;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    rendering.sprite = front;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    rendering.sprite = right;
                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    rendering.sprite = front;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    rendering.sprite = right;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rendering.sprite = back;
                }
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    rendering.sprite = right;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rendering.sprite = back;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    rendering.sprite = left;
                }
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    rendering.sprite = back;
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    rendering.sprite = left;
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    rendering.sprite = front;
                }
            }
        }

        gameObject.transform.position = player.transform.position;
        
    }
}
