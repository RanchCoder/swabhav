import {Coach} from "./Coach";
import {Cricket} from "./Cricket";
import {Football} from "./Football";

let cricketCoach = new Cricket();
let footballCoach = new Football();
let coachArray : Coach[] = [];
coachArray.push(cricketCoach);
coachArray.push(footballCoach);

coachArray.forEach(item=>console.log(item.getDailyWorkout()));
