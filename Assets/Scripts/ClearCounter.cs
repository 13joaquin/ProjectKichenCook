using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    
    [SerializeField] public KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPonit;
    [SerializeField] public ClearCounter secondClearCounter;
    [SerializeField] private bool testing;
    private KitchenObject kitchenObject;
     //Update is called once per frame
   private void Update(){
        if(testing && Input.GetKeyDown(KeyCode.T)){
            if(kitchenObject != null){
                kitchenObject.SetClearCounter(secondClearCounter);
                //Debug.Log(kitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact (){
        //Debug.Log("Interact");
        if(kitchenObject == null){
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab,counterTopPonit);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
            /*kitchenObjectTransform.localPosition = Vector3.zero;
            kitchenObject =  kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.SetClearCounter(this);*/
            //Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
       }else{
           Debug.Log(kitchenObject.GetClearCounter());
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
