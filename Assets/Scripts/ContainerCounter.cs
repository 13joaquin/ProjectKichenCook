using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{   
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] public KitchenObjectSO kitchenObjectSO;

    public override void Interact (Player player){
        //Debug.Log("Interact");
        if(!player.HasKitchenObject()){
             //El jugador no lleva algo
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }

    }
}
