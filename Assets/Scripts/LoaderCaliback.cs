using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCaliback : MonoBehaviour
{
    private bool isFirstUpdate = true;
    void Update()
    {
        if(isFirstUpdate){
            isFirstUpdate = false;
            Loader.LoaderCaliback();
        }
    }
}
