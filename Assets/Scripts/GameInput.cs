using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputAction;
    private void Awake() {
        playerInputAction = new PlayerInputActions();
        playerInputAction.Player.Enable();
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