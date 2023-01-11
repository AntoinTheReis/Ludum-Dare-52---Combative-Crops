using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{

    public Player_Controller controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }

    public void Quit()
    {
        controller.awake = true;
        Destroy(gameObject);
    }

    public void GreenBits()
    {
        if(controller.seeds >= 1)
        {
            controller.seeds--;
            controller.coins += 3;
        }
    }

    public void BlueBits()
    {
        if (controller.blueSeeds >= 1)
        {
            controller.blueSeeds--;
            controller.coins += 5;
        }
    }

}
