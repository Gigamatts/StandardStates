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
        gObject.transform.position += Vector3.up * 0.05f;
    }
}
