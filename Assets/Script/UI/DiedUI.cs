using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiedUI : MonoBehaviour
{
    private GameObject uiGameObject;
    public static DiedUI Instance{ get; private set;}

    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
            return;

        }
        Instance = this;
    }

    void Start()
    {
        uiGameObject = transform.Find("DiedUI").gameObject;
        Hide();
        
    }


    public void Show(){
        uiGameObject.SetActive(true);

        
        
    }

    private void Hide(){
        uiGameObject.SetActive(false);

    }
}
