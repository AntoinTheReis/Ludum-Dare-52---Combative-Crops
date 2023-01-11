using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{

    public Transform attackPoint;
    public GameObject scythePrefab;
    public GameObject boostedScythePrefab;
    public Player_Controller controller;

    public bool boosted;

    // Start is called before the first frame update
    void Start()
    {
        boosted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.onField && Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (!boosted)
        {
            GameObject scythe = Instantiate(scythePrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = scythe.GetComponent<Rigidbody2D>();
        }
        if (boosted)
        {
            GameObject scythe = Instantiate(boostedScythePrefab, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = scythe.GetComponent<Rigidbody2D>();
        }
    }
}
