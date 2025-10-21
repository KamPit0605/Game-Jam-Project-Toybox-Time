using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public ItemTeleporting itemTeleporting;
    private float TimeSpan = 5f;
    private int speed = 5;
    private bool StartSpan = false;
    public bool CloneSpan = false;

    private bool PlayerInteracted = false;
    public GameObject Meteor;

    // Start is called before the first frame update
    void Start()
    {
        if (CloneSpan == true) //It's true for Cloned objects
        { 
            StartSpan = true;
            Vector3 randomVector = new Vector3(Random.Range
                (itemTeleporting.TarMin.x, itemTeleporting.TarMax.x), 0.65f, 
                Random.Range(itemTeleporting.TarMin.z, itemTeleporting.TarMax.z));
            gameObject.transform.position = randomVector;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerInteracted);
        if (StartSpan)
        {
            Meteor.transform.Translate(Vector3.down * speed * Time.deltaTime);
            TimeSpan -= Time.deltaTime;
        }
        if (TimeSpan <= 0 || PlayerInteracted == true) { Destroy(gameObject);}
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInteracted = true;
        }
    }

}
