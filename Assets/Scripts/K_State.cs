using UnityEngine;
public class K_State : TestBaseState 
{
    private float _timer;
    public override void Enter(TestManager manager)
    {
        Debug.Log("Entered K_State");
        _timer = 5f; // Setting Max Time
    }

    public override void Update(TestManager manager)
    {
        Debug.Log("Upadte in K_State");
        if(_timer >= 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            manager.SwitchState(manager.d_State);
        }
    }

    public override void Exit(TestManager manager)
    {
        Debug.Log("Exit in K_State");
    }
}
