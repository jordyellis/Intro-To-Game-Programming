using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{
    //VOLLEGR NOW IN CLSSS MW

    //GLOBAL VARIABLES
    Vector3 dir = Vector3.right; //decare default movement direction
                                 //Remember the difference b/w Vector2(x,y) & Vector3(x,y,z)
                                 //there is shorthand for Vector2/3 directions.
                                 //In this one, Vector3.right = Vector3(1,0,0), moving it to the RIGHT
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject tailPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //OPTION: Randomize the direction of the snake like our Pong Ball when it starts
        //Call MoveSnake() every 300ms(0.3 seconds) to move the snake
        InvokeRepeating("MoveSnake", 0.3f, 0.3f);
        //InvokeRepeating("methodName", time, repeatRate)
        //methodName: name of method/function to invoke
        //time: start invoking after n seconds
        //repeatRate: repeat after every n seconds.
    }

    // Update is called once per frame
    void Update()
    {
        //NOTE: if we did movement in update, it would go SUPER FAST, so let's call it on a delay in Start()

        //Change the Snake's direction by calling ChangeDirection(), detecting key presses all the time
        ChangeDirection(); 
    }

    void MoveSnake()
    {
        Vector3 gap = transform.position;

        //In Snake, the snake is ALWAYS moving in some direction, never standing still.
        //MOVE SNAKE HEAD IN A DIRECTION
        transform.Translate(dir);
        //Translate moves the transform property in the direction and distance of the translation,
        //In this case, we are moving in the whatever direction we've set the dir variable to be the distance of that variable

        if(ate)
        {
            Debug.Log("Ate =" + ate);

            GameObject tailSec = (GameObject)Instantiate(tailPrefab, gap, Quaternion.identity);
            tail.Insert(0, tailSec.transform);

            ate = false;
        }
        //check if snake has tail
        else if (tail.Count > 0)
        {
            //move last tail to where head was previously was
            tail.Last().position = gap;

            //keep tail list in order
            //add last element tail to the front of the list and remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void ChangeDirection()
    {
        if(Input.GetKey(KeyCode.RightArrow)) //if the Right Arrow is continuously pressed down, then...
        {
            dir = Vector3.right; //change the direction to RIGHT
            //Debug.Log("direction = right"); //print to console
        }//MOVE LEFT
        else if (Input.GetKey(KeyCode.LeftArrow)) //if the Left Arrow is continuously pressed down, then...
        {
            dir = Vector3.left; //change the direction to LEFT
                                //NOTE: this could also be written as dir = - Vector3.right, "-right" = left
                                //Debug.Log("direction = left"); //print to console
        }//MOVE UP
        else if (Input.GetKey(KeyCode.UpArrow)) //if the Up Arrow is continuously pressed down, then...
        {
            dir = Vector3.up; //change the direction to UP
            //Debug.Log("direction = up"); //print to console
        }//MOVE DOWN
        else if (Input.GetKey(KeyCode.DownArrow)) //if the Down Arrow is continuously pressed down, then...
        {
            dir = Vector3.down; //change the direction to DOWN
            //Debug.Log("direction = down"); //print to console
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //When Snake collides with Food...
        if (collision.gameObject.tag == "Food")
        {
            ate = true;
            //Debug.Log("food eaten");
            Destroy(collision.gameObject); //Remove the Food

        }
    }
}