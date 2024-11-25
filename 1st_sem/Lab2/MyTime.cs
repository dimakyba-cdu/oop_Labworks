// namespace Lab2
// {
//   public class MyTime
//   {
//     public int hour, minute, second;

//     public MyTime(int h, int m, int s)
//     {
//       hour = h;
//       minute = m;
//       second = s;
//     }

//     public MyTime(string time)
//     {
//       string[] parts = time.Split(':');
//       hour = int.Parse(parts[0]);
//       minute = int.Parse(parts[1]);
//       second = int.Parse(parts[2]);
//     }

//     public override string ToString()
//     {
//       return $"{hour:D2}:{minute:D2}:{second:D2}";
//     }

//     public int ToSecSinceMidnight()
//     {
//       return hour * 3600 + minute * 60 + second;
//     }

//     public static MyTime FromSecSinceMidnight(int t)
//     {
//       const int secPerDay = 60 * 60 * 24;
//       t %= secPerDay;

//       if (t < 0)
//         t += secPerDay;
//       int h = t / 3600;
//       int m = t / 60 % 60;
//       int s = t % 60;
//       return new MyTime(h, m, s);
//     }

//     public MyTime AddOneSecond()
//     {
//       return AddSeconds(1);
//     }

//     public MyTime AddOneMinute()
//     {
//       return AddMinutes(1);
//     }

//     public MyTime AddOneHour()
//     {
//       return AddHours(1);
//     }

//     public MyTime AddSeconds(int s)
//     {
//       const int secondsInDay = 24 * 60 * 60;
//       int totalSeconds = hour * 3600 + minute * 60 + second;
//       totalSeconds += s;

//       totalSeconds = totalSeconds % secondsInDay;

//       if (totalSeconds < 0)
//       {
//         totalSeconds = secondsInDay + totalSeconds;
//       }
//       int newHour = totalSeconds / 3600;
//       int newMinute = totalSeconds % 3600 / 60;
//       int newSecond = totalSeconds % 60;

//       return new MyTime(newHour, newMinute, newSecond);
//     }

//     public MyTime AddMinutes(int m)
//     {
//       return AddSeconds(m * 60);
//     }

//     public MyTime AddHours(int h)
//     {
//       return AddSeconds(h * 3600);
//     }

//     public static int Difference(MyTime t1, MyTime t2)
//     {
//       int totalSeconds1 = t1.hour * 3600 + t1.minute * 60 + t1.second;
//       int totalSeconds2 = t2.hour * 3600 + t2.minute * 60 + t2.second;

//       int difference = totalSeconds1 - totalSeconds2;

//       return difference;
//     }

//     public static bool IsInRange(MyTime start, MyTime finish, MyTime t)
//     {
//       int startSec = ToSecSinceMidnight(start);
//       int finishSec = ToSecSinceMidnight(finish);
//       int currentSec = ToSecSinceMidnight(t);
//       if (finishSec < startSec)
//       {
//         startSec -= 24 * 60 * 60;
//       }

//       return currentSec >= startSec && currentSec < finishSec;

//     }

//     public static string WhatLesson(MyTime mt)
//     {
//       MyTime[] lessonsStart = {
//         new MyTime(8, 0, 0),
//         new MyTime(9, 40, 0),
//         new MyTime(11, 20, 0),
//         new MyTime(13, 0, 0),
//         new MyTime(14, 40, 0),
//         new MyTime(16, 10, 0)
//     };

//       MyTime[] lessonsEnd = {
//         new MyTime(9, 20, 0),
//         new MyTime(11, 0, 0),
//         new MyTime(12, 40, 0),
//         new MyTime(14, 20, 0),
//         new MyTime(16, 0, 0),
//         new MyTime(17, 30, 0)
//     };

//       if (Difference(mt, lessonsStart[0]) < 0)
//       {
//         return "пари ще не почались";
//       }

//       if (IsInRange(lessonsStart[0], lessonsEnd[0], mt))
//       {
//         return "1-а пара";
//       }

//       for (int i = 1; i < lessonsStart.Length; i++)
//       {
//         if (IsInRange(lessonsStart[i], lessonsEnd[i], mt))
//         {
//           return $"{i + 1}-а пара";
//         }

//         if (IsInRange(lessonsEnd[i - 1], lessonsStart[i], mt))
//         {
//           return $"перерва між {i}-ою та {i + 1}-ою парами";
//         }
//       }

//       return "пари вже кінчилися";
//     }
//   }
// }
