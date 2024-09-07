using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    //the player will duck while holding S
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Ducking");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.transform.localScale *= 0.5f;
        player.mCurrentState = this;
    }

    //player will return to normal after release
    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.S))
        {
            rbPlayer.transform.localScale *= 2.0f;
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}