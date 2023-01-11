using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buyer : MonoBehaviour
{
    public Player_Controller controller;
    public Attacking attacker;
    public GameObject buyer2;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        attacker = GameObject.FindGameObjectWithTag("Player").GetComponent<Attacking>();
    }

    public void GreenBits()
    {
        if (controller.coins >= 5)
        {
            controller.coins -= 5;
            controller.seeds++;
        }
    }

    public void ScytheBoost()
    {
        if (controller.coins >= 75)
        {
            controller.coins -= 75;
            attacker.boosted = true;
            Debug.Log("boosted");
            Instantiate(buyer2);
            Destroy(gameObject);
        }
    }

    public void Quit()
    {
        controller.awake = true;
        Destroy(gameObject);
    }

    public void Heart()
    {
        if (controller.coins >= 40)
        {
            controller.initialHealth++;
            controller.coins -= 40;
        }
    }

    public void blueBits()
    {
        if (controller.coins >= 35)
        {
            controller.coins -= 35;
            controller.blueSeeds += 1;
            controller.hasBlue = true;
        }
    }

}
