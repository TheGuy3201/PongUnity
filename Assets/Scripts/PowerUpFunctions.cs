using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpFunctions : MonoBehaviour
{
    // Variable Declaration
    float turboSpeed = 2;
    int turboTime = 5000;
    int freezeTime = 2000;
    public bool isTurbo;
    public int recentHit = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            recentHit = other.GetComponent<BallSpawner>().lastHit;
            CheckPowerType();
            Destroy(this.gameObject);
            GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeping>().powerCount--;
        }
    }
    
    void CheckPowerType()
    {
        if (isTurbo)
            Turbo();
        else
            Freeze();
    }

    private async void Turbo()
    {
        if (recentHit == 2)
        {
            GameObject.Find("Player1").GetComponent<Player1Controller>().playerSpeed *= turboSpeed;
            await Task.Delay(turboTime);
            GameObject.Find("Player1").GetComponent<Player1Controller>().playerSpeed /= turboSpeed;
        }
        else if (recentHit == 1)
        {
            GameObject.Find("Player2").GetComponent<Player2Controller>().playerSpeed *= turboSpeed;
            await Task.Delay(turboTime);
            GameObject.Find("Player2").GetComponent<Player2Controller>().playerSpeed /= turboSpeed;
        }
    }

    private async void Freeze()
    {
        if (recentHit == 2)
        {
            float oldPlayerSpeed = GameObject.Find("Player1").GetComponent<Player1Controller>().playerSpeed;
            GameObject.Find("Player1").GetComponent<Player1Controller>().playerSpeed = 0;
            await Task.Delay(freezeTime);
            GameObject.Find("Player1").GetComponent<Player1Controller>().playerSpeed = oldPlayerSpeed;
        }
        else if (recentHit == 1)
        {
            float oldPlayerSpeed = GameObject.Find("Player2").GetComponent<Player2Controller>().playerSpeed;
            GameObject.Find("Player2").GetComponent<Player2Controller>().playerSpeed = 0;
            await Task.Delay(freezeTime);
            GameObject.Find("Player2").GetComponent<Player2Controller>().playerSpeed = oldPlayerSpeed;
        }
    }
}
