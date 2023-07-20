using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] public KitchenObjectSO kitchenObjectSO;
    public ClearCounter clearCounter;
    public KitchenObjectSO GetKitchenObjectSO(){
        return kitchenObjectSO;
    }
    
    public void SetClearCounter(ClearCounter clearCounter){
        if(this.clearCounter != null){
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter;
        if(clearCounter.HasKitchenObject()){
            Debug.LogError("Counter ya tiene a KitchenObject");
        }
        clearCounter.SetKichenObject(this);
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter(){
        return clearCounter;
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
