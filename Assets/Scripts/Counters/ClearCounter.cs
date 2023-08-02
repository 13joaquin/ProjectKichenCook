using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter, IKitchenObjectParent
{
    
    [SerializeField] public KitchenObjectSO kitchenObjectSO;
     //Update is called once per frame
   
    public override void Interact (Player player){
        //Debug.Log("Interact");
        if(!HasKitchenObject()){
            //No hay KitchenObject aqui
            if(player.HasKitchenObject()){
                //El jugador lleva algo
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else{
                //El jugador no lleva algo
            }
        }else{
            // Hay KitchenObject aqui
            if(player.HasKitchenObject()){
                //El jugador lleva algo
            }else{
                //El jugador no lleva algo
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    /* Start is called before the first frame update
    void Start()
    {
        
    }
        
    }*/
}
