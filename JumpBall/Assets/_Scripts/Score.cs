using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score S;
    public bool keepPlay;

    private Text thisText;

    private float _score;
    public float score
    {
        get
        {
            return _score;
        }
        set
        {
            _score = value;
            thisText.text = Mathf.RoundToInt(_score).ToString();
        }
    }

    private void Awake()
    {
        if (S == null) S = this;
        thisText = GetComponent<Text>();
        score = 0;
        keepPlay = true;
    }

    private void FixedUpdate()
    {
        if (keepPlay)
            score += Time.deltaTime;
    }
}
