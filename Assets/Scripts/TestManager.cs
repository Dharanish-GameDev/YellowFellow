using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// The Test Manager is a Context Which has References to the concrete States
/// </summary>
public class TestManager : MonoBehaviour
{
    TestBaseState currentState;

    // Instantiating Concrete States in the Context.
    public K_State k_State = new K_State();
    public D_State d_State = new D_State();

    private void Start()
    {
        currentState = k_State;
        currentState.Enter(this);
    }


    private void Update()
    {
        currentState.Update(this);
    }

    public void SwitchState(TestBaseState state)
    {
        currentState.Exit(this);
        state.Enter(this);
        currentState = state;
    }
}
