using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreElement : MonoBehaviour
{
    public Player player;
    public Text score;

    private void Update()
    {
        score.text = player.Score.ToString();
    }
}
