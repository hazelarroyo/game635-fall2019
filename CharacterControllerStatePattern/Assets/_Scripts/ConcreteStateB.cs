using System;
using UnityEngine;

class ConcreteStateB : State
{
    public override void Handle1()
    {
        Debug.Log("ConcreteStateB handles request1.");
    }

    public override void Handle2()
    {
        Debug.Log("ConcreteStateB handles request2.");
        Debug.Log("ConcreteStateB wants to change the state of the context.");
        this._context.TransitionTo(new ConcreteStateA());
    }
}
