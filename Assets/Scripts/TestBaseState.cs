
using UnityEngine;

public abstract class TestBaseState
{
    /// <summary>
    /// Enter Runs Once During the Switch State
    /// </summary>
    /// <param name="manager"></param>


    public virtual void Enter(TestManager manager) { }


    /// <summary>
    /// Update Runs Every Frame Only During this state is Active
    /// </summary>
    /// <param name="manager"></param>
    public virtual void Update(TestManager manager) { }


    /// <summary>
    /// It runs only once Before Switching from This State to another State 
    /// </summary>
    /// <param name="manager"></param>
    public virtual void Exit(TestManager manager) { }
}
