using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCoundtdownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    private void Start() {
        KichenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }
    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e){
        if(KichenGameManager.Instance.IsCountdownToStartActive()){
            Show();
        }else{
            Hide();
        }
    }
    private void Update() {
        countdownText.text = Mathf.Ceil(KichenGameManager.Instance.GetCountdownToStartTimer()).ToString();
    }
    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
