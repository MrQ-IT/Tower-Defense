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

    "Bối cảnh ngôi làng:\nNgôi làng trong rừng: Làng có các túp lều, sạp hàng, căn nhà, hoa cỏ và những cánh đồng. Người chơi có thể sử dụng các công trình và địa hình để tạo ra các chiến lược phòng thủ khác nhau.",

    "Nhân vật trong làng:\nCung thủ: Là những người tham gia chiến đấu trên các tòa tháp cao.\nKẻ thù: Có thể là những sinh vật đến từ khu rừng, bao gồm cả các quái vật đã từng bị trục xuất khỏi làng trước đây.",

    "Các tòa tháp phòng thủ:\nTháp đơn: Tháp mục tiêu đơn, tốc độ tấn công trung bình, sát thương ổn định.\nTháp làm chậm: Làm chậm kẻ địch, diện tích ảnh hưởng rộng, sát thương thấp.\nTháp bắn tỉa: Tháp tầm xa, sát thương cao, tốc độ tấn công chậm. Hiệu quả chống lại kẻ thù mạnh.",

    "Cấp độ và mục tiêu:\nMỗi cấp độ sẽ là một cuộc tấn công mới với kẻ thù ngày càng mạnh. Người chơi phải bảo vệ các công trình quan trọng trong làng, ví dụ như tòa nhà chính, nguồn nước, hoặc đền thờ."
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
