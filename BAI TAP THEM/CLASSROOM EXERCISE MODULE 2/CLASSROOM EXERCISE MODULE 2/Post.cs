using System;
using System.Collections.Generic;
using System.Text;

namespace CLASSROOM_EXERCISE_MODULE_2
{
    class Post : IPost
    {
        private int _id;
        private string _title;
        private string _content;
        private string _author;
        private double _averageRate;
        private int[] _rates = new int[0];
        private static int ID = 0;

        public int Id { get => _id; set => _id = value; }
        public string Title { get => _title; set => _title = value; }
        public string Content { get => _content; set => _content = value; }
        public string Author { get => _author; set => _author = value; }
        public double AverageRate { get => _averageRate;}
        public int[] Rates { get => _rates; set => _rates = value; }
        public int RateCount { get => _rates.Length; }

        public Post()
        {
            _id = ++ID;
        }
        public Post(string title, string content, string author)
        {
            _title = title;
            _content = content;
            _author = author;
            _id = ++ID;
        }

        public string Display()
        {
            CalculateRate();
            return $"ID: {_id}\n" +
                $"Title: {_title}\n" +
                $"Content: {_content}\n" +
                $"Author: {_author}\n" +
                $"Count Rate: {RateCount}\n" +
                $"Average Rate: {_averageRate}\n";
        }

        public void CalculateRate()
        {
            if (RateCount != 0)
            {
                int sumRates = 0;
                foreach (var rate in _rates)
                {
                    sumRates += rate;
                }
                _averageRate = (double)(sumRates / RateCount);
            }
        }

        public void AddRate(int rate)
        {
            Array.Resize(ref _rates, RateCount + 1);
            _rates[RateCount - 1] = rate;
        }
    }
}
