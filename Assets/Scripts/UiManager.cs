using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class UiManager : MonoBehaviour
{
    /*
    private GameManager _gameManager;
    private Ship _ship;
    private Player _player;

    //UI
    public GameObject menuPanel;
    public GameObject gamePanel;
    public GameObject overPanel;
    public GameObject levelPanel;
    public GameObject enemyGroup;
    public GameObject BossGroup;
    public Text maxScoText;
    public Text scoText;
    public Text stageText;
    public Text playTimeText;
    public Text playerHealthText;
    public Text playerAmmoText;
    public Text playerCoinText;
    public Image weapon1Img;
    public Image weapon2Img;
    public Image weapon3Img;
    public Image weapon4Img;
    public Image weaponRImg;
    public Text enemyAText;
    public Text enemyBText;
    public Text enemyCText;
    public RectTransform bossHealthGroup;
    public RectTransform bossHealthBar;
    public Text curScoreText;
    public Text bestText;
    public GameObject crossHair;
    
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
        switch (_gameManager.SType)
        {
            case GameManager.SceneType.Game:
                _gameManager.enemyList = new List<int>();
                maxScoText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
                break;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _gameManager = FindObjectOfType<GameManager>();
        _player = FindObjectOfType<Player>();
        levelPanel.SetActive(false);
        switch (_gameManager.SType)
        {
            case GameManager.SceneType.Game:
                _gameManager.enemyList = new List<int>();
                maxScoText.text = string.Format("{0:n0}", PlayerPrefs.GetInt("MaxScore"));
                break;
        }
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    
    
    public void Aiming()
    {
        crossHair.SetActive(true);
    }

    public void EndAiming()
    {
        crossHair.SetActive(false);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //Weapon UI
        weapon1Img.color = new Color(1, 1, 1, _player.hasWeapons[0] ? 1 : 0);
        weapon2Img.color = new Color(1, 1, 1, _player.hasWeapons[1] ? 1 : 0);
        weapon3Img.color = new Color(1, 1, 1, _player.hasWeapons[2] ? 1 : 0);
        weapon4Img.color = new Color(1, 1, 1, _player.hasWeapons[3] ? 1 : 0);
        weaponRImg.color = new Color(1, 1, 1, _player.hasGrendes > 0 ? 1 : 0);
        // Player UI
        playerHealthText.text = _player._health.ToString();
        playerCoinText.text = string.Format("{0:n0}", _player._coin.Value);
        if (_player.equipWeapon == null)
            playerAmmoText.text = "- / " + _player._ammo.Value;
        else if (_player.equipWeapon.type == Weapon.Type.Melee)
            playerAmmoText.text = "- / " + _player._ammo.Value;
        else
        {
            Range range;
            range = _player.equipWeapon.GetComponent<Range>();
            playerAmmoText.text = range._curAmmo + "/" + _player._ammo.Value;
        }

        switch (_gameManager.SType)
        {
            case GameManager.SceneType.Camp:
                stageText.text = "roost";

                break;
            case GameManager.SceneType.Game:
                // UI 
                scoText.text = string.Format("{0:n0}", _player.score);
                if(_gameManager.stage <= 10)
                    stageText.text = "STAGE " + _gameManager.stage;

                int hour = (int)(_gameManager.playTime / 3600);
                int min = (int)((_gameManager.playTime - hour * 3600) / 60);
                int sec = (int)(_gameManager.playTime % 60);
                playTimeText.text = string.Format("{0:00}", hour) + ":"
                                                                  + string.Format("{0:00}", min) + ":" +
                                                                  string.Format("{0:00}", sec);

                //Cnt Enemy UI
                enemyAText.text = _gameManager.enemyCntA.ToString();
                enemyBText.text = _gameManager.enemyCntB.ToString();
                enemyCText.text = _gameManager.enemyCntC.ToString();

                //Boss Health UI
                if (_gameManager.boss != null)
                {
                    bossHealthGroup.anchoredPosition = Vector3.down * 30;
                    bossHealthBar.localScale =
                        new Vector3((float)_gameManager.boss._health.Value / _gameManager.boss._health.GetMaxValue(), 1, 1);
                }
                else
                {
                    bossHealthGroup.anchoredPosition = Vector3.up * 200;
                }
                break;
        }
    }
    */

    [SerializeField] Text _hp;
    [SerializeField] Text _stamina;
    [SerializeField] Text _ammo;

    [SerializeField] Image _equipWeapon;
    [SerializeField] Sprite[] _sprWeapons;
    [SerializeField] Sprite _sprDefault;
    [SerializeField] InforPanel _inforPanel;

    Player _player;

    private void Start()
    {
        _player = Player.s_Instance;
        _equipWeapon.sprite = _sprDefault;
    }
    private void Update()
    {
        _hp.text = Player.s_Instance._health.ToString();
        _stamina.text = (int)Player.s_Instance._stamina.Value + " / " + (int)Player.s_Instance._stamina.GetMaxValue();


        int equipIdx = Player.s_Instance.equipWeaponIndex;

        if (Input.GetKeyDown(KeyCode.Tab)) {
            _inforPanel.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            _inforPanel.gameObject.SetActive(false);
        }

        if (equipIdx > -1)
        {
            _equipWeapon.sprite = _sprWeapons[equipIdx];
            if (_player.equipWeapon.type == Weapon.Type.Range)
            {
                Range range = _player.equipWeapon.GetComponent<Range>();
                _ammo.text = range._ammo.ToString();
            }
            else
            {
                _ammo.text = "- / -";
            }
        }
        else
        {
            _equipWeapon.sprite = _sprDefault;
            _ammo.text = "- / -";

        }
    }
}