using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{

    private IState[] states = new IState[2];
    private IState currentState;

    // Start is called before the first frame update
    void Start()
    {
        states[0] = new StateWalking(gameObject, states, SwitchState);
        states[1] = new StateFlying(gameObject, states, SwitchState);

        currentState = states[0];
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    public void SwitchState(IState ie)
    {
        currentState = ie;
    }
}
