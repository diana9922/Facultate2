using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Facultate2.Data;

namespace Facultate2.Models
{
    public class StudentSpecializariPageModel : PageModel
    {
        public List<AssignedSpecializareData> AssignedSpecializareDataList;
        public void PopulateAssignedSpecializareData(Facultate2Context context, Student student)
        {
            var allSpecializari = context.Specializare;
            var studentSpecializari = new HashSet<int>(
            student.StudentSpecializari.Select(c => c.StudentID));
            AssignedSpecializareDataList = new List<AssignedSpecializareData>();
            foreach (var cat in allSpecializari)
            {
                AssignedSpecializareDataList.Add(new AssignedSpecializareData
                {
                    SpecializareID = cat.ID,
                    Nume = cat.SpecializareNume,
                    Assigned = studentSpecializari.Contains(cat.ID)
                });
            }
        }

        public void UpdateStudentSpecializari(Facultate2Context context, string[] selectedSpecializari, Student studentToUpdate)
        {
            if (selectedSpecializari == null)
            {
                studentToUpdate.StudentSpecializari = new List<StudentSpecializare>();
                return;
            }

            var selectedSpecializariHS = new HashSet<string>(selectedSpecializari);
            var studentSpecializari = new HashSet<int>
            (studentToUpdate.StudentSpecializari.Select(c => c.Specializare.ID));
            foreach (var cat in context.Specializare)
            {
                if (selectedSpecializariHS.Contains(cat.ID.ToString()))
                {
                    if (!studentSpecializari.Contains(cat.ID))
                    {
                        studentToUpdate.StudentSpecializari.Add(
                         new StudentSpecializare
                         {
                             StudentID = studentToUpdate.ID,
                             SpecializareID = cat.ID
                         });
                    }
                }
                else
                {
                    if (studentSpecializari.Contains(cat.ID))
                        {
                        StudentSpecializare courseToRemove
                         = studentToUpdate
                         .StudentSpecializari
                         .SingleOrDefault(i => i.SpecializareID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}