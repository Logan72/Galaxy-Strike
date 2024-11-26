using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    static TMP_Text scoreTMP;
    static int score = 0;

    void Awake()
    {
        scoreTMP = GetComponent<TMP_Text>();
        scoreTMP.text = score.ToString();
    }

    public static void ModifyScore(int amount)
    {
        score += amount;
        scoreTMP.text = score.ToString();
    }
}
