using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlanter : MonoBehaviour
{
    public Player_Controller player;
    public bool onField;
    public GameObject bluecropPrefab;
    public GameObject blueslimePrefab;
    public Vector3 plantingSpot;


    public List<Vector3> bluecropLocations = new List<Vector3>();
    public List<GameObject> bluecrops = new List<GameObject>();
    public int cropCounter;

    // Start is called before the first frame update
    void Start()
    {
        cropCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        plantingSpot = player.transform.position;

        onField = player.onField;

        if (Input.GetKeyDown(KeyCode.O) && player.blueSeeds > 0 && onField)
        {
            bluecrops.Add(Instantiate(bluecropPrefab, plantingSpot, gameObject.transform.rotation));
            player.blueSeeds--;

            bluecropLocations.Add(plantingSpot);
            cropCounter++;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("pushin O hahahahahahhahahah");
        }
    }

    public void killCrops()
    {
        if (cropCounter > 0)
        {
            for (int i = 0; i < bluecrops.Count; i++)
            {
                Destroy(bluecrops[i]);
            }
            bluecrops.Clear();
        }
    }

    public void birthCrops()
    {
        if (cropCounter > 0)
        {
            for (int i = 0; i < cropCounter; i++)
            {
                Instantiate(blueslimePrefab, bluecropLocations[i], blueslimePrefab.transform.rotation);
            }
            bluecropLocations.Clear();
            cropCounter = 0;
        }
    }

}
