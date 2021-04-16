import {Coach} from "./Coach";

export class Football implements Coach{
    public getDailyWorkout():string{
        return "Cricket practise";
    }
}