using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image damageOverlay;
    public float maxAlpha = 0.6f;

    // call this from PlayerHealth
    public void UpdateDamageOverlay(int current, int max)
    {
        float t = (float)current / max;   // 1 = healthy, 0 = dead
        float alpha = Mathf.Lerp(maxAlpha, 0f, t);

        var c = damageOverlay.color;
        c.a = alpha;
        damageOverlay.color = c;
    }
}
