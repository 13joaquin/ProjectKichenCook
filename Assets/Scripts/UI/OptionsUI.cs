using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsUI : MonoBehaviour
{
    [SerializeField] private Button soundEffectsButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private TextMeshProUGUI soundEffectsText;
    [SerializeField] private TextMeshProUGUI musicText;
    private void Awake() {
        soundEffectsButton.onClick.AddListener(() => {
            SoundManager.Instance.ChangeVolume();
            UpddateVisual();
        });
        musicButton.onClick.AddListener(() => {});
    }
    private void Start() {
        UpddateVisual();
    }
    private void UpddateVisual(){
        soundEffectsText.text = "Efecto de Sonido:" + Mathf.Round(SoundManager.Instance.GetVolume()*10f);
    }
}
