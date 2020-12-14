using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivatable
{

    
    event EventHandlers.ActivationManager OnActivation;

    bool Activated
    {
        get;
    }

    void Activate(GameObject sender);
}
