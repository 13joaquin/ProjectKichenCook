using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;
    private bool isWalking;
    private void Update(){
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
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);
           
            if (canMove)
            {
                //Solo puede moverse en la x
                moveDir = moveDirX;
            }else
            {
                //No puede moverse en la x
                // Intento solo Z movierse
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);
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
    public bool IsWalking(){
        return isWalking;
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
