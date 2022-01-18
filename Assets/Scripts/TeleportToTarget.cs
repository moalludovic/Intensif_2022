using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToTarget : MonoBehaviour
{
    public Transform myCam;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TP(Transform target){
        Quaternion rot;
        Vector3 f = Quaternion.Inverse(transform.rotation) * myCam.transform.forward;
        if (f.x!=0|| f.z != 0){
            rot = Quaternion.LookRotation(new Vector3(f.x,0, f.z), Vector3.up);
            rot = Quaternion.Inverse(rot);
        }
        else{
            Debug.Log("abort the mission");
            rot = transform.rotation;
        }
        Vector3 pos = myCam.transform.localPosition;
        pos.y = 0;
        pos = rot * pos;
        pos = target.position - pos;
        transform.position = pos;
        transform.rotation = rot;
    }
}
