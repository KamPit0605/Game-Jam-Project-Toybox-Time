using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeScript : MonoBehaviour
{
    [SerializeField] private byte GameMode;

    private void Start()
    {
        PublicStatic.CurrentGameMode = GameMode;
    }
}
