using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicStatic : MonoBehaviour
{
    #region GAMEMODE
    public static byte CurrentGameMode;
    // 1 = Original Time mode; 2 = Co-op Time mode;
    // 3 = Versus Time mode; 4 = Versus Score Mode
    #endregion

    #region RESULTS
    public static int ResultsRecordScore;
    public static int ResultsScore;
    public static float ResultsStopwatch;
    #endregion
}
