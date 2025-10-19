using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class Gem : MonoBehaviour
{
    public ItemTeleporting ItemTeleporting;
    public UnityEvent gemCollect;
    public GameObject GemObject;

    private int TeleportPosition;

    private void Start()
    {
        gemCollect.AddListener(GameObject.FindGameObjectWithTag("UI").GetComponent<PublicScripts>().Scoring);
        //^ calls the scoring function to execute the score system
        Teleporting();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gemCollect.Invoke();
            Instantiate(GemObject);
            Destroy(gameObject);
        }
    }

 

   /*
    public void TestMethod()
    {
        print("it works");
    }
   */

    void Teleporting()
    {
        TeleportPosition = Random.Range(0, 4);
        
        if (TeleportPosition == 0) {GemObject.transform.position = new Vector3(ItemTeleporting.TPP01.x, ItemTeleporting.TPP01.y, ItemTeleporting.TPP01.z);}
        else if (TeleportPosition == 1) {GemObject.transform.position = new Vector3(ItemTeleporting.TPP02.x, ItemTeleporting.TPP02.y, ItemTeleporting.TPP02.z);}
        else if (TeleportPosition == 2) {GemObject.transform.position = new Vector3(ItemTeleporting.TPP03.x, ItemTeleporting.TPP03.y, ItemTeleporting.TPP03.z);}
        else if (TeleportPosition == 3) {GemObject.transform.position = new Vector3(ItemTeleporting.TPP04.x, ItemTeleporting.TPP04.y, ItemTeleporting.TPP04.z);}
        else if (TeleportPosition == 4) {GemObject.transform.position = new Vector3(ItemTeleporting.TPP05.x, ItemTeleporting.TPP05.y, ItemTeleporting.TPP05.z);}
    }
}
