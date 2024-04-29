using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D_State : TestBaseState
{
    public override void Enter(TestManager manager)
    {
        Debug.Log("Entered D_State");
    }

    public override void Update(TestManager manager)
    {
        Debug.Log("Upadte in D_State");
    }

    public override void Exit(TestManager manager)
    {
        Debug.Log("Exit in D_State");
    }
}
