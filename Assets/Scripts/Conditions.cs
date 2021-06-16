using UnityEngine;
using UnityEngine.SceneManagement;

public class Conditions: MonoBehaviour
{
    // Story Act
    public static int act = 0;

    // Conditions
    // Main
    public static int[] conditions = new int[14];
    public static string time = "19 00";

    public static int interactions;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
