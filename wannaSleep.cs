using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wannaSleep : MonoBehaviour
{
    
    public Planter plantManager;
    public BluePlanter blueManager;
    public Player_Controller playerController;

    public GameObject button1;
    public GameObject button2;
    public GameObject board;
    public GameObject text;

    public GameObject nightCurtain;
    public GameObject thiSnightCurtain;

    // Start is called before the first frame update

    public void Start()
    {
        plantManager = GameObject.FindGameObjectWithTag("planter").GetComponent<Planter>();
        blueManager = GameObject.FindGameObjectWithTag("planter").GetComponent<BluePlanter>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
    }

    public void No()
    {  
        playerController.awake = true;
        Destroy(gameObject);
    }

    public void Yes()
    {
        Debug.Log("Yas queen");

        plantManager.killCrops();
        blueManager.killCrops();
        plantManager.birthCrops();
        blueManager.birthCrops();
        playerController.health = playerController.initialHealth;
        StartCoroutine(Sleep());
    }
    IEnumerator Sleep()
    {
        thiSnightCurtain = Instantiate(nightCurtain, playerController.transform.position, gameObject.transform.rotation);
        Debug.Log("pls sleep");
        Destroy(board);
        Destroy(button2);
        Destroy(button1);
        Destroy(text);
        yield return new WaitForSeconds(playerController.sleepTime);
        Debug.Log("AWAKE");
        playerController.awake = true;
        Destroy(gameObject);
        Destroy(thiSnightCurtain);
    }
}
