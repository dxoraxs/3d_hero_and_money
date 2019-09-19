using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    [SerializeField] private UIChangeText _uIChangeText;
    private int _playerCoin;    

    public void AddOneCoin()
    {
        _playerCoin++;
        _uIChangeText.SetTextCoinUI(_playerCoin.ToString());
    }
}
