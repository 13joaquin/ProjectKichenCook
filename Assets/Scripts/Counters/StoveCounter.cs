using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounter : BaseCounter
{
   [SerializeField] private FlyingRecipeSO[] flyingRecipeSOArray;
    public override void Interact(Player player)
    {
        if(!HasKitchenObject()){
            //No hay KitchenObject aqui
            if(player.HasKitchenObject()){
                //El jugador lleva algo
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                    //Jugador que lleva algo que se puede Cocinar
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
    private bool HasRecipeWithInput(KitchenObjectSO inpuntKitchenObjectSO){
        FlyingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inpuntKitchenObjectSO);
        return fryingRecipeSO != null;
    }
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inpuntKitchenObjectSO){
        FlyingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inpuntKitchenObjectSO);
        if(fryingRecipeSO != null){
            return fryingRecipeSO.output;
        }else{
            return null;
        }
    }
    private FlyingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inpuntKitchenObjectSO){
        foreach (FlyingRecipeSO fryingRecipeSO in flyingRecipeSOArray)
        {
            if(fryingRecipeSO.input == inpuntKitchenObjectSO){
                return fryingRecipeSO;
            }
        }
        return null;
    }
}
