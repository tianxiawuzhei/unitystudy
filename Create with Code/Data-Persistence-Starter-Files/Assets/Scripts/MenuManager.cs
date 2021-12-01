using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text _txScore;
    [SerializeField] private InputField _inputField;

    // Start is called before the first frame update
    void Start()
    {
        _txScore.text = $"Best Score : {GameManage.Instance.nameHighest} : {GameManage.Instance.scoreHighest}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onBtnStart()
    {
        GameManage.Instance.curName = _inputField.text;
        SceneManager.LoadScene(1);
    }

    public void onBtnExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
