using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeefyPlayerState : IPlayerState
{
    Player mPlayer;
    Rigidbody rbPlayer;

    //will increase player size when holding B down
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Beefy");
        rbPlayer = player.GetComponent<Rigidbody>();
        rbPlayer.transform.localScale *= 4.0f;
        player.mCurrentState = this;
    }

    //decreases player size back to original after releasing B
    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.B))
        {
            rbPlayer.transform.localScale *= 0.25f;
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}