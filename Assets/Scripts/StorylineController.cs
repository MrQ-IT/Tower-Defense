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
    "Cốt truyện chính:\nTrong một ngôi làng yên bình nằm sâu trong rừng, nơi sinh sống của những cư dân hiền hòa, một thế lực đen tối đã trỗi dậy và muốn xâm chiếm ngôi làng. Người chơi sẽ đóng vai một anh hùng hoặc thủ lĩnh, tổ chức việc bảo vệ ngôi làng khỏi các đợt tấn công của kẻ thù. Các tòa tháp phòng thủ sẽ được xây dựng trên các vị trí chiến lược trong ngôi làng để ngăn chặn kẻ địch tiếp cận.",

    "Bối cảnh ngôi làng:\nNgôi làng trong rừng: Làng có các căn nhà tranh, suối nước, cối xay gió và những cánh đồng. Người chơi có thể sử dụng các công trình và địa hình để tạo ra các chiến lược phòng thủ khác nhau.\nTài nguyên của làng: Mỗi căn nhà hoặc khu vực đặc biệt có thể tạo ra tài nguyên (vàng, gỗ, đá) mà người chơi cần để xây dựng và nâng cấp các tòa tháp.",

    "Nhân vật trong làng:\nDân làng: Là những người bình thường nhưng sẽ cung cấp hỗ trợ, nâng cấp các tòa tháp hoặc thậm chí tham gia chiến đấu.\nKẻ thù: Có thể là những sinh vật đến từ khu rừng, bao gồm cả các quái vật và phù thủy đã từng bị trục xuất khỏi làng trước đây.",

    "Các tòa tháp phòng thủ:\nTháp cung thủ: Được đặt trên những căn nhà cao hoặc tháp canh.\nTháp pháp sư: Đặt gần các khu vực linh thiêng hoặc đền đài cổ.\nChướng ngại vật: Sử dụng các yếu tố của làng như cối xay gió hoặc bức tường để làm vật cản.",

    "Cấp độ và mục tiêu:\nMỗi cấp độ sẽ là một cuộc tấn công mới với kẻ thù ngày càng mạnh. Người chơi phải bảo vệ các công trình quan trọng trong làng, ví dụ như tòa nhà chính, nguồn nước, hoặc đền thờ. Những công trình này nếu bị phá hủy sẽ ảnh hưởng đến khả năng phòng thủ."
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
