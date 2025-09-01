using UnityEngine;
using Naninovel;

public class InteractiveItem : MonoBehaviour
{
    private ICustomVariableManager variableManager;
    private Renderer rend;
    private Material mat;

    [Header("Цвета")]
    public Color normalColor = Color.white;
    public Color hoverColor = Color.yellow;

    [SerializeField] private QuestUIController questUI;

    private void Awake()
    {
        variableManager = Engine.GetService<ICustomVariableManager>();
        rend = GetComponent<Renderer>();
        mat = rend.material;
        mat.SetColor("_OutLine_Color", normalColor);


        if (questUI == null)
            questUI = FindObjectOfType<QuestUIController>();
    }

    private void OnMouseEnter()
    {
        mat.SetColor("_OutLine_Color", hoverColor);
    }

    private void OnMouseExit()
    {
        mat.SetColor("_OutLine_Color", normalColor);
    }

    private void OnMouseDown()
    {
        if (!enabled || !gameObject.activeInHierarchy) return;

        gameObject.SetActive(false);
        variableManager.SetVariableValue("Take_Item", "true");

        // Скрываем UI квеста
        if (questUI != null)
            questUI.HideAfterCompletion();
    }
}
