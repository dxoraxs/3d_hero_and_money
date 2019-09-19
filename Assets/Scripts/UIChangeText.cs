using UnityEngine;
using UnityEngine.UI;

public class UIChangeText : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _finishPanel;
    [SerializeField] private Text _coinText;
    [SerializeField] private Text _timeText;
    
    public void SetTextTimeIsGameOver(string text)
    {
        _timeText.text = text;
    }

    public void SetTextCoinUI(string text)
    {
        _coinText.text = "Score: "+text;
    }

    public void GameOverSetActive()
    {
        _gameOverPanel.SetActive(true);
    }

    public void FinishSetActive()
    {
        _finishPanel.SetActive(true);
    }
}
