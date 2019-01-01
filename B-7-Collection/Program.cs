using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_5
{
    class Program
    {
        static void Main(string[] args)
        {
            //ArrayListExample();
            //ArrayListPoemSort();
            //ArrayListOfSongsSort();
            //GenericListOfSongsSort();
            //GenericListOfNeighborSearch();
            DictionaryOfNeighborSearch();
            Console.ReadLine();
        }



        public static void ArrayListPoemSort()
        {
            
            var poem = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введите {i + 1} строку поэмы");
                poem.Add(Console.ReadLine());
            }

            poem.Sort();

            poem.RemoveAt(poem.Count - 1);

            object[] mass = poem.ToArray();

            Console.WriteLine("Отсортированный массив");
            foreach(var item in mass)
            Console.WriteLine(item);
        }

        public static void ArrayListOfSongsSort()
        {
            var poem = new ArrayList();

            for (int i = 0; i < 5; i++)
            {
                Song song = new Song();
                Console.WriteLine($"Введите {i + 1} строку поэмы");
                song.Lyrics = Console.ReadLine();
                poem.Add(song);
            }

            //poem.Sort();

            poem.RemoveAt(poem.Count - 1);

            object[] mass = poem.ToArray();

            Console.WriteLine("Массив");
            foreach(var item in mass)
            Console.WriteLine((item as Song).Lyrics);
        }

        public static void GenericListOfSongsSort()
        {
            var poem = new List<Song>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Введите {i + 1} строку поэмы");
                poem.Add(new Song() { Lyrics = Console.ReadLine() });
            }

            poem.Sort();
                            
            poem.RemoveAt(poem.Count - 1);

            Console.WriteLine("Отсортированный LIST<>");
            foreach (var item in poem)
                Console.WriteLine(item.Lyrics);
            //object[] mass = poem.ToArray();

            //Console.WriteLine("Отсортированный массив");
            //foreach (var item in mass)
            //    Console.WriteLine((item as Song).Lyrics);
        }
        public static void GenericListOfNeighborSearch()
        {
            var floorNeighbors = new List<Neighbor>();
            Random random = new Random();
            int flatNumber;
            int flag = 0;

            for(int i = 0; i < 50; i++)
            {
                //Neighbor neighbor = new Neighbor(); // это если надо вводить данные вручную
                //neighbor.FlatNumber = "1";
                //neighbor.FullName = "fsfaa";
                //floorNeighbors.Add(neighbor);
                if (i + 1  == 34) continue; // номер моей квартиры

                floorNeighbors.Add(new Neighbor
                {
                    FullName = $"FullName {i + random.Next(1, 100) }",
                    FlatNumber = i + 1,
                    PhoneNumber = $"+375 29 {random.Next(0000000, 9999999)}"
                });

            }
            while (flag == 0)
            {
                while (true)
                {
                    Console.WriteLine("Введите номер квартиры");
                    flatNumber = Convert.ToInt32(Console.ReadLine());
                    if (flatNumber == 0 || flatNumber < 0)
                        Console.WriteLine("Ошибка");
                    else break;
                }

                foreach (var item in floorNeighbors)
                {
                    if (item.FlatNumber == flatNumber)
                    {
                        Console.WriteLine($"Имя соседа {item.FullName} \nНомер телефона {item.PhoneNumber} ");
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0) Console.WriteLine("Такой квартиры не существует");
            }
        }

        public static void DictionaryOfNeighborSearch()
        {
            var floorNeighbors = new Dictionary<int, Neighbor>();

            Random random = new Random();
            int flatNumber;
            int flag = 0;

            for (int i = 0; i < 50; i++)
            {
                if (i + 1 == 34) continue; // номер моей квартиры

                Neighbor neighbor = new Neighbor
                {
                    FullName = $"FullName {i + random.Next(1, 100) }",
                    FlatNumber = i + 1,
                    PhoneNumber = $"+375 29 {random.Next(0000000, 9999999)}"
                };

                floorNeighbors.Add(neighbor.FlatNumber, neighbor);

            }
            while (flag == 0)
            {
                while (true)
                {
                    Console.WriteLine("Введите номер квартиры");
                    flatNumber = Convert.ToInt32(Console.ReadLine());
                    if (flatNumber == 0 || flatNumber < 0)
                        Console.WriteLine("Ошибка");
                    else break;
                }

                if (floorNeighbors.ContainsKey(flatNumber))
                {
                    Console.WriteLine($"Имя соседа {floorNeighbors[flatNumber].FullName} \nНомер телефона {floorNeighbors[flatNumber].PhoneNumber} ");
                    flag = 1;
                    break;
                }
                else
                {
                    Console.WriteLine("Такой квартиры не существует");
                    flag = 0;
                }
            }
        }

        public class Song: IComparable<Song>
        {
            public string Lyrics;

            public int CompareTo(Song comparePart)
            {
                if (comparePart == null)
                    return 1;

                else
                    return this.Lyrics.CompareTo(comparePart.Lyrics);
            }

        }
    }
}
