using UnityEngine;

public class ResizePanels : MonoBehaviour
{
    public RectTransform panelJoueur1;
    public RectTransform panelTable;
    public RectTransform panelJoueur2;

    private void Start()
    {
        float screenWidth = Screen.width;

        // Calcul des tailles en fonction de l'écran
        panelJoueur1.sizeDelta = new Vector2(screenWidth * 0.4f, 0);
        panelTable.sizeDelta = new Vector2(screenWidth * 0.2f, 0);
        panelJoueur2.sizeDelta = new Vector2(screenWidth * 0.4f, 0);
    }
}
