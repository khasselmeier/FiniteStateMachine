using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;
    float launchTime;

    //the player will jump after pressing space
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Jumping");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.velocity = new Vector3(0, 5, 0);
        launchTime = Time.time;
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        Debug.Log("Executing State: Jumping");

        if (Physics.Raycast(rbPlayer.transform.position, Vector3.down, 0.55f) && (Time.time - launchTime > 0.5f))
        {
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DoubleJumpPlayerState doublejumpState = new DoubleJumpPlayerState();
            doublejumpState.Enter(player);
        }
    }
}