using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToTarget : MonoBehaviour
{
    public void TP(Transform target){

        var player = this.GetComponent<CharacterController>();
        player.enabled = false;

        player.transform.localPosition = target.localPosition;
        player.transform.localRotation = target.localRotation;

        player.enabled = true;
    }
}
