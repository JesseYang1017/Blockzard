using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskNPCObject : InteractableObject
{
    public string npcName;
    public GameTaskSO gameTaskSO;

    public string[] contentInTaskExecution;
    public string[] contentInTaskCompleted;
    public string[] contentInTaskEnd;

    private void Start(){
        gameTaskSO.state = GameTaskState.Waiting;
    }
    protected override void Interact(){
        switch (gameTaskSO.state){
            case GameTaskState.Waiting:
                DialogueUI.Instance.Show(npcName, gameTaskSO.dialogue, OnDialogueEnd);
                break;
            case GameTaskState.Executing:
                DialogueUI.Instance.Show(npcName, contentInTaskExecution, OnDialogueEnd);
                break;
            case GameTaskState.Completed:
                DialogueUI.Instance.Show(npcName, contentInTaskCompleted, OnDialogueEnd);
                break;
            case GameTaskState.End:
                DialogueUI.Instance.Show(npcName, contentInTaskEnd, OnDialogueEnd);
                break;


        }

        

    }

    public void OnDialogueEnd(){
        switch(gameTaskSO.state){
            case GameTaskState.Waiting:
                gameTaskSO.Start();
                InventoryManager.Instance.AddItem(gameTaskSO.startReward);
                waiter();
                MessageUI.Instance.Show("You obtained: scythe. Press Space to attack");
                break;
            case GameTaskState.Completed:
                gameTaskSO.End();
                InventoryManager.Instance.AddItem(gameTaskSO.endReward);
                MessageUI.Instance.Show("Thank you for completing the quest!");
                break;
        }
    }
    IEnumerator waiter(){
        yield return new WaitForSeconds(10);
    }
}
