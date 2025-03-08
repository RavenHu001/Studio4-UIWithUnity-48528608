using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CoinCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI current;
    [SerializeField] private TextMeshProUGUI toUpdate;
    [SerializeField] private Transform coinTextContainer;
    [SerializeField] private float duration;
    [SerializeField] private Ease animationCurve;

    private float containerInitPosition;
    private float moveAmount;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        current.SetText("0");
        toUpdate.SetText("0");
        containerInitPosition = coinTextContainer.localPosition.y;
        moveAmount = current.rectTransform.rect.height;
    }

    public void UpdateScore(int score) 
    {
        //set Score to marked text UI
        toUpdate.SetText($"{score}");
        //trigger local move animation
        //coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount,duration);
        coinTextContainer.DOLocalMoveY(containerInitPosition + moveAmount, duration).SetEase(animationCurve);
        StartCoroutine(ResetCoinContainer(score));
    }

    private IEnumerator ResetCoinContainer(int score) 
    { 
        //let editor waite for given time
        yield return new WaitForSeconds(duration);
        current.SetText($"{score}");//update the original score
        Vector3 localPosition = coinTextContainer.localPosition;//get the position of text to rest
        coinTextContainer.localPosition = new Vector3(localPosition.x, containerInitPosition, localPosition.y);//reset the y position of coinTextContainer
    }
}
