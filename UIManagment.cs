using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagment : MonoBehaviour
{

    public Player_Controller playerController;
    public Text slimeBits;
    public Text coins;
    public Text health;
    public GameObject ui;
    public GameObject blueSlimeUI;
    public Text blueSlime;
    public bool done;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        slimeBits = GameObject.FindGameObjectWithTag("bits").GetComponent<Text>();
        coins = GameObject.FindGameObjectWithTag("coin").GetComponent<Text>();
        health = GameObject.FindGameObjectWithTag("health").GetComponent <Text>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!done && playerController.hasBlue)
        {
            done = true;
            Instantiate(blueSlimeUI, ui.transform);
        }
        if (playerController.hasBlue)
        {
            blueSlime = GameObject.FindGameObjectWithTag("blueBits").GetComponent<Text>();
            blueSlime.text = playerController.blueSeeds.ToString();
        }

        slimeBits.text = playerController.seeds.ToString();
        coins.text = playerController.coins.ToString();
        health.text = playerController.health.ToString() + " / " + playerController.initialHealth.ToString();
    }
}
