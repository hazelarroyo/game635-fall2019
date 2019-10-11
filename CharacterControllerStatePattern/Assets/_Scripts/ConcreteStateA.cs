using System;
using UnityEngine;

class ConcreteStateA : State
{
    public override void Handle1()
    {
        Debug.Log("ConcreteStateA handles request1.");
        Debug.Log("ConcreteStateA wants to change the state of the context.");
        this._context.TransitionTo(new ConcreteStateB());
    }

    public override void Handle2()
    {
        Debug.Log("ConcreteStateA handles request2.");
    }
}
