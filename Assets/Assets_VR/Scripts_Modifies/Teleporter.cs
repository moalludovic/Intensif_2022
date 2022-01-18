using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform TeleporterDestination;
    public CharacterController Player;
    public IEnumerator DelaiTeleportation;
    public bool PlayerIsHere = false;

    private float ditanceMin;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
