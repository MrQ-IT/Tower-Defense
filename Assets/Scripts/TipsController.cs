using UnityEngine;
using UnityEngine.UI; // Use the UnityEngine.UI namespace

public class TipsController : MonoBehaviour
{
    public Text tipsText; // Change back to Text
    public Text pageNumberText; // Change back to Text
    public Button nextButton;
    public Button previousButton;

    // Array containing gameplay tips
    private string[] tips = {
        "Tip 1: Always start by placing basic towers near the entrance.",
        "Tip 2: Upgrade your towers instead of building too many new ones.",
        "Tip 3: Use special skills wisely when enemies are clustered."
    };

    private int currentPage = 0;

    void Start()
    {
        // Assign events to buttons
        nextButton.onClick.AddListener(NextTip);
        previousButton.onClick.AddListener(PreviousTip);

        // Update initial information
        UpdateTip();
    }

    void UpdateTip()
    {
        // Update the displayed tip and page number
        tipsText.text = tips[currentPage];
        pageNumberText.text = (currentPage + 1) + "/" + tips.Length;

        // Check the state of the buttons
        previousButton.interactable = currentPage > 0;
        nextButton.interactable = currentPage < tips.Length - 1;
    }

    void NextTip()
    {
        if (currentPage < tips.Length - 1)
        {
            currentPage++;
            UpdateTip();
        }
    }

    void PreviousTip()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateTip();
        }
    }
}
