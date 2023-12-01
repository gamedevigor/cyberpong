using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveController : MonoBehaviour
{
    public Color colorPlayer = Color.white;
    public Color colorEnemy = Color.white;

    public string nameEnemy;
    public string namePlayer;

    private string savedWinnerKey = "SavedWinner";

    private static SaveController _instance;

    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();

                if (_instance == null )
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if ( _instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        if (string.IsNullOrEmpty(nameEnemy))
        {
            nameEnemy = "Player 2";
        }

        else if (string.IsNullOrEmpty(namePlayer))
        {
            namePlayer = "Player 1";
        }

        return isPlayer ? namePlayer : nameEnemy;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString(savedWinnerKey, winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString(savedWinnerKey);
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Reset()
    {
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }
}