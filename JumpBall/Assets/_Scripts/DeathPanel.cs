using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    public static DeathPanel S;

    [SerializeField] private GameObject deathPanel;
    [SerializeField] private Text congratulations;
    [SerializeField] private Text topScore;

    private Animation thisAnimation;

    private void Awake()
    {
        thisAnimation = GetComponent<Animation>();

        if (S == null) S = this;
    }

    public void Death()
    {
        deathPanel.SetActive(true);
        thisAnimation.Play("Appearance");
        Score.S.keepPlay = false;

        StartCoroutine(smoothScore());

        if (Score.S.score > PlayerPrefs.GetFloat("topScore", 0))
            PlayerPrefs.SetFloat("topScore", Score.S.score);

        topScore.text = "TOP SCORE: " + Mathf.RoundToInt(PlayerPrefs.GetFloat("topScore"));
    }

    private IEnumerator smoothScore()
    {
        int score = 0;
        while (score < Mathf.RoundToInt(Score.S.score))
        {
            congratulations.text = "GREAT!\n YOUR SCRE: " + score;
            score++;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
