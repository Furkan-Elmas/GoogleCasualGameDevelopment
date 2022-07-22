using UnityEngine;

public class InputManager : MonoBehaviour
{
    bool _isClicking;
    float _mouseScrollDelta;

    public bool IsClicking => _isClicking;
    public float MouseScrollDelta => _mouseScrollDelta;

    public static InputManager Instance { get; private set; }
    

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {   
        // Taking input data on update method
        _mouseScrollDelta = Input.GetAxis("Mouse ScrollWheel");
        _isClicking = Input.GetButton("Fire1");
    }
}
