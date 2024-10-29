using UnityEngine;
using UnityEngine.UI;

public class EncyclopediaSwitcher : MonoBehaviour
{
    public GameObject encyclopediaPanel;
    public GameObject towersPanel;
    public GameObject enemiesPanel;
    public GameObject tipsPanel;

        // Gán các nút trong Inspector
    public Button towersButton;
    public Button enemiesButton;
    public Button tipsButton;

        // Nút Back cho từng panel
    public Button towersBackButton;
    public Button enemiesBackButton;
    public Button tipsBackButton;

    void Start()
    {
        // Đặt trạng thái hiển thị ban đầu
        ShowPanel(encyclopediaPanel);

        // Thêm sự kiện cho các nút chuyển đổi panel
        towersButton.onClick.AddListener(() => ShowPanel(towersPanel));
        enemiesButton.onClick.AddListener(() => ShowPanel(enemiesPanel));
        tipsButton.onClick.AddListener(() => ShowPanel(tipsPanel));

        // Thêm sự kiện cho nút Back quay về panel chính
        towersBackButton.onClick.AddListener(() => ShowPanel(encyclopediaPanel));
        enemiesBackButton.onClick.AddListener(() => ShowPanel(encyclopediaPanel));
        tipsBackButton.onClick.AddListener(() => ShowPanel(encyclopediaPanel));
    }

    void ShowPanel(GameObject panelToShow)
    {
        // Ẩn tất cả các panel
        encyclopediaPanel.SetActive(false);
        towersPanel.SetActive(false);
        enemiesPanel.SetActive(false);
        tipsPanel.SetActive(false);

        // Hiển thị panel được chọn
        panelToShow.SetActive(true);
    }
}
