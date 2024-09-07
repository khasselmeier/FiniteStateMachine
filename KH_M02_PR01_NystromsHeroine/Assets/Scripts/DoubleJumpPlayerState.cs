using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;
    float launchTime;

    //the player will double jump after pressing space while in jump
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Double Jump");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.velocity = new Vector3(0, 5, 0);
        launchTime = Time.time;
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Debug.Log("Executing State: Double Jump");

        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f) && (Time.time - launchTime > 0.5f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            DivingPlayerState divingState = new DivingPlayerState();
            divingState.Enter(player);
        }
    }
}