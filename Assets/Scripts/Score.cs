using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _text;

    public int Count { get; private set; }
    
    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
    
    public void Increment()
    {
        Count++;
        _text.text = Count.ToString();
    }
}
