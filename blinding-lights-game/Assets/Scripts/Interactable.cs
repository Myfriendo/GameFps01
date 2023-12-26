using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // message displayed to the player when they are in range of the interactable
    public bool useEvents;
    [SerializeField]
    public string promptMessage;
    // this function will be called when the player interacts with the object
    public virtual string Onlook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {   
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }

    protected virtual void Interact()
    {
        // we won't have any code written in this function
        // but we will have it in the child classes
    }
}
