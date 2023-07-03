using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : Collectible
{
    private enum FoodEffect {
        HealthGain,
        SpeedBoost,
        JumpBoost,
        AttackBoost
    }
    [Tooltip("Jenis efek")]
    [SerializeField] private FoodEffect effect;
    [Tooltip("Value yang ditambahin")]
    [SerializeField] private float effectValue;
    [Tooltip("Durasi boost, abaikan kalo HealthGain")]
    [SerializeField] private float effectDuration = 0f;

    protected override void CollectItem(Player player)
    {
        Debug.Log("nyam");
        switch (effect)
        {
            case FoodEffect.HealthGain:
                player.SetHealth(player.GetHealth() + (int)effectValue);
                Debug.Log("health gained");
                Destroy(gameObject);
                break;
            case FoodEffect.SpeedBoost:
                Debug.Log("Speed Boosted");
                StartCoroutine(BoostSpeed(player, effectValue, effectDuration));
                break;
            case FoodEffect.JumpBoost:
                Debug.Log("Jump Boosted");
                StartCoroutine(BoostJump(player, effectValue, effectDuration));
                break;
            case FoodEffect.AttackBoost:
                Debug.Log("Attack Boosted");
                StartCoroutine(BoostAttack(player, (int)effectValue, effectDuration));
                break;
            default:
                Debug.Log("ko ga masuk");
                break;
        }
    }

    IEnumerator BoostAttack(Player player, int boost, float duration)
    {
        player.AttackPower = player.AttackPower + boost;
        yield return new WaitForSeconds(duration);
        player.AttackPower = player.AttackPower - boost;
        Debug.Log("duration ran out");
        Destroy(gameObject);
    }

    IEnumerator BoostSpeed(Player player, float boost, float duration)
    {
        player.Speed = player.Speed + boost;
        yield return new WaitForSeconds(duration);
        player.Speed = player.Speed - boost;
        Debug.Log("duration ran out");
        Destroy(gameObject);
    }

    IEnumerator BoostJump(Player player, float boost, float duration)
    {
        player.JumpDistance = player.JumpDistance + boost;
        yield return new WaitForSeconds(duration);
        player.JumpDistance = player.JumpDistance - boost;
        Debug.Log("duration ran out");
        Destroy(gameObject);
    }
}
