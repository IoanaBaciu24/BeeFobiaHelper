using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialDialogue : MonoBehaviour
{
    public Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

        sentences.Enqueue("Hey there! I've heard that you are afraid of bees.");
        sentences.Enqueue("My name is Bee-atrice, and I am here to help you out! All you have to do is to follow some steps.");
        sentences.Enqueue("At first, you can sit around and enjoy the view, get used to the nature surrounding you.");
        sentences.Enqueue("If I am in front of you and close enough, you can press E to pet me.");
        sentences.Enqueue("When you feel ready, you should start walking in the path that is surrounded by flowers.");
        sentences.Enqueue("The further you go, you will meet a few bees that are just minding their own business.");
        sentences.Enqueue(" Don't be afraid of them, they can't harm you, and they don't want to either.");
        sentences.Enqueue("Close to the end of the path, there is the hive. There are the most bees, naturally.");
        sentences.Enqueue("You can go closer and look around, as long as you feel ready to do this. ");
        sentences.Enqueue("At the end of the road, there should bee a small cabin, a great place when you want to live a little in the nature.");
        sentences.Enqueue("There will bee a poor bee that got lost and needs your help.");
        sentences.Enqueue("Are you going to bee brave enough to get close to it by the time you reach the cabin?");
        sentences.Enqueue("I will follow you everywhere you go, so if you want to just play around a little, turn to me and press E.");

        GetComponent<Text>().text = sentences.Dequeue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("x"))
        {
            if(sentences.Count == 0)
            {
                SceneManager.LoadScene("BeeScene");
            }
            GetComponent<Text>().text = sentences.Dequeue();
        }
    }
}
