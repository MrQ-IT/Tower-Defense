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
        "Tip 3: Use special skills wisely when enemies are clustered.",
        "Tip 4: Balance the tower types to deal with a variety of different types of enemies.",
        "Tip 5: Place strong towers at knots to make the most of AoE damage.",
        "Tip 6: Prioritize important targets such as strong or fast enemies.",
        "Tip 7: Keep resources under control and invest properly.",
        "Tip 8: Prepare the anti-air tower when the enemy is flying.",
        "Tip 9: Actively deal with bosses by saving powerful skills and upgrading strategies.",
        "Tip 9: Actively deal with bosses by saving powerful skills and upgrading strategies.",
        "Tip 10: Take advantage of the terrain to extend the time enemies move through the tower.",
        "Tip 11: Build a continuous damage tower where there is a detour to increase the shooting time.",
        "Tip 12: Observe and adjust tactics continuously based on the situation.",
        "Tip 13: Don't forget to sell the tower that is no longer effective to reinvest in a better location.",
        "Tip 14: Upgrade range on towers in key positions for broader coverage.",
        "Tip 15: Don’t neglect corners—they provide good coverage for multiple paths.",
        "Tip 16: Place resource-generating towers early (if available) to boost income for later waves.",
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
