using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAI : MonoBehaviour
{

    private IState[] states = new IState[2];
    private IState currentState;

    private Controls ctrl;
    private InputAction flying;

    private void Awake()
    {
        ctrl = new Controls();
        flying = ctrl.Player.Flying;
    }
    private void OnEnable()
    {
        ctrl.Enable();  
    }

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

        if (flying.WasPressedThisFrame())
        {
            SwitchState(states[(currentState == states[0] ? 1 : 0)]);
        }
    }

    public void SwitchState(IState ie)
    {
        currentState = ie;
    }
}
