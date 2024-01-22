using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueUI : MonoBehaviour
{
    
    public static DialogueUI Instance{ get; private set;}
    private TextMeshProUGUI nameText;
    private TextMeshProUGUI contentText;
    private List<string> contentList;
    private Button continueButton;
    private int contentIndex = 0;
    private GameObject uiGameObject;
    private Action OnDialogueEnd;

    private void Awake(){
        if(Instance != null && Instance != this){
            Destroy(this.gameObject);
            return;

        }
        Instance = this;
    }

    private void Start(){
        nameText = transform.Find("UI/name text").GetComponent<TextMeshProUGUI>();
        contentText = transform.Find("UI/content text").GetComponent<TextMeshProUGUI>();
        continueButton = transform.Find("UI/Button").GetComponent<Button>();
        continueButton.onClick.AddListener(this.OnContinueButtonClick);
        uiGameObject = transform.Find("UI").gameObject;
        Hide();
       

    }
    public void Show()
    {
        uiGameObject.SetActive(true);
        
    }

    public void Show(string name, string[] content, Action OnDialogueEnd = null){
        nameText.text = name;
        contentList = new List<string>();
        contentList.AddRange(content);
        contentIndex = 0;
        contentText.text = contentList[0];
        uiGameObject.SetActive(true);
        this.OnDialogueEnd = OnDialogueEnd;
    }

    public void Hide(){
        uiGameObject.SetActive(false);   
    }

    private void OnContinueButtonClick(){
        
        contentIndex++;
        if(contentIndex >= contentList.Count){
            OnDialogueEnd?.Invoke();
            Hide();
            return;
        }
        contentText.text = contentList[contentIndex];
        

    }
}
