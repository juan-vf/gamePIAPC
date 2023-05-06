using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VigilantBaseState
{

    public abstract void Enter(VigilantSM vigilantSM);
    public abstract void Update(VigilantSM vigilantSM);
    public abstract void Exit(VigilantSM vigilantSM);
    public abstract void OnCollisionEnter(VigilantSM vigilantSM, Collision collision);
}
