using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFieldScript : MonoBehaviour
{
    private bool setItem = false;
    public float TimeSpan = 15f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) {setItem = true; }
        
        if (setItem == true)
        {
            gameObject.SetActive(true);
            TimeSpan -= Time.deltaTime;
        }
        else { gameObject.SetActive(false); }
        if (TimeSpan <= 0f)
        {
            setItem = false;
            gameObject.SetActive(false);
            TimeSpan = 0f;
        }

        
    }
}
