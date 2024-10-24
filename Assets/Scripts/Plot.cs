using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    private Color startColor;
    public bool checkTurret { get; set; }
    public bool selected { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Initialize()
    {
        startColor = sr.color;
        checkTurret = false;
        selected = false;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        // Kiểm tra nếu chuột đang không ở trên UI
        if (EventSystem.current.IsPointerOverGameObject()) return;

        if (!selected)
        {   
            UIManager.main.plot = this;
            UIManager.main.EnableBuildManager();
            selected = true;
        }
        else
        {
            UIManager.main.plot = null;
            UIManager.main.DisableBuildManager();
            selected = false;
        }
    }
}
