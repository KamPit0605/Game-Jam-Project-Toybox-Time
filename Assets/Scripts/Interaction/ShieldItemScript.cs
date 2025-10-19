using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItemScript : MonoBehaviour
{
    public ItemTeleporting ItemTeleporting;
    //private bool setItem = false;
    public float TimeSpan = 10f;
    private bool StartSpan = false;
    public bool CloneSpan = false;

    private int TeleportPosition;

    // Start is called before the first frame update
    void Start()
    {
        if (CloneSpan == true) //It should never be "true" for the parent (or the already existing) tar so it could execute properly for its clones only.
        {
            StartSpan = true;
            Teleporting();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StartSpan == true) { TimeSpan -= Time.deltaTime; }
        if (TimeSpan <= 0) { Destroy(gameObject); }
    }

    void Teleporting()
    {
        TeleportPosition = Random.Range(0, 2);
        if (TeleportPosition == 0) { gameObject.transform.position = new Vector3(ItemTeleporting.TPP06.x, 1, ItemTeleporting.TPP06.z); }
        else if (TeleportPosition == 1) { gameObject.transform.position = new Vector3(ItemTeleporting.TPP07.x, 1, ItemTeleporting.TPP07.z); }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
