using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Standing");
        player.mCurrentState = this;
    }

    public void Execute(Player player)
    {
        //transition to jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpingPlayerState jumpingState = new JumpingPlayerState();
            jumpingState.Enter(player);
        }

        //transition to duck
        if (Input.GetKeyDown(KeyCode.S))
        {
            DuckingPlayerState duckingState = new DuckingPlayerState();
            duckingState.Enter(player);
        }

        //transition to beefy
        if (Input.GetKeyDown(KeyCode.B))
        {
            BeefyPlayerState beefyState = new BeefyPlayerState();
            beefyState.Enter(player);
        }

        //transition to invisibility
        if (Input.GetKeyDown(KeyCode.I))
        {
            InvisPlayerState invisState = new InvisPlayerState();
            invisState.Enter(player);
        }
    }
}