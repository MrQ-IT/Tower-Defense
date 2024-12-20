using UnityEngine;
using UnityEngine.SceneManagement;

public class EncyclopediaManager : MonoBehaviour
{
    public GameObject encyclopediaPanel;
    public GameObject towersPanel;
    public GameObject enemiesPanel;
    public GameObject tipsPanel;
    public GameObject storylinePanel;

    // This method is called when a panel button is clicked
    public void ShowTowersPanel()
    {
        ShowPanel(towersPanel);
    }

    public void ShowEnemiesPanel()
    {
        ShowPanel(enemiesPanel);
    }

    public void ShowTipsPanel()
    {
        ShowPanel(tipsPanel);
    }

    public void ShowStorylinePanel()
    {
        ShowPanel(storylinePanel);
    }

    public void ShowEncyclopediaPanel()
    {
        ShowPanel(encyclopediaPanel);
    }

    // This method is called when the quit button is clicked
    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // General method to handle showing panels
    void ShowPanel(GameObject panelToShow)
    {
        // Hide all panels
        encyclopediaPanel.SetActive(false);
        towersPanel.SetActive(false);
        enemiesPanel.SetActive(false);
        tipsPanel.SetActive(false);
        storylinePanel.SetActive(false);

        // Show the selected panel
        panelToShow.SetActive(true);
    }
}