using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {

        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            FillContests(contests);

            var studentsRanking = new SortedDictionary<string, Dictionary<string, int>>();
            AddStudentAndPointsToSudentsRanking(contests, studentsRanking);

            PrintBestCandidate(studentsRanking);
            Console.WriteLine("Ranking: ");
            PrintRanking(studentsRanking);
        }

        private static void PrintRanking(SortedDictionary<string, Dictionary<string, int>> studentsRanking)
        {
            foreach (var student in studentsRanking)
            {
                Console.WriteLine(student.Key);
                foreach (var exams in student.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {exams.Key} -> {exams.Value}");
                }
            }
        }

        private static void PrintBestCandidate(SortedDictionary<string, Dictionary<string, int>> studentsRanking)
        {
            var nameBestCandidate = "";
            var pointBestCandidate = 0;
            foreach (var student in studentsRanking)
            {
                var curentPoint = 0;
                foreach (var point in student.Value.Values)
                {
                    curentPoint += point;
                }

                if (curentPoint > pointBestCandidate)
                {
                    pointBestCandidate = curentPoint;
                    nameBestCandidate = student.Key;
                }
            }
            Console.WriteLine($"Best candidate is {nameBestCandidate} with total {pointBestCandidate} points.");
        }

        private static void AddStudentAndPointsToSudentsRanking(Dictionary<string, string> contests, SortedDictionary<string, Dictionary<string, int>> studentsRanking)
        {
            var inputExam = Console.ReadLine();

            while (inputExam != "end of submissions")
            {
                var inputExamArr = inputExam.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                var exam = inputExamArr[0];
                var passwordExam = inputExamArr[1];
                if (contests.ContainsKey(exam) && contests[exam] == passwordExam)
                {
                    var nameStudent = inputExamArr[2];
                    var grade = int.Parse(inputExamArr[3]);
                    if (!studentsRanking.ContainsKey(nameStudent))
                    {
                        studentsRanking.Add(nameStudent, new Dictionary<string, int>());
                    }
                    if (!studentsRanking[nameStudent].ContainsKey(exam))
                    {
                        studentsRanking[nameStudent].Add(exam, 0);
                    }
                    if (studentsRanking[nameStudent][exam] < grade)
                    {
                        studentsRanking[nameStudent][exam] = grade;
                    }
                }
                inputExam = Console.ReadLine();
            }
        }

        private static void FillContests(Dictionary<string, string> contests)
        {
            var inputContest = Console.ReadLine();

            while (inputContest != "end of contests")
            {
                var inputContestArr = inputContest.Split(':');
                contests.Add(inputContestArr[0], inputContestArr[1]);
                inputContest = Console.ReadLine();
            }
        }
    }
}
