using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI ui;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().theCamera;
        ui = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ui.UpdateText(string.Empty);
        Ray ray = new(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactables>() != null)
            {
                Interactables interactables = hitInfo.collider.GetComponent<Interactables>();
                //Debug.Log(hitInfo.collider.GetComponent<Interactables>().PromtMessage);
                ui.UpdateText(interactables.PromtMessage);
                if(inputManager.OnFoot.Interact.triggered)
                {
                    interactables.BaseInteract();
                }
            }
        }

    }
}
