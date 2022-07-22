using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 5f;

    Vector3 _centralObject;


    void Awake()
    {
        _centralObject = GameObject.Find("Sun").transform.position;
    }

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }


    IEnumerator MoveCoroutine()
    {
        while (!InputManager.Instance.IsClicking) // If user click to screen coroutine stops
        {
            transform.RotateAround(_centralObject, Vector3.up, Time.deltaTime * _rotationSpeed);
            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(ClickCoroutine());
    }

    IEnumerator ClickCoroutine()
    {
        float time = 3;

        while (time > 0)
        {
            if (InputManager.Instance.IsClicking) time = 3; // Every click restarts coroutine
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        UIManager.Instance.ResetPanels();
        StartCoroutine(MoveCoroutine());
    }
}
