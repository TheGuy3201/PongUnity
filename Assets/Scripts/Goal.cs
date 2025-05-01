using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;

    private void OnTriggerEnter2D(Collider2D collided)
    {
        if (collided.gameObject.CompareTag("Ball"))
        {
            if (isPlayer1Goal)
                GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeping>().Player2Scored();
            else
                GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeping>().Player1Scored();
        }
    }
}
