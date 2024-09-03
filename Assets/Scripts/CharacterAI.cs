using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Searcher;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
[DefaultExecutionOrder(1)]

public class CharacterAI : MonoBehaviour
{

    private IState[] states = new IState[2];
    private IState currentState;

    private Controls controls;
    private InputAction flying;

    private Coroutine moveToTargetCoroutine;

    public Grid grid;
    private void Awake()
    {
        controls = new Controls();
        flying = controls.Player.Flying;

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    // Start is called before the first frame update
    void Start()
    {
        states[0] = new StateWalking(gameObject, states, SwitchState);
        states[1] = new StateFlying(gameObject, states, SwitchState);

        currentState = states[0];
        moveToTargetCoroutine = StartCoroutine(moveToTarget());
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
        if (flying.WasPressedThisFrame())
        {
            SwitchState(states[currentState == states[0] ? 1 : 0]);
        }
        

        
    }
    private IEnumerator moveToTarget()
    {
        yield return new WaitForEndOfFrame();
        Vector3 oldPosition = grid.path[grid.path.Count - 1].worldPosition;
        
        //loop that moves to each node in path towards target
        foreach (Node n in grid.path)
        {
            //if seeker reaches target, stop
            if (grid.path.Count < 2)
            {
                Debug.Log("ACHEI VOCE");
                StopCoroutine(moveToTargetCoroutine);
                Debug.Log("PORQUEEEEE");

            }
            for ( float timer = 0; timer < 1; timer += 0.1f)
            {
                //if target moves, escape loop
                if (grid.path[grid.path.Count - 1].worldPosition != oldPosition)
                {
                    break;
                }

                //move to next node
                transform.position = Vector3.Lerp(transform.position, n.worldPosition + new Vector3(0,0.4f,0), timer);

                yield return new WaitForEndOfFrame();
            }
        }

        //if target moves, restart loop
        moveToTargetCoroutine = StartCoroutine(moveToTarget());
    }
    public void SwitchState(IState ie)
    {
        currentState = ie;
    }
}
