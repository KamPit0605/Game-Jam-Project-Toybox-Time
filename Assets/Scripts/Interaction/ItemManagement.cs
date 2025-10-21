using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagement : MonoBehaviour
{
    public PublicScripts UiScript;
    private int SpawnItem = 0;
    private int SpawnPowerUp = 0;
    private int SpawnMultiple = 0;
    
    public GameObject SlowField;
    public SlowFieldScript SlowFieldScript;
    public GameObject Tar;
    public TarScript TarScript;
    public GameObject Meteor;
    public MeteorScript MeteorScript;



    public GameObject SpeedPowerUp;
    public SpeedItemScript SpeedItemScript;

    public GameObject ShieldPowerUp;
    public ShieldItemScript ShieldItemScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemSpawnManagement();
        itemSpawnMultiple();
        
        if (UiScript.itemSpawned == true)
        {
            SpawnItem = Random.Range(1,4);
            SpawnPowerUp = Random.Range(0,3);
            if (UiScript.itemSpawned == true) 
            { 
                UiScript.itemSpawnTimer = 0f;
                UiScript.itemSpawned = false;
            }
            //if (SpawnItem >= 1) {SpawnItem = 0;}

            //UiScript.itemSpawned = false;
        }
        //Debugging();
    }

    void itemSpawnManagement()
    {
        if (SpawnItem == 1)
        {
            SlowField.SetActive(true);
            SlowFieldScript.TimeSpan = 15f;
            SpawnItem = 0;

        }
        if (SpawnItem == 2)
        {
            TarScript.CloneSpan = true;
            Instantiate(Tar);
            SpawnItem = 0;
            //Tar.SetActive(true);
        }

        if (SpawnItem == 3)
        {
            SpawnMultiple = Random.Range(1,6);
            MeteorScript.CloneSpan = true;
            //Head to itemSpawnMultiple function;
        }

        if (SpawnPowerUp == 1)
        {
            SpeedItemScript.CloneSpan = true;
            Instantiate(SpeedPowerUp);
            SpawnPowerUp = 0;
        }
        if (SpawnPowerUp == 2)
        {
            ShieldItemScript.CloneSpan = true;
            Instantiate(ShieldPowerUp);
            SpawnPowerUp = 0;
        }

        
    }

    void itemSpawnMultiple()
    {
        if (SpawnMultiple > 0)
        {
            SpawnMultiple--;
            if (SpawnItem == 3) { Instantiate(Meteor);}

         
        }
   
        if (SpawnMultiple <= 0)
        {
            SpawnItem = 0;
            SpawnMultiple = 0;
        }
           
    }

    void Debugging()
    {
        Debug.Log("Spawned Item " + SpawnItem);
        Debug.Log("Spawned Multiple " + SpawnMultiple);
    }
}
