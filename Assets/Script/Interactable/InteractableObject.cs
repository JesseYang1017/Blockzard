using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class InteractableObject : MonoBehaviour
{

    private NavMeshAgent playerAgent;
    private bool interacted = false;
    public void OnClick(NavMeshAgent playerAgent){
        this.playerAgent = playerAgent;
        playerAgent.stoppingDistance = 2;
        playerAgent.SetDestination(transform.position);
        interacted = false;

  }

    private void Update(){
        if (playerAgent != null && interacted == false && playerAgent.pathPending == false){
            if(playerAgent.remainingDistance<=2){
                Interact();
                interacted = true;
            }
        }
    }

    protected virtual void Interact(){
            print("interactable object");
    }
}
