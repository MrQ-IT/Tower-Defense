using UnityEngine;
using UnityEngine.UI; // Sử dụng thư viện UI của Unity

public class StorylineController : MonoBehaviour
{
    public Text StorylineText; // Hiển thị cốt truyện
    public Text pageNumberText; // Hiển thị số trang
    public Button nextButton;
    public Button previousButton;

    // Mảng chứa các đoạn cốt truyện
    private string[] Storyline = {
        "Main storyline:\nIn a peaceful village nestled deep within the forest, home to gentle inhabitants, a dark force has risen and seeks to invade the village. The player takes on the role of a hero or leader, organizing the defense of the village against waves of enemy attacks. Defensive towers will be built at strategic locations in the village to stop the enemies from advancing.",

        "Village setting:\nThe forest village: The village has huts, stalls, houses, flowers, and fields. Players can use buildings and terrain to create various defense strategies.",

        "Village characters:\nArchers: Villagers who fight from atop tall towers.\nEnemies: Can include creatures from the forest, such as monsters that were previously exiled from the village.",

        "Defensive towers:\nSingle-target tower: Targets one enemy at a time, with average attack speed and stable damage.\nSlow tower: Slows enemies down, has a wide area of effect, but low damage.\nSniper tower: Long-range tower with high damage but slow attack speed. Effective against strong enemies.",

        "Levels and objectives:\nEach level represents a new wave of attacks with increasingly stronger enemies. Players must protect key structures in the village, such as the main hall, water sources, or temples."
    };



    private int currentPage = 0;

    void Start()
    {
        // Cập nhật thông tin ban đầu khi bắt đầu
        UpdateStoryline();
    }

    // Phương thức này sẽ cập nhật cốt truyện và số trang
    public void UpdateStoryline()
    {
        // Hiển thị cốt truyện và số trang hiện tại
        StorylineText.text = Storyline[currentPage];
        pageNumberText.text = (currentPage + 1) + "/" + Storyline.Length;

        // Kiểm tra trạng thái của các nút
        previousButton.interactable = currentPage > 0;
        nextButton.interactable = currentPage < Storyline.Length - 1;
    }

    // Phương thức gọi khi nhấn nút Next
    public void NextStoryline()
    {
        if (currentPage < Storyline.Length - 1)
        {
            currentPage++;
            UpdateStoryline();
        }
    }

    // Phương thức gọi khi nhấn nút Previous
    public void PreviousStoryline()
    {
        if (currentPage > 0)
        {
            currentPage--;
            UpdateStoryline();
        }
    }
}
