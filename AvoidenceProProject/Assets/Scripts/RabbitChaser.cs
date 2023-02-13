using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitChaser : Kinematic
{
    FollowPath myMoveType;
    LookWhereGoing myRotateType;
    public PlayerController player;

    public GameObject[] myPath = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        myRotateType = new LookWhereGoing();
        myRotateType.character = this;
        myRotateType.target = myTarget;

        myMoveType = new FollowPath();
        myMoveType.character = this;
        //myMoveType.target = myTarget;
        myMoveType.path = myPath;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(player.gameStart == true)
        {
            steeringUpdate = new SteeringOutput();
            steeringUpdate.angular = myRotateType.getSteering().angular;
            steeringUpdate.linear = myMoveType.getSteering().linear;
            steeringUpdate.linear.y = 0;
            base.Update();
        }
    }
}
