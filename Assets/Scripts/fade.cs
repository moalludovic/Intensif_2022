using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float fadeDuration = .1f;
    [SerializeField]
    private float fadePow = 3;

    private Volume volume;
    private LiftGammaGain liftGainOverride;

    // Start is called before the first frame update
    void Start()
    {
            //flash
            volume = GetComponent<Volume>();

            volume.profile.TryGet<LiftGammaGain>(out liftGainOverride);
            liftGainOverride.active = true;

            StartCoroutine("FadeOut");
    }
	
    private IEnumerator FadeOut()
    {
        float i = 1f;
        do
        {
            i -= Time.deltaTime / fadeDuration;
            i = Mathf.Max(i, 0);
            liftGainOverride.lift.value = new Vector4(liftGainOverride.lift.value.x, liftGainOverride.lift.value.y, liftGainOverride.lift.value.z, Mathf.Pow(i,fadePow));
            yield return new WaitForEndOfFrame();
        }
        while (i >0);

        yield return null;
    }
}
