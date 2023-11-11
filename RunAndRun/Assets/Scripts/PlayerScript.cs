using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    private bool isGrounded=true;
    private void Start() {
        rb=gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="injection")
        {
            GameManger.instance.gameStart=false;
            GameManger.instance.gameEndPanel.SetActive(true);
            Destroy(GameManger.instance.injection);
            Time.timeScale=0;
        }
        if(other.gameObject.tag=="ground")
        {
            isGrounded=true;
        }
    }
    private void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            if(isGrounded&&GameManger.instance.gameStart)
            {
                rb.AddForce(new Vector2(rb.velocity.x,jumpForce));
            }
        }
    }
}