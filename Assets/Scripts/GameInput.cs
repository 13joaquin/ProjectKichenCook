using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance {get; private set;}
    public event EventHandler OnInteractionAction;
    public event EventHandler OnInteractionAlternactAction;
    public event EventHandler OnPauseAction;
    private PlayerInputActions playerInputAction;
    public void Awake() {
        Instance = this;
        playerInputAction = new PlayerInputActions();
        playerInputAction.Player.Enable();

        playerInputAction.Player.Interact.performed += Interact_performed;
        playerInputAction.Player.InteractAlternate.performed += InteractAlternate_performed;
        playerInputAction.Player.Pause.performed += Pause_performed;
    }
    private void OnDestroy() {
         playerInputAction.Player.Interact.performed -= Interact_performed;
        playerInputAction.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playerInputAction.Player.Pause.performed -= Pause_performed;
        playerInputAction.Dispose();
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }
    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnInteractionAlternactAction?.Invoke(this, EventArgs.Empty);
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj){
        OnInteractionAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormlized(){
         Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
         
        inputVector = inputVector.normalized;
        return inputVector;
    }
    /* Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
