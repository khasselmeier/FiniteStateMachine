using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisPlayerState : IPlayerState
{
    Player mPlayer;
    MeshRenderer meshRenderer;
    GameObject gameObject;

    //will turn player invisible while holding I
    public void Enter(Player player)
    {
        Debug.Log("Entering State: Invisible");
        meshRenderer = player.GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
        //gameObject.GetComponent<MeshRenderer>().enabled = false;
        player.mCurrentState = this;
    }

    //player will return to normal after release
    public void Execute(Player player)
    {
        if (!Input.GetKey(KeyCode.I))
        {
            meshRenderer = player.GetComponent<MeshRenderer>();
            meshRenderer.enabled = true;
            StandingPlayerState standingState = new StandingPlayerState();
            standingState.Enter(player);
        }
    }
}