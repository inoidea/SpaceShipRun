using Main;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class EnterName : MonoBehaviour
{
    [SerializeField] TMP_InputField chatInput;
    [SerializeField] Button enterBtn;

    private void Awake()
    {
        enterBtn.onClick.AddListener(() => AddUser(chatInput.text));
    }

    private void AddUser(string userName)
    {
        gameObject.SetActive(false);
    }
}