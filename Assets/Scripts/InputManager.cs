using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private Player playerInput;
    public Player.OnFootActions OnFoot;

    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerLook playerLook;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new Player();
        OnFoot = playerInput.OnFoot;
        OnFoot.Jump.performed += ctx => playerMovement.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement.ProcessMove(OnFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(OnFoot.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        OnFoot.Enable();
    }
    private void OnDisable()
    {
        OnFoot.Disable();
    }
}
