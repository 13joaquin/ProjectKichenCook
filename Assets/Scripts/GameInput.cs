using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractionAction;
    private PlayerInputActions playerInputAction;
    public void Awake() {
        playerInputAction = new PlayerInputActions();
        playerInputAction.Player.Enable();

        playerInputAction.Player.Interact.performed += Interact_performed;
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
