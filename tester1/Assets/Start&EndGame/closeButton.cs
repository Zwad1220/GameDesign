using UnityEngine;

public class closeButton : MonoBehaviour
{
   public PlayerMove playerMove;
public void oncloseButton()
    {
        gameObject.SetActive(false);
        playerMove.canMove = true;
    }
}
