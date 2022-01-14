using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    private float perlinNoise = 0f;
    [HideInInspector]
    public float multiplier = 0f;
    public int nbObjX;
    public int nbObjZ;
    private int nbObj;
    public float taillePerlinNoise = 0.1f;

    public GameObject Obj;
    public float objScale;

    private Vector3 newObjPos;
    [HideInInspector]
    public List<GameObject> Objs;
    private float decalageX;
    private float decalageZ;

    [HideInInspector]
    public List<Vector3> startPositions;
    [HideInInspector]
    public List<float> frequences;
    public float frequence = 1f;
    public float speed = 2;
    public float magnitude = 0.2f;
    public float offset = 0;
    public float tmpMax;
    private float startTime = 0;
    [HideInInspector]
    public bool timeUp = false;

    // Start is called before the first frame update
    void Start()
    {
        nbObj = nbObjX * nbObjZ;
        decalageX = (nbObjX * objScale) / 2;
        decalageZ = (nbObjZ * objScale) / 2;

        for (int i = 0; i < nbObjX; i++)
        {
            for (int j = 0; j < nbObjZ; j++)
            {
                perlinNoise = Mathf.PerlinNoise(i * taillePerlinNoise, j * taillePerlinNoise);
                newObjPos = new Vector3(((i * objScale) - (decalageX - gameObject.transform.position.x)), (perlinNoise * multiplier) + gameObject.transform.position.y, ((j * objScale) - (decalageZ - gameObject.transform.position.z)));
                var NewObj = Instantiate(Obj, newObjPos, new Quaternion(0, 0, 0, 0));
                NewObj.transform.parent = gameObject.transform;

                Objs.Add(NewObj);
                startPositions.Add(NewObj.transform.localPosition);
                frequences.Add(frequence + (NewObj.transform.localPosition.y*10)/2);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (startTime <= 0)
        {
            timeUp = true;
        }else if (startTime >= tmpMax)
        {
            timeUp = false;
        }

        if (timeUp)
        {
            startTime += 0.01f;
        }
        else if (!timeUp)
        {
            startTime -= 0.01f;
        }

        foreach (GameObject Object in Objs)
        {
            int index = Objs.IndexOf(Object);
            Object.transform.localPosition = startPositions[index] + transform.up * Mathf.Sin((startTime * speed) * frequences[index] + offset) * magnitude;
        }
    }

}
