using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private Player playerInput;
    private Player.OnFootActions onFootActions;

    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerLook playerLook;
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new Player();
        onFootActions = playerInput.OnFoot;
        onFootActions.Jump.performed += ctx => playerMovement.Jump();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerMovement.ProcessMove(onFootActions.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        playerLook.ProcessLook(onFootActions.Look.ReadValue<Vector2>());

    }

    private void OnEnable()
    {
        onFootActions.Enable();
    }
    private void OnDisable()
    {
        onFootActions.Disable();
    }
}
