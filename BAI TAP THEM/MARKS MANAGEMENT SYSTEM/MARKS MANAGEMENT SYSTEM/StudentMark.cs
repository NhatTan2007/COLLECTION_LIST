using System;
using System.Collections.Generic;
using System.Text;

namespace MARKS_MANAGEMENT_SYSTEM
{
    class StudentMark : IStudentMark
    {
        private string _fullName;
        private int _id;
        private string _class;
        private int _semester;
        private float _averageMark = -1;
        private List<int> _subjectMarkList = new List<int>(5);
        private static int _countStudent = 0;

        public string FullName { get => _fullName; set => _fullName = value; }
        public int Id { get => _id; set => _id = value; }
        public string Class { get => _class; set => _class = value; }
        public int Semester { get => _semester; set => _semester = value; }
        public float AverageMark { get => _averageMark;}
        public List<int> SubjectMarkList { get => _subjectMarkList; set => _subjectMarkList = value; }

        public StudentMark()
        {
            _id = ++_countStudent;
        }
        public void AveCal()
        {
            int sumMark = 0;
            for (int i = 0; i < _subjectMarkList.Count; i++)
            {
                sumMark += _subjectMarkList[i];
            }
            _averageMark = sumMark / _subjectMarkList.Count;
        }

        public string Display()
        {
            if(_averageMark != -1)
            {
                return $"{_id}\t|\t{_fullName}\t\t\t\t|\t{_class}\t|\t{_semester}\t\t|\t{_averageMark}";
            } else
            {
                return $"{_id}\t|\t{_fullName}\t\t\t\t|\t{_class}\t|\t{_semester}\t\t|\tNot calculate yet";
            }
        }
    }
}
