using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Image bar;
    public float maxHealth;
    public float curHealth;
    public Player_Controller playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Controller>();
        bar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        curHealth = playerController.health;
        maxHealth = playerController.initialHealth;
        bar.fillAmount = curHealth / maxHealth;
    }
}
