using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    [SerializeField] GameObject _meteorPrefab;
    [SerializeField] float _meteorSpeed;

    MeteorController _meteorController;

    GameObject[] _planetPositions;

    public static MeteorManager Instance;

    public float MeteorSpeed { get => _meteorSpeed; set => _meteorSpeed = value; }
    public GameObject[] PlanetPositions { get => _planetPositions; set => _planetPositions = value; }

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

        _meteorController = new MeteorController(_meteorPrefab);
        _planetPositions = GameObject.FindGameObjectsWithTag("Planet"); // Taking all planets' gameobject veriables by their tag
    }

    void Start()
    {
        StartCoroutine(_meteorController.MeteorFallCoroutine());
    }
}
