using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TipsController : MonoBehaviour
{
    public TextMeshProUGUI tipsText;
    public TextMeshProUGUI pageNumberText;
    public Button nextButton;
    public Button previousButton;

    // Mảng chứa các mẹo chơi
    private string[] tips = {
        "Tip 1: Always start by placing basic towers near the entrance.",
        "Tip 2: Upgrade your towers instead of building too many new ones.",
        "Tip 3: Use special skills wisely when enemies are clustered."
    };

    private int currentPage = 0;

    void Start()
    {
        // Gán sự kiện cho các nút
        nextButton.onClick.AddListener(NextTip);
        previousButton.onClick.AddListener(PreviousTip);

        // Cập nhật thông tin ban đầu
        UpdateTip();
    }

    void UpdateTip()
    {
        // Cập nhật text hiển thị mẹo và số trang
        tipsText.text = tips[currentPage];
        pageNumberText.text = (currentPage + 1) + "/" + tips.Length;

        // Kiểm tra trạng thái của nút
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
