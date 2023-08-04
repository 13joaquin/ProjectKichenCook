using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    private List<KitchenObjectSO> kitchenObjectSOList;
    private void Awake() {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO){
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO)){
            //No es un ingrediente válido
            return false;
        }
        if(kitchenObjectSOList.Contains(kitchenObjectSO)){
            //Ya tiene este tipo
            return false;
        }else{
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }
}
