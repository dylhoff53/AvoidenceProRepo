using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wade : Kinematic
{
    Wander myMoveType;
    Face mySeekRotateType;
    LookWhereGoing myFleeRotateType;
    public PlayerController player;

    public bool flee = false;

    // Start is called before the first frame update
    void Start()
    {
        myMoveType = new Wander();
        myMoveType.character = this;
        myMoveType.target = myTarget;
        myMoveType.flee = flee;

        mySeekRotateType = new Face();
        mySeekRotateType.character = this;
        mySeekRotateType.target = myTarget;

        myFleeRotateType = new LookWhereGoing();
        myFleeRotateType.character = this;
        myFleeRotateType.target = myTarget;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(player.gameStart == true)
        {
            steeringUpdate = new SteeringOutput();
            steeringUpdate.linear = myMoveType.getSteering().linear;
            steeringUpdate.angular = flee ? myFleeRotateType.getSteering().angular : mySeekRotateType.getSteering().angular;
            steeringUpdate.linear.y = 0;
            base.Update();
        }
    }

}
