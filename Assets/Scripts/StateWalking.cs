using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWalking : IState
{
    private GameObject gObject;
    private IState[] Istates;
    private Action<IState> switchState;

    public StateWalking(GameObject go, IState[] states, Action<IState> act)
    {
        gObject = go;
        Istates = states;
        switchState = act;
    }
    public void Update()
    {

        Debug.Log("Walking");
        //gObject.GetComponent<CharacterAI>().SwitchState(Istates[1]);
        switchState(Istates[1]);
    }
}
