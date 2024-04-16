using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnButtons : MonoBehaviour
{
    public ScriptableObjects scriptableObject; // Pøipojte váš scriptable objekt sem
    public GameObject buttonPrefab; // Pøetáhnìte prefab tlaèítka sem ve vaší hierarchii

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        if (scriptableObject != null && buttonPrefab != null)
        {
            foreach (var item in scriptableObject.seznamPolozek)
            {
                GameObject buttonGO = Instantiate(buttonPrefab, transform);
                Button button = buttonGO.GetComponent<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(() => ButtonClicked(item));
                    TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
                    if (buttonText != null)
                    {
                        buttonText.text = item.nazev;
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Scriptable object or button prefab is not assigned.");
        }
    }

    void ButtonClicked(hodnoty_do_seznamu item)
    {
        // Implementace, co se má stát po kliknutí na tlaèítko
        Debug.Log("Clicked on button for: " + item.nazev);
    }
}
