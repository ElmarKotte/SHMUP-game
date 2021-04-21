using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public void StartShake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }

    IEnumerator Shake (float duration, float magnitude)
    {
        Vector3 origin = transform.localPosition;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1, 1f) * magnitude;
            float y = Random.Range(-1, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, origin.z);

            elapsed += Time.deltaTime;
            print("elapsed " + elapsed + " and duration " + duration);

            yield return null;
        }


        transform.localPosition = new Vector3(0, 0, 0);
        yield return null;
    }
}
