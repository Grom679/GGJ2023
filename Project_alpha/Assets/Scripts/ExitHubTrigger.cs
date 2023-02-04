using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHubTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManage.Instance.OnChangeScene(2);
        }
    }
}
