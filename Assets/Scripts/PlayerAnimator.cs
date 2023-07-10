using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "";
    [SerializeField] private Player player;
    private Animator animatior;
    private void Awake() {
        animatior = GetComponent<Animator>();
    }
    private void Update(){
        animatior.SetBool(IS_WALKING,player.IsWalking());
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
