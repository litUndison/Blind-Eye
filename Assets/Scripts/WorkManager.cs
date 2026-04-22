using System.Collections.Generic;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    public List<string> _cards = new List<string>();
    [SerializeField] GameObject _aiworker;
    public string _theme; //сюда внести тему на которую надо гадать
    void Start()
    {
        _theme = Parameters._question;
    }
    public void MakePrompt()
    {
        _aiworker.GetComponent<UnityAndGeminiV3>().prompt = $"Я гадаю на игральных картах, представляя что это карты таро. Гадаю я по следующей теме '{_theme}'. Мне выпал следующий набор карт: {_cards[0]},{_cards[1]},{_cards[2]},{_cards[3]},{_cards[4]}. Составь мне предсказание в 5 предложений по моей теме исходя из полученного набора карт. Если тема гадания неподходящая, составь сообщение об ошибке, но напиши его мистическим текстом.";
        _aiworker.GetComponent<UnityAndGeminiV3>().enabled = true;
        GameObject.Find("Canvas").GetComponent<LoadingScript>()._state = Connect.connecting; // пытается подключить
    }
}
