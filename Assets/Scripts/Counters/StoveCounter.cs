using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter, IHasProgress
{
     public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs{
        public State state;
    }
    public enum State {
        Idle,
        Frying,
        Fried,
        Burned,
    }
   [SerializeField] private FlyingRecipeSO[] flyingRecipeSOArray;
   [SerializeField] private BurningRecipeSO[] burningRecipesSOArray;
   private State state;
   private float fryingTimer;
   private FlyingRecipeSO flyingRecipeSO;
   private float burningTimer;
   private BurningRecipeSO burningRecipeSO;
   private void Start() {
       state = State.Idle;
   }
    private void Update() {
        if(HasKitchenObject()){
             switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs{
                        progressNormalized = fryingTimer / flyingRecipeSO.fryingTimerMax
                    });
                    if(fryingTimer > flyingRecipeSO.fryingTimerMax){
                        //Frito
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObjectt(flyingRecipeSO.output,this);
                        //Debug.Log("Objecto Frito!");
                        state = State.Fried;
                        burningTimer = 0f;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{
                            state = state
                        });
                    }
                    break;
                case State.Fried:
                 burningTimer += Time.deltaTime;
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs{
                        progressNormalized = burningTimer / burningRecipeSO.burningTimerMax
                    });
                    if(burningTimer> burningRecipeSO.burningTimerMax){
                        //Frito
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObjectt(burningRecipeSO.output,this);
                        //Debug.Log("Objecto Quemado!");
                        state = State.Burned;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{
                            state = state
                        });
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs{
                            progressNormalized = 0f
                        });
                    }
                    break;
                case State.Burned:
                    break;
            }
            //Debug.Log(state);
        }
    }
    public override void Interact(Player player)
    {
        if(!HasKitchenObject()){
            //No hay KitchenObject aqui
            if(player.HasKitchenObject()){
                //El jugador lleva algo
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO())){
                    //Jugador que lleva algo que se puede frito
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    flyingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    state = State.Frying;
                    fryingTimer = 0f;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{
                            state = state
                        });
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs{
                        progressNormalized = fryingTimer / flyingRecipeSO.fryingTimerMax
                    });
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
                state = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs{
                    state = state
                });
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs{
                    progressNormalized = 0f
                });
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
        private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO inpuntKitchenObjectSO){
        foreach (BurningRecipeSO burningRecipeSO in burningRecipesSOArray)
        {
            if(burningRecipeSO.input == inpuntKitchenObjectSO){
                return burningRecipeSO;
            }
        }
        return null;
    }
}
