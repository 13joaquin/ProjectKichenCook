using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private KitchenObjectSO cutKitchenObjectSO;
    public override void Interact(Player player)
    {
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
    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject()){
            // Hay un KitchenObject aqui
            GetKitchenObject().DestroySelf();
            Transform kitchenObjectTransform = Instantiate(cutKitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
    }
}
