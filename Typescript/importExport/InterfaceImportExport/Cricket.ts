import {Coach} from "./Coach";

export class Cricket implements Coach{
    public getDailyWorkout():string{
        return "Cricket practise";
    }
}