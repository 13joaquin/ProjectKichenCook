using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{ 
    public static Player Instance {  get; private set;  }
   
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs {
        public BaseCounter selectedCounter;
    }
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
     [SerializeField] private Transform kitchenObjectHoldpPonit;
    private bool isWalking;
    private Vector3 lastInteractDir;
    private BaseCounter selectedCounter;
    private KitchenObject kitchenObject;
    private void Awake() {
        if (Instance != null)
        {
            Debug.LogError("Hay más de una instancia de jugador");
        }
        Instance = this;
    }
       // Start is called before the first frame update
    private void Start()
    {
        gameInput.OnInteractionAction += GameInput_OnInteractAction;
        gameInput.OnInteractionAlternactAction += GameInput_OnInteractAlternateAction;
    }
    private void GameInput_OnInteractAlternateAction(object sender, EventArgs e){
        if(selectedCounter != null){
            selectedCounter.InteractAlternate(this);
        }
    }
    private void GameInput_OnInteractAction(object sender, System.EventArgs e){
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }
    private void Update(){
       HandheldMovement();
       HandheldInteractions();
    }
    public bool IsWalking(){
        return isWalking;
    }
    private void HandheldInteractions(){
       Vector2 inputVector = gameInput.GetMovementVectorNormlized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
        if (moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out BaseCounter baseCounter)){
                //Tiene ClearCounter
                if (baseCounter != selectedCounter)
                {
                    SerSelectedCounter(baseCounter);
                }
            }else
            {
                SerSelectedCounter(null);
            }
        }else {
            SerSelectedCounter(null);
        }
    }
    private void HandheldMovement(){
        Vector2 inputVector = gameInput.GetMovementVectorNormlized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        
        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);
        
        if (!canMove)
        {
            //No puede moverse hacia moveDier
            //Intento solo x moviente
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
           
            if (canMove)
            {
                //Solo puede moverse en la x
                moveDir = moveDirX;
            }else
            {
                //No puede moverse en la x
                // Intento solo Z movierse
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
                if (canMove)
                {
                    //Solo puede moverse en la Z
                    moveDir = moveDirZ;
                }else
                {
                    //No puede moverse una sola direccion
                }
            }
        }
        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }
        isWalking = moveDir != Vector3.zero;
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir, Time.deltaTime * rotateSpeed);
        //Debug.Log(Time.deltaTime);
    }
    private void SerSelectedCounter(BaseCounter selectedCounter){
        this.selectedCounter = selectedCounter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs{
            selectedCounter = selectedCounter
        });
    }
    public Transform GetKitchenObjectFollowTransform(){
        return kitchenObjectHoldpPonit;
    }
     public void SetKichenObject(KitchenObject kitchenObject){
        this.kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject(){
        return kitchenObject;
    }
    public void ClearKitchenObject(){
        kitchenObject = null;
    }
    public bool HasKitchenObject(){
        return kitchenObject != null;
    }

    /* Update is called once per frame
    void Update()
    {
        
    }*/
}
