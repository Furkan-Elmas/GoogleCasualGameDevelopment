using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] float _rotationSpeed = 5f;

    Vector3 _centralObject;
    bool _isMoving = true;


    void Awake()
    {
        _centralObject = GameObject.Find("Sun").transform.position;
    }

    void Start()
    {
        StartCoroutine(MoveCoroutine());
    }

    void Update()
    {
        if (InputManager.Instance.IsClicking)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.transform == null) return;

                switch (hit.transform.root.name)
                {
                    case "Earth":
                        UIManager.Instance.ResetPanels();
                        UIManager.Instance.OpenEarthPanel();
                        break;
                    case "Moon":
                        UIManager.Instance.ResetPanels();
                        UIManager.Instance.OpenMoonPanel();
                        break;
                    case "Jupiter":
                        UIManager.Instance.ResetPanels();
                        UIManager.Instance.OpenJupiterPanel();
                        break;
                    case "Saturn":
                        UIManager.Instance.ResetPanels();
                        UIManager.Instance.OpenSaturnPanel();
                        break;
                    case "Sun":
                        UIManager.Instance.ResetPanels();
                        UIManager.Instance.OpenSunPanel();
                        break;
                }
            }
        }
    }

    IEnumerator MoveCoroutine()
    {
        while (!InputManager.Instance.IsClicking)
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
            if (InputManager.Instance.IsClicking) time = 3;
            time -= Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        UIManager.Instance.ResetPanels();
        StartCoroutine(MoveCoroutine());
    }
}
