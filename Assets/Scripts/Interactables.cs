using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Interactables : MonoBehaviour
{
    //Add or remove an interactioneven component to this object
    public bool UseEvents;
    public string PromtMessage;

    public void BaseInteract()
    {
        if (UseEvents)
        {
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        }
        Interact();
    }

    protected virtual void Interact()
    {

    }
}
