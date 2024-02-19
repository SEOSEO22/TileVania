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
         * �÷��̾��� Capsule Collider�� Box Collider�� ���� Ʈ���� �Լ��� �� �� ȣ��Ǹ鼭
         * ������ �� ���� ������ ��찡 �����. ���� isPicked ������ ����� ���ھ �� ������
         * �������� �������־���.
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
