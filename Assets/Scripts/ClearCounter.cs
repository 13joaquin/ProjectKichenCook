using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    
    [SerializeField] public KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPonit;
    [SerializeField] private bool testing;
    private KitchenObject kitchenObject;
     //Update is called once per frame
   
    public void Interact (Player player){
        //Debug.Log("Interact");
        if(kitchenObject == null){
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab,counterTopPonit);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }else{
            //Dar el objeto al jugador
            kitchenObject.SetKitchenObjectParent(player);
           //Debug.Log(kitchenObject.GetKitchenObjectParent());
       }
    }
    public Transform GetKitchenObjectFollowTransform(){
        return counterTopPonit;
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
    /* Start is called before the first frame update
    void Start()
    {
        
    }
        
    }*/
}
