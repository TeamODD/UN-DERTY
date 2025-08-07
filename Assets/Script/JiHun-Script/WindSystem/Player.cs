using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bOnGround = true;
            foreach (Action action in onGroundActions)
                action();
        }
            
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bOnGround = false;
        }
    }
    public void RegistOnGroundAction(Action action)
    {
        onGroundActions.Add(action);
    }
    public bool IsOnGround() { return bOnGround; }
    private List<Action> onGroundActions = new List<Action>();
    private bool bOnGround = false;
}
