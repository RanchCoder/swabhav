using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace College_App.model
{
    class CollegeSpecification
    {
        private string nameOfCollege;
        private string cityOfCollege;
        private string stateOfCollege;
        private string locationOfCollege;
        private int postalCodeOfCollege;
        private bool collegeHasLibrary;
        private bool collegeHasPlayground;
        private bool collegeHasGymkhana;
        private bool collegeHasCanteen;
        private bool collegeHasComputerLab;
        private bool collegeHasPhysicsLab;
        private bool collegeHasChemistryLab;

       

        public CollegeSpecification(string nameOfCollege, string cityOfCollege, string stateOfCollege, 
                                    string locationOfCollege, int postalCodeOfCollege, bool collegeHasLibrary,
                                    bool collegeHasPlayground, bool collegeHasGymkhana, bool collegeHasCanteen,
                                    bool collegeHasComputerLab, bool collegeHasPhysicsLab, bool collegeHasChemistryLab)
        {
            this.nameOfCollege = nameOfCollege;
            this.cityOfCollege = cityOfCollege;
            this.stateOfCollege = stateOfCollege;
            this.locationOfCollege = locationOfCollege;
            this.postalCodeOfCollege = postalCodeOfCollege;
            this.collegeHasLibrary = collegeHasLibrary;
            this.collegeHasPlayground = collegeHasPlayground;
            this.collegeHasGymkhana = collegeHasGymkhana;
            this.collegeHasCanteen = collegeHasCanteen;
            this.collegeHasComputerLab = collegeHasComputerLab;
            this.collegeHasPhysicsLab = collegeHasPhysicsLab;
            this.collegeHasChemistryLab = collegeHasChemistryLab;
        }

        public string NameOfCollege { get => nameOfCollege; set => nameOfCollege = value; }
        public string CityOfCollege { get => cityOfCollege; set => cityOfCollege = value; }
        public string StateOfCollege { get => stateOfCollege; set => stateOfCollege = value; }
        public string LocationOfCollege { get => locationOfCollege; set => locationOfCollege = value; }
        public int PostalCodeOfCollege { get => postalCodeOfCollege; set => postalCodeOfCollege = value; }
        public bool CollegeHasLibrary { get => collegeHasLibrary; set => collegeHasLibrary = value; }
        public bool CollegeHasPlayground { get => collegeHasPlayground; set => collegeHasPlayground = value; }
        public bool CollegeHasGymkhana { get => collegeHasGymkhana; set => collegeHasGymkhana = value; }
        public bool CollegeHasCanteen { get => collegeHasCanteen; set => collegeHasCanteen = value; }
        public bool CollegeHasComputerLab { get => collegeHasComputerLab; set => collegeHasComputerLab = value; }
        public bool CollegeHasPhysicsLab { get => collegeHasPhysicsLab; set => collegeHasPhysicsLab = value; }
        public bool CollegeHasChemistryLab { get => collegeHasChemistryLab; set => collegeHasChemistryLab = value; }
    }
}
