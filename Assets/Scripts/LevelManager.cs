using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro.Examples;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    public class Map
    {
        public string name;
        public Sprite image;
        public string sceneName;
    }
    public Map[] maps;
    public Image mapImage;
    public Text mapTitle;

    //LockImage
    public Image imageLockMap;

    public Image preMapImage;
    public Image nextMapImage;

    public Button clickToLoadScene;
    public Button nextButton;
    public Button prevButton;
    public Button resetDataButton;

    public int currentIndex = 0;

    private void Start()
    {
        UpdateMapDisplay();
    }
    //next map
    public void nextMap()
    {
        currentIndex = (currentIndex + 1) % maps.Length; //next map      
        UpdateMapDisplay();
    }

    //pre map
    public void preMap()
    {
        currentIndex = (currentIndex - 1 + maps.Length) % maps.Length;
        UpdateMapDisplay();
    }
    //show Image

    public void showImage()
    {
        Color color = imageLockMap.color;
        color.a = 1f;
        imageLockMap.color = color;
    }
    //hide Image
    public void hideImage()
    {
        Color color = imageLockMap.color;
        color.a = 0f;
        imageLockMap.color = color;
    }
    public void UpdateMapDisplay()
    {
        if (maps.Length > 0)
        {
            //display map
            mapImage.sprite = maps[currentIndex].image; //update image
            mapTitle.text = maps[currentIndex].name; //update tilte map

            // Display next map
            int prevIndex = (currentIndex - 1 + maps.Length) % maps.Length;
            preMapImage.sprite = maps[prevIndex].image;

            // Display pre map
            int nextIndex = (currentIndex + 1) % maps.Length;
            nextMapImage.sprite = maps[nextIndex].image;
            // Color next & pre map
            preMapImage.color = new Color(1, 1, 1, 0.5f);
            nextMapImage.color = new Color(1, 1, 1, 0.5f);

            PlayerPrefManager.UnlockMap(0);
            CheckCompleteCondition();
            if (PlayerPrefManager.IsMapUnlocked(currentIndex))
            {
                hideImage(); //hide unlock img if map is unlocked
            }
            else
            {
                showImage();
            }
        }
    }
    public void LoadScene()
    {
        if (PlayerPrefManager.IsMapUnlocked(currentIndex))
        {
            string sceneToLoad = maps[currentIndex].sceneName;
            SceneManager.LoadScene(sceneToLoad);

        }
        else {
            Debug.Log("You can't load new map!");
        }
    }
    public void CompleteMap()
    {       
        if(currentIndex < maps.Length - 1)
        {
            Debug.Log("Finish Lvl,Unlock next map");
            Debug.Log(maps.Length);
            PlayerPrefManager.UnlockMap(currentIndex + 1);
        }
        else if(currentIndex == maps.Length - 1)
        {
            Debug.Log("Max level you can play");
        }
        
    }
    public void CheckCompleteCondition()
    {
        //LevelCompleteManager levelCompleteManager = new LevelCompleteManager();
        //if(levelCompleteManager.CheckLevelComp() == true)
        //{
        //    CompleteMap();
        //}
    }

    public void Reset()
    {
        PlayerPrefManager.ResetAllData();
    }
}

