using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color selectedColor;
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
        if (!selected)
        {   
            sr.color = selectedColor;
            UIManager.main.plot = this;
            UIManager.main.EnableBuildManager();
            selected = true;
        }
        else
        {
            sr.color = startColor;
            UIManager.main.plot = null;
            UIManager.main.DisableBuildManager();
            selected = false;
        }
    }
}
