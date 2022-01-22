using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform TeleporterDestination;
    public CharacterController Player;

    public float distanceMin;
    

    // Update is called once per frame
    void Update()
    {
        float currentDist = Vector3.Distance(transform.localPosition, Player.transform.localPosition);

        if (currentDist <= distanceMin)
        {
            Player.GetComponent<TeleportToTarget>().TP(TeleporterDestination);
        }

    }
    
}
