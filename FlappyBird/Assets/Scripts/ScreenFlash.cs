using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFlash : MonoBehaviour
{
    public Image flashImage;

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        flashImage.color = new Color(1, 1, 1, 1);

        float t = 0f;
        while (t < 0.15f)
        {
            t += Time.unscaledDeltaTime;
            flashImage.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, t / 0.15f));
            yield return null;
        }
    }
}
