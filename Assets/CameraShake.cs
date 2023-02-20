using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;

    private float shakeTimeRemaining, shakePower, shakeFadeTime, shakeRotation;

    public float rotationMultiplier = 7.5f;


    private void Start()
    {
        instance = this;
    }

    private void LateUpdate()
    {

    }

    private void FixedUpdate()
    {
        if (shakeTimeRemaining > 0)
        {
            shakeTimeRemaining -= Time.deltaTime;

            float xAmount = Random.Range(-1, 1) * shakePower;
            float yAmount = Random.Range(1, 1) * shakePower;

            //transform.localPosition -= new Vector3(xAmount, yAmount, 0);
            transform.localPosition += Random.insideUnitSphere * shakePower;

            shakePower = Mathf.MoveTowards(shakePower, 0, shakeFadeTime * Time.deltaTime);

            shakeRotation = Mathf.MoveTowards(shakeRotation, 0, shakeFadeTime * rotationMultiplier * Time.deltaTime);
        }

        transform.rotation = Quaternion.Euler(0, 0, shakeRotation * Random.Range(-1, 1));

    }

    public void StartShake(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;

        shakeFadeTime = power / length;

        shakeRotation = power * rotationMultiplier;
    }
}
