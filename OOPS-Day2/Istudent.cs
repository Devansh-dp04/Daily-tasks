using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace OOPSDay2
{
    //implementing the add,update and removing operations    
        interface Istudent
        {
            void AddStudent(Student student);
            void UpdateMarks(int studentID, int newMarks);
            void DisplayAllStudents();
        } 
}
