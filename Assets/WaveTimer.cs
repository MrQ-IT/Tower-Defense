using UnityEngine;
using UnityEngine.UI;

public class WaveTimer : MonoBehaviour
{
    public float countdownTime = 10f; // Tổng thời gian đếm ngược
    public Image timerCircle;         // Hình tròn hiển thị thời gian
    public RectTransform arrow;      // Đối tượng mũi tên
    public Transform waveStartPoint; // Điểm bắt đầu của wave
    private float currentTime;

    void Start()
    {
        //currentTime = countdownTime;
        // Đảm bảo mũi tên hướng về điểm bắt đầu lúc khởi tạo
        UpdateArrowPositionAndRotation();
    }

    void Update()
    {
        //if (currentTime > 0)
        //{
        //    // Giảm thời gian
        //    currentTime -= Time.deltaTime;

        //    // Cập nhật phần trăm hiển thị của hình tròn
        //    if (timerCircle != null)
        //    {
        //        timerCircle.fillAmount = currentTime / countdownTime;
        //    }

        // Cập nhật hướng mũi tên
        UpdateArrowPositionAndRotation();
        //}
        //else
        //{
        //    // Khi thời gian hết
        //    StartNextWave();
        //}
    }

    Vector3 GetPointOnCircleEdge(RectTransform circle, Transform waveStartPoint)
    {
        if (circle == null || waveStartPoint == null)
            return Vector3.zero;

        // Tâm của hình tròn trong Screen Space
        Vector3 circleCenterScreen = RectTransformUtility.WorldToScreenPoint(Camera.main, circle.position);

        // Điểm bắt đầu (waveStartPoint) trong Screen Space
        Vector3 waveStartScreen = RectTransformUtility.WorldToScreenPoint(Camera.main, waveStartPoint.position);

        // Vector hướng từ tâm hình tròn đến điểm bắt đầu trong Screen Space
        Vector3 directionScreen = (waveStartScreen - circleCenterScreen).normalized;

        // Bán kính của hình tròn trong Screen Space
        float radiusScreen = (circle.rect.width / 2f) * circle.lossyScale.x;

        // Tính vị trí điểm trên chu vi trong Screen Space
        Vector3 pointOnEdgeScreen = circleCenterScreen + directionScreen * radiusScreen;

        // Chuyển điểm từ Screen Space về World Space (Canvas)
        Vector3 pointOnEdgeWorld;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(circle, pointOnEdgeScreen, Camera.main, out pointOnEdgeWorld);

        // Debug để kiểm tra
        Debug.Log($"Wave Start Point (Screen): {waveStartScreen}");
        Debug.Log($"Circle Center (Screen): {circleCenterScreen}");
        Debug.Log($"Point on Edge (Screen): {pointOnEdgeScreen}");
        Debug.Log($"Point on Edge (World): {pointOnEdgeWorld}");

        return pointOnEdgeWorld;
    }

    void UpdateArrowPositionAndRotation()
    {
        // Lấy điểm trên chu vi
        Vector3 pointOnCircle = GetPointOnCircleEdge(timerCircle.rectTransform, waveStartPoint);

        // Đặt vị trí mũi tên
        arrow.position = pointOnCircle;

        // Tính toán hướng
        Vector3 direction = (pointOnCircle - timerCircle.rectTransform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Xoay mũi tên
        arrow.rotation = Quaternion.Euler(0, 0, angle);
    }



    void StartNextWave()
    {
        Debug.Log("Next wave started!");
        currentTime = countdownTime; // Reset thời gian
    }
}
