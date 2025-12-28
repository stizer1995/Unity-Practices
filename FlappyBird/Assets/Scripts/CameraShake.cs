using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Vector3 originalPos;

    void Awake()
    {
        originalPos = transform.localPosition;
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        float time = 0f;

        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            transform.localPosition = originalPos + Random.insideUnitSphere * magnitude;
            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
