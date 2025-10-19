using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PlayerClass : ScriptableObject
{
    public float playerSpeed = 5f;
    public float playerJumpHeight = 4f;
    public float jumpHeldMax = 2f;
    public float gravity = -4f;
    //To change the values, go onto its Inspector and change them
}
