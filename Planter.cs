using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planter : MonoBehaviour
{
    public Player_Controller player;
    public bool onField;
    public GameObject cropPrefab;
    public GameObject slimePrefab;
    public Vector3 plantingSpot;

   
    public List<Vector3> cropLocations = new List<Vector3>();
    public List<GameObject> crops = new List<GameObject>();
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

        if (Input.GetKeyDown(KeyCode.P)&& player.seeds > 0 && onField)
        {
            crops.Add(Instantiate(cropPrefab, plantingSpot, gameObject.transform.rotation));
            player.seeds --;

            cropLocations.Add(plantingSpot);
            cropCounter++;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("pushin p hahahahahahhahahah");
        }
    }

    public void killCrops()
    {
        if (cropCounter > 0){
            for (int i = 0; i < crops.Count; i++)
            {
                Destroy(crops[i]);
            }
            crops.Clear();
        }
    }

    public void birthCrops()
    {
        if (cropCounter > 0)
        {
            for (int i = 0; i < cropCounter; i++)
            {
                Instantiate(slimePrefab, cropLocations[i], slimePrefab.transform.rotation);
            }
            cropLocations.Clear();
            cropCounter = 0;
        }
    }

}


