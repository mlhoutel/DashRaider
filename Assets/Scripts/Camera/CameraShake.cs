using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {


    [Range(0, 1)] [SerializeField] float trauma;
    [SerializeField] float traumaMultiplicator = 40f;
    [SerializeField] float traumaMagnitude = 1f;
    [SerializeField] float traumaRotationMagnitude = 17f;
    [SerializeField] float traumaFallMagnitude = 0.3f;
    [SerializeField] float traumaDecay = 4f;

    public bool camShakeActive = true;
    private float timeCounter;
    public float Trauma
    {
        get
        {
            return trauma;
        }
        set
        {
            trauma = Mathf.Clamp01(value);
        }
    }

    private float GetFloat(float seed)
    {
        return (Mathf.PerlinNoise(seed, timeCounter) - 0.5f) * 2;
    }

    private Vector3 GetVector3()
    {
        return new Vector3(GetFloat(1), GetFloat(10), 0);
    }

    private void Update()
    {
        if (camShakeActive && (Trauma>0.05) )
        {
            timeCounter += Time.deltaTime * Mathf.Pow(trauma, traumaFallMagnitude) * traumaMultiplicator;
            Vector3 newPos = GetVector3() * traumaMagnitude * Trauma;
            transform.localPosition += newPos;
            //transform.localRotation = Quaternion.Euler(newPos * traumaRotationMagnitude);
            trauma -= Time.deltaTime * trauma * traumaDecay;
        }
        else
        {

        }
    }
}
