using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private Transform _centralPlanet;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] float _selfRotationSpeed = 50;
    [SerializeField] float _spaceRotationSpeed = 25;

    private float _curveValue;
    private float _rotationLoopValue;

    void Start()
    {
        StartCoroutine(AnimationCurveCor());

        _animationCurve.AddKey(360, 360);
    }

    IEnumerator AnimationCurveCor()
    {

        while (true)
        {
            transform.rotation = Quaternion.Euler(0, _animationCurve.Evaluate(_curveValue), 0);
            transform.RotateAround(_centralPlanet.position, Vector3.up, Time.deltaTime * _spaceRotationSpeed);

            _curveValue += Time.deltaTime * _selfRotationSpeed;

            _rotationLoopValue += Time.deltaTime * _spaceRotationSpeed;
            if (_rotationLoopValue > 360)
            {
                _rotationLoopValue = 0;
                Debug.Log($"{gameObject.name} has made a lap around {_centralPlanet.name}");
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
