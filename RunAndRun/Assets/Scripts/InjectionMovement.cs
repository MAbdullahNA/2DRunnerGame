using UnityEngine;

public class InjectionMovement : MonoBehaviour
{
    void Update()
    {
        var step =  2*Time.timeScale * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, GameManger.instance.endPosition.transform.position, step);
        if(transform.position==GameManger.instance.endPosition.transform.position)
        {
            GameManger.instance.InstantiateInjection();
            switch (GameManger.instance.score)
            {
                case >=1800:
                {
                    Time.timeScale=2f;
                    GameManger.instance.speed=60;
                    break;
                }
                case >=1200:
                {
                    Time.timeScale=1.8f;
                    GameManger.instance.speed=45;
                    break;
                }
                case >=900:
                {
                    Time.timeScale=1.6f;
                    GameManger.instance.speed=40;
                    break;
                }
                case >=500:
                {
                    Time.timeScale=1.4f;
                    GameManger.instance.speed=35;
                    break;
                }
                case >=200:
                {
                    Time.timeScale=1.2f;
                    GameManger.instance.speed=30;
                    break;
                }
            }
            Destroy(this.gameObject);
        }
    }
}
