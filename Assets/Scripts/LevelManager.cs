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

    [SerializeField] private LevelSO[] levelSO;

    // star of level 
    public Image star;
    public Sprite[] starSprite;

    //LockImage
    public Image imageLockMap;

    public Image preMapImage;
    public Image nextMapImage;

    public Button clickToLoadScene;
    public Button nextButton;
    public Button prevButton;

    public int currentIndex = 0;

    private void Start()
    {
        UpdateMapDisplay();
    }

    //next map button event
    public void NextMap()
    {
        currentIndex = (currentIndex + 1) % maps.Length; //next map      
        UpdateMapDisplay();
    }

    //pre map button event
    public void PreMap()
    {
        currentIndex = (currentIndex - 1 + maps.Length) % maps.Length;
        UpdateMapDisplay();
    }

    //show image lock
    public void ShowImage()
    {
        //Color color = imageLockMap.color;
        //color.a = 1f;
        //imageLockMap.color = color;
        imageLockMap.gameObject.SetActive(true);
        star.gameObject.SetActive(false);
    }

    //hide image lock
    public void HideImage()
    {
        //Color color = imageLockMap.color;
        //color.a = 0f;
        //imageLockMap.color = color;
        imageLockMap.gameObject.SetActive(false);
        star.gameObject.SetActive(true);
    }
    public void UpdateMapDisplay()
    {
        if (maps.Length > 0)
        {
            //display selected map
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

            //PlayerPrefManager.UnlockMap(0);
            //CheckCompleteCondition();
            // check selected map is unlock
            //if (PlayerPrefManager.IsMapUnlocked(currentIndex))
            if (!levelSO[currentIndex].islock)
            {
                if (levelSO[currentIndex].star == 0)
                {
                    star.sprite = starSprite[0];
                }
                else if ( levelSO[currentIndex].star == 1)
                {
                    star.sprite = starSprite[1];
                }
                else if ( levelSO[currentIndex].star == 2)
                {
                    star.sprite = starSprite[2];
                }
                else
                {
                    star.sprite = starSprite[3];
                }
                HideImage();
            }
            else
            {
                ShowImage();
            }
        }
    }

    // select map button event
    public void LoadScene()
    {
        //if (PlayerPrefManager.IsMapUnlocked(currentIndex))
        if (!levelSO[currentIndex].islock)
        {
            string sceneToLoad = maps[currentIndex].sceneName;
            SceneManager.LoadScene(sceneToLoad);

        }
        else
        {
            Debug.Log("You can't load new map!");
        }
    }

    // button to back main menu
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // button to open Skill Shop
    public void SkillShopButton()
    {
        SceneManager.LoadScene("SkillShop");
    }

    // button to open Achievements
    public void AchievementButton()
    {
        SceneManager.LoadScene("AchievementsScene");
    }
    //public void CompleteMap()
    //{
    //    if (currentIndex < maps.Length - 1)
    //    {
    //        Debug.Log("Finish Lvl,Unlock next map");
    //        Debug.Log(maps.Length);
    //        PlayerPrefManager.UnlockMap(currentIndex + 1);
    //    }
    //    else if (currentIndex == maps.Length - 1)
    //    {
    //        Debug.Log("Max level you can play");
    //    }

    //}
    //public void CheckCompleteCondition()
    //{

    //}

    //public void Reset()
    //{
    //    PlayerPrefManager.ResetAllData();
    //}
}

