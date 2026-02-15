using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorImageRotateScript : MonoBehaviour
{

    void Update()
    {
        gameObject.transform.Rotate(new Vector3(0f, 1f, 3f));
    }
}
