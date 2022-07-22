using System.Collections;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    [SerializeField] Transform _centralPlanet;
    [SerializeField] AnimationCurve _animationCurve;
    [SerializeField] float _selfRotationSpeed = 50;
    [SerializeField] float _spaceRotationSpeed = 25;

    float _curveValue;
    float _rotationLoopValue;


    void Start()
    {
        _animationCurve.AddKey(360, 360); // For calculate full tour of a planet

        StartCoroutine(AnimationCurveCor());
    }

    IEnumerator AnimationCurveCor()
    {
        while (true)
        {
            transform.rotation = Quaternion.Euler(0, _animationCurve.Evaluate(_curveValue), 0); // Take corresponding value of keys (x-axis)
            transform.RotateAround(_centralPlanet.position, Vector3.up, Time.deltaTime * _spaceRotationSpeed);

            _curveValue += Time.deltaTime * _selfRotationSpeed; // Increase value of animation curve keys (y-axis)

            _rotationLoopValue += Time.deltaTime * _spaceRotationSpeed; // Calculate total angle
            if (_rotationLoopValue > 360) // Check for every 360 degree angle
            {
                _rotationLoopValue = 0; // reset
                Debug.Log($"{gameObject.name} has made a lap around {_centralPlanet.name}");
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
