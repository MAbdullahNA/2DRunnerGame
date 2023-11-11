using UnityEngine;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public float score=0;
    public float speed=25;
    public Animator playerAnim;
    public GameObject tapToPlay;
    public GameObject gameEndPanel;
    public Text scoreText;
    public Material background;
    private float offsetValue=0;
    public Transform startPosition;
    public GameObject endPosition;
    public Transform injectionParent;
    public GameObject[] injections;
    [HideInInspector] public GameObject injection;
    public static GameManger instance;
    public bool gameStart=false;

    private void Start() {
        if(instance==null)
        {
            instance=this;
        }
        tapToPlay.SetActive(true);
    }
    void Update()
    {
        if(gameStart)
        {
            score+=(speed*Time.deltaTime);
            int scr=(int)score;
            scoreText.text=scr.ToString();
            offsetValue+=(Time.timeScale*Time.deltaTime);
            background.SetTextureOffset("_MainTex",new Vector2(offsetValue,0));
        }
    }
    public void PlayAgain()
    {
        gameEndPanel.SetActive(false);
        tapToPlay.SetActive(true);
    }
    public void TapToPlay()
    {
        score=0;
        tapToPlay.SetActive(false);
        Time.timeScale=1;
        InstantiateInjection();
        GameManger.instance.gameStart=true;
    }
    public void InstantiateInjection()
    {
        int num = Random.Range(0,4);
        Debug.Log("Speed = "+GameManger.instance.speed);
        Debug.Log(Time.timeScale);
        injection=Instantiate(injections[num],startPosition.position,Quaternion.identity,injectionParent);
    }
}
