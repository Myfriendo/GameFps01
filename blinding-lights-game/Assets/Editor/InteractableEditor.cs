using UnityEditor;
[CustomEditor(typeof(Interactable),true)]
public class InteractableEditor : Editor
{

    public override void OnInspectorGUI()
    {               
        Interactable interactable = (Interactable)target;

        if(target.GetType()== typeof(EventOnlyInteractable)){
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage);
            EditorGUILayout.HelpBox("This is an event only interactable. It will not have any code written in the Interact() function.", MessageType.Info);
            if(!interactable.GetComponent<InteractionEvent>())
            {
                interactable.useEvents=true;
                interactable.gameObject.AddComponent<InteractionEvent>();    
            }
                        
        }
        else
        {
            base.OnInspectorGUI();
            if (interactable.useEvents)
            {
                if (!interactable.GetComponent<InteractionEvent>())
                { 
                    interactable.gameObject.AddComponent<InteractionEvent>();
                }
            }
            else
            {
                if (interactable.GetComponent<InteractionEvent>())
                { 
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>());
                }
            }
        }
    }
}
