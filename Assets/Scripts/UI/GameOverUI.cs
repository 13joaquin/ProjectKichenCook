using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    private void Start() {
        KichenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e){
        if(KichenGameManager.Instance.IsGameOver()){
            Show();
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }else{
            Hide();
        }
    }
    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
