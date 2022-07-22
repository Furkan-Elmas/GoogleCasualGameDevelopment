using UnityEngine;

public class UIController : MonoBehaviour
{
    void Update()
    {
        if (InputManager.Instance.IsClicking)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.transform == null) return;

                // Every hit are controlled by their hit.transform.name
                UIManager.Instance.ResetPanels();
                switch (hit.transform.name)
                {
                    case "Earth":
                        UIManager.Instance.OpenEarthPanel();
                        break;
                    case "Moon":
                        UIManager.Instance.OpenMoonPanel();
                        break;
                    case "Jupiter":
                        UIManager.Instance.OpenJupiterPanel();
                        break;
                    case "Saturn":
                        UIManager.Instance.OpenSaturnPanel();
                        break;
                    case "Sun":
                        UIManager.Instance.OpenSunPanel();
                        break;
                }
            }
        }
    }
}
