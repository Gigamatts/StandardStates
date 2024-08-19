using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFlying : IState
{
    private GameObject gObject;
    private IState[] Istates;
    private Action<IState> switchState;

    public StateFlying(GameObject go, IState[] states,Action<IState> act)
    {
        gObject = go;
        Istates = states;
        switchState = act;
    }
    public void Update()
    {
        Debug.Log("Flying");
        //gObject.GetComponent<CharacterAI>().SwitchState(Istates[0]);
        switchState(Istates[0]);
    }
}
