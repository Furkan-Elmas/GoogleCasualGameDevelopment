using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _earthPanel;
    [SerializeField] GameObject _moonPanel;
    [SerializeField] GameObject _jupiterPanel;
    [SerializeField] GameObject _saturnPanel;
    [SerializeField] GameObject _sunPanel;

    public static UIManager Instance { get; private set; }


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

    public void OpenEarthPanel()
    {
        _earthPanel.SetActive(true);
    }

    public void OpenMoonPanel()
    {
        _moonPanel.SetActive(true);
    }

    public void OpenJupiterPanel()
    {
        _jupiterPanel.SetActive(true);
    }

    public void OpenSaturnPanel()
    {
        _saturnPanel.SetActive(true);
    }

    public void OpenSunPanel()
    {
        _sunPanel.SetActive(true);
    }

    public void ResetPanels()
    {
        _earthPanel.SetActive(false);
        _moonPanel.SetActive(false);
        _jupiterPanel.SetActive(false);
        _saturnPanel.SetActive(false);
        _sunPanel.SetActive(false);
    }
}