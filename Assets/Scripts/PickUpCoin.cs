using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    [SerializeField] AudioClip coinSFX;
    bool isPicked = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /* 
         * 플레이어의 Capsule Collider와 Box Collider로 인해 트리거 함수가 두 번 호출되면서
         * 점수가 두 번씩 오르는 경우가 생긴다. 따라서 isPicked 변수를 사용해 스코어가 한 번씩만
         * 오르도록 설정해주었다.
        */
        if (isPicked) return;

        isPicked = true;
        AudioSource.PlayClipAtPoint(coinSFX, Camera.main.transform.position);

        switch (this.tag)
        {
            case "Gold Coin":
                FindObjectOfType<GameSession>().AddScore(2000);
                break;
            case "Silver Coin":
                FindObjectOfType<GameSession>().AddScore(1000);
                break;
            case "Bronze Coin":
                FindObjectOfType<GameSession>().AddScore(500);
                break;
        }

        Destroy(gameObject);
    }
}
