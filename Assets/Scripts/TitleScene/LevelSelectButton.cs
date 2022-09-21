using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    protected Button m_Button;


    public Text titleDisplay;
    public Text description;
    public Sprite starAchieved;
    public Image[] stars;
    protected MouseScroll m_MouseScroll;
    protected LevelItem m_Item;
    
    public void ButtonClicked()
    {
        ChangeScenes();
    }
    protected void ChangeScenes()
    {
       SceneManager.LoadScene(m_Item.sceneName);
    }
    
    public void Initialize(LevelItem item, MouseScroll mouseScroll)
    {
        LazyLoad();
        if (titleDisplay == null)
        {
            return;
        }
        m_Item = item;
        titleDisplay.text = item.name;
        description.text = item.description;
        HasPlayedState();
        m_MouseScroll = mouseScroll;
    }
    protected void HasPlayedState()
    {
        GameManager gameManager = GameManager.instance;
        if (gameManager == null)
        {
            return;
        }
        int starsForLevel = gameManager.GetStarsForLevel(m_Item.id);
        for (int i = 0; i < starsForLevel; i++)
        {
            stars[i].sprite = starAchieved;
        }
    }
    protected void LazyLoad()
    {
        if (m_Button == null)
        {
            m_Button = GetComponent<Button>();
        }
    }
    
    protected void OnDestroy()
    {
        if (m_Button != null)
        {
            m_Button.onClick.RemoveAllListeners();
        }
    }
    
    public void OnSelect(BaseEventData eventData)
    {
        m_MouseScroll.SelectChild(this);
    }

}