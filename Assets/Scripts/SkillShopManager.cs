using UnityEngine;
using UnityEngine.UI;

public class SkillShopManager : MonoBehaviour
{
    public GameObject skillPrefab; // Tham chiếu tới prefab kỹ năng
    public Transform skillPanel; // Vị trí để spawn các kỹ năng (UI Panel)
    public Text goldText;
    public Button resetButton;
    public Button backButton;

    private int playerGold = 100;

    // Dữ liệu giả lập cho các kỹ năng
    private string[] skillNames = { "Kỹ Năng 1", "Kỹ Năng 2", "Kỹ Năng 3", "Kỹ Năng 4" };
    private string[] skillDescriptions = { "Mô tả 1", "Mô tả 2", "Mô tả 3", "Mô tả 4" };
    private Sprite[] skillIcons; // Gắn các sprite cho icon của kỹ năng

    void Start()
    {
        InitializeSkills();
        UpdateGoldUI();
        resetButton.onClick.AddListener(OnResetButtonClick);
        backButton.onClick.AddListener(OnBackButtonClick);
    }

    // Khởi tạo các kỹ năng
    void InitializeSkills()
    {
        for (int i = 0; i < 4; i++)
        {
            // Tạo kỹ năng từ prefab
            GameObject skillObject = Instantiate(skillPrefab);
            
            // Lấy script SkillManager để khởi tạo giá trị cho từng kỹ năng
            SkillManager skillManager = skillObject.GetComponent<SkillManager>();
            skillManager.InitializeSkill(skillIcons[i], skillNames[i], skillDescriptions[i], 1, 50);
        }
    }

    // Cập nhật UI vàng
    void UpdateGoldUI()
    {
        goldText.text = "Gold: " + playerGold.ToString();
    }

    // Xử lý nút reset
    void OnResetButtonClick()
    {
        SkillManager[] skillManagers = skillPanel.GetComponentsInChildren<SkillManager>();
        foreach (var skill in skillManagers)
        {
            skill.ResetSkill();
        }
        playerGold = 100;
        UpdateGoldUI();
    }

    // Xử lý nút back
    void OnBackButtonClick()
    {
        Debug.Log("Quay lại màn hình trước");
    }
}
