function Student(pid, pname, pcgpa) {
    this.id = pid
    this.name = pname
    this.cgpa = pcgpa
    this.getDetails = function () {
        return "Id: " + pid + " Name: " + pname + " Cgpa: " + pcgpa
    }
}
var s1 = new Student(101, "ABC", 5.5)
console.log(s1.getDetails())
console.log(s1);
var s2 = new Student(102, "DEF", 6.5)
console.log(s2.getDetails())
console.log(s2);