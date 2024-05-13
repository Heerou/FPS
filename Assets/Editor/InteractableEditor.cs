using UnityEditor;
[CustomEditor(typeof(Interactables), true)]
public class InteractableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Interactables interactables = (Interactables)target;
        if (target.GetType() == typeof(EventOnlyInteractable))
        {
            interactables.PromtMessage = EditorGUILayout.TextField("Prompt Message", interactables.PromtMessage);
            EditorGUILayout.HelpBox("EventOnlyInteract can ONLY use UnityEvents", MessageType.Info);
            if (interactables.GetComponent<InteractionEvent>() == null)
            {
                interactables.UseEvents = true;
                interactables.gameObject.AddComponent<InteractionEvent>();
            }
        }
        else
        {
            base.OnInspectorGUI();
            if (interactables.UseEvents)
            {
                if (interactables.GetComponent<InteractionEvent>() == null)
                    interactables.gameObject.AddComponent<InteractionEvent>();
            }
            else
            {
                if (interactables.GetComponent<InteractionEvent>() != null)
                    DestroyImmediate(interactables.GetComponent<InteractionEvent>());
            }
        }
    }
}
