using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gravity : MonoBehaviour
{
    public static Gravity S;

    [SerializeField] [Min(0)] private float maxBonusCoolDown = 3f;
    private float bonusCoolDown;

    [SerializeField] [Min(0)] private float maxGravityCoolDown = 1f;
    private float gravityCoolDown;

    [SerializeField] private Image collDownBonusLine;
    [SerializeField] private Image collDowngravityLine;

    private bool bonusActivate;

    private void Awake()
    {
        if (S == null)
            S = this;

        bonusActivate = false;

        gravityCoolDown = maxGravityCoolDown;
        Physics2D.gravity = new Vector2(0, -9.8f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gravityCoolDown >= maxGravityCoolDown || bonusActivate)
            {
                Physics2D.gravity *= -1;
                gravityCoolDown = 0;
                Arrow.S.ShoingArrows();
            }
        }
    }

    private void FixedUpdate()
    {
        if (bonusActivate)
        {
            bonusCoolDown -= Time.deltaTime;
            CoolDownVisualisation(bonusCoolDown / maxBonusCoolDown, collDownBonusLine);
        }
        else if (gravityCoolDown < maxGravityCoolDown)
        {
            gravityCoolDown += Time.deltaTime;
            CoolDownVisualisation(gravityCoolDown / maxGravityCoolDown, collDowngravityLine);
        }
    }

    private void CoolDownVisualisation(float coolDown, Image line)
    {
        RectTransform lineTransform = line.GetComponent<RectTransform>();
        float scale = coolDown * 18;
        lineTransform.localScale = new Vector3(scale, 0.5f, 1);
    }

    public void ActivatingBonus()
    {
        bonusActivate = true;
        bonusCoolDown = maxBonusCoolDown;

        gravityCoolDown = maxGravityCoolDown;
        CoolDownVisualisation(1f, collDowngravityLine);

        StartCoroutine(DisablingDelayBonus(maxBonusCoolDown));
    }

    private IEnumerator DisablingDelayBonus(float delay)
    {
        yield return new WaitForSeconds(delay);
        bonusActivate = false;
        CoolDownVisualisation(0f, collDownBonusLine);
    }
}
