using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ScoreKeeping : MonoBehaviour
{
    public GameObject freezePower;
    public GameObject turboPower;

    public GameObject ball;

    public GameObject player1Goal;
    public GameObject player2Goal;

    public GameObject Player1Text;
    public GameObject Player2Text;
    public GameObject VictoryMessage;

    private int player1SCR;
    private int player2SCR;
    int winScore = 3;
    public int powerCount;
    public int powerLimit;

    float time = 0.0f;

    void Update()
    {
        int randTime = Random.Range(10, 20);
        if (time > randTime)
        {
            PowerSpawner();
            time = 0;
        }
        time += Time.deltaTime;
    }

    public void Player1Scored()
    {
        player1SCR++;
        Player1Text.GetComponent<TextMeshProUGUI>().text = player1SCR.ToString();
        if (player1SCR >= winScore)
            Win(true);
        else
            ResetPos();
    }

    public void Player2Scored()
    {
        player2SCR++;
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2SCR.ToString();
        if (player2SCR >= winScore)
            Win(false);
        else
            ResetPos();
    }

    private void Win(bool isPlayer1)
    {
        if (isPlayer1)
            VictoryMessage.GetComponent<TextMeshProUGUI>().text = "Player 1 Wins!";
        else
            VictoryMessage.GetComponent<TextMeshProUGUI>().text = "Player 2 Wins!";
        ResetAll();
    }

    //Resets the ball position
    private void ResetPos()
    {
        ball.GetComponent<BallSpawner>().Reset();
    }

    //spawns Power Ups
    private async void PowerSpawner()
    {
        await Task.Delay(10000);
        if (powerCount < powerLimit)
        {
            int powerChance = Random.Range(0, 3);
            int x = Random.Range(-10, 10);
            int y = Random.Range(-6, 6);

            if (powerChance == 1)
            {
                Instantiate(freezePower, new Vector3(x, y), freezePower.transform.rotation);
                powerCount++;
            }
            else if (powerChance == 2)
            {
                Instantiate(turboPower, new Vector3(x, y), turboPower.transform.rotation);
                powerCount++;
            }
        }
    }

    //Resets the game scores, ball, and spawns a new power up
    private async void ResetAll()
    {
        await Task.Delay(5000);
        player1SCR = 0;
        player2SCR = 0;

        ResetPos();

        Player1Text.GetComponent<TextMeshProUGUI>().text = player1SCR.ToString();
        Player2Text.GetComponent<TextMeshProUGUI>().text = player2SCR.ToString();
        VictoryMessage.GetComponent<TextMeshProUGUI>().text = " ";
    }
}
