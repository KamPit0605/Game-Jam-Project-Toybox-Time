using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFieldScript : MonoBehaviour
{
    private bool setItem = false;
    public float TimeSpan = 15f;
    public GameObject SlowField;
    public GameObject SafeField;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        SafeField.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf) {setItem = true; }
        
        if (setItem == true)
        {
            gameObject.SetActive(true);
            SlowField.SetActive(true);
            TimeSpan -= Time.deltaTime;
        }
        else { gameObject.SetActive(false); }
        if (TimeSpan <= 0.2f)
        {
            SafeField.SetActive(true);
            SlowField.SetActive(false);
        }
        if (TimeSpan <= 0f)
        {
            setItem = false;
            SafeField.SetActive(false);
            gameObject.SetActive(false);
            TimeSpan = 0f;
        }

        
    }
}
