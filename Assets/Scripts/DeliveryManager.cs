using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    public static DeliveryManager Instance {get; private set;}
    [SerializeField] private RecipeListSO recipeListSO;
  private List<RecipeSO> waitingRecipeSOList; 
  private float spawnRecipeTimer;
  private float spawnRecipeTimerMax  = 4f;
  private int waitingRecipesMax = 4;
  private void Awake() {
      Instance = this;
      waitingRecipeSOList = new List<RecipeSO>();
  }
  private void Update() {
      spawnRecipeTimer -= Time.deltaTime;
      if(spawnRecipeTimer <= 0f){
          spawnRecipeTimer = spawnRecipeTimerMax;
          if(waitingRecipeSOList.Count < waitingRecipesMax){
            RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[Random.Range(0,recipeListSO.recipeSOList.Count)];
            Debug.Log(waitingRecipeSO.recipeName);
            waitingRecipeSOList.Add(waitingRecipeSO);
          }
      }
  }
  public void DeliverRecipe(PlateKitchenObject plateKitchenObject){
      for (int i = 0; i < waitingRecipeSOList.Count; i++)
      {
        RecipeSO waitingRecipeSO = waitingRecipeSOList[i];
        if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
        {    //Tiene la misma cantidad de ingredientes
            bool plateContentsMatchesRecipe = true;
            foreach(KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList){
                //Recorriendo todos los ingredientes de la receta
                bool ingredientesFound = false;
                foreach(KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()){
                //Recorriendo todos los ingredientes de la plato
                    if(plateKitchenObjectSO == recipeKitchenObjectSO){
                        // Coincidencias de ingredientes
                        ingredientesFound = true;
                        break;
                    }
                }
                if(!ingredientesFound){
                    //Este ingrediente de receta no se encontró en el plato
                    plateContentsMatchesRecipe = false;
                }
            }
            if(plateContentsMatchesRecipe){
                //!El juegador entregó la receta correcta!
                Debug.Log("!El juegador entregó la receta correcta!");
                waitingRecipeSOList.RemoveAt(i);
                return;
            }
        }
    }
    //!No se encontraron coincidencias!
    //El jugador no entregó una receta correecta
    Debug.Log("El jugador no entregó una receta correecta");
  }
}
