using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCoundtdownUI : MonoBehaviour
{
    private const string NUMBER_POPUP = "NumberPopup";
    [SerializeField] private TextMeshProUGUI countdownText;
    private Animator animator;
    private int previosCountdownNumber;
    private void Awake() {
        animator = GetComponent<Animator>();
    }
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
        int countdownNumber = Mathf.CeilToInt(KichenGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();
        if(previosCountdownNumber != countdownNumber){
            previosCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
        }
    }
    private void Show(){
        gameObject.SetActive(true);
    }
    private void Hide(){
        gameObject.SetActive(false);
    }
}
