using System;

namespace Hello
{
    public class Message
    {
        public string Date { get; set; }
        public int AmountMoney { get; set; }
        public string Operation { get; set; }

    }
    class Program
    {
        static Message[]? data;

        public static int GetAmountMoney(string userDate)
        {
            int sum = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (IsLateDate(userDate, data[i].Date))
                {
                    sum += DoOperaton(data[i], i);
                }
                else
                {
                    break;
                }
            }

            return sum;
        }

        public static bool IsLateDate(string userDate, string currentDate)
        {
            // Годы.
            if (int.Parse(userDate[..4]) == int.Parse(currentDate[..4]))
            {
                // Месяцы.
                if (int.Parse(userDate[5..7]) == int.Parse(currentDate[5..7]))
                {
                    // Дни.
                    if (int.Parse(userDate[8..10]) == int.Parse(currentDate[8..10]))
                    {
                        // Часы.
                        if (int.Parse(userDate[11..13]) == int.Parse(currentDate[11..13]))
                        {
                            // Минуты.
                            if (int.Parse(userDate[14..16]) == int.Parse(currentDate[14..16]))
                            {
                                return true;
                            }

                            else if (int.Parse(userDate[14..16]) > int.Parse(currentDate[14..16]))
                            {
                                return true;
                            }

                            else return false;
                        }

                        else if (int.Parse(userDate[11..13]) > int.Parse(currentDate[11..13]))
                        {
                            return true;
                        }

                        else return false;
                    }

                    else if (int.Parse(userDate[8..10]) > int.Parse(currentDate[8..10]))
                    {
                        return true;
                    }

                    else return false;
                }

                else if (int.Parse(userDate[5..7]) > int.Parse(currentDate[5..7]))
                {
                    return true;
                }

                else return false;
            }

            else if (int.Parse(userDate[..4]) > int.Parse(currentDate[..4]))
            {
                return true;
            }

            else return false;
        }

        public static int DoOperaton(Message message, int indexCurrentLine)
        {
            if (message.Operation == "in")
            {
                return message.AmountMoney;
            }
            else if (message.Operation == "out")
            {
                return -message.AmountMoney;
            }
            else
            {
                if (data[indexCurrentLine - 1].Operation == "in")
                {
                    return -data[indexCurrentLine - 1].AmountMoney;
                }
                else
                {
                    return data[indexCurrentLine - 1].AmountMoney;
                }
            }
        }

        public static void Main()
        {
            var lines = File.ReadAllLines("выписка.txt");

            data = new Message[lines.Length];

            // Заполнение массива данными.
            data[0] = new Message { Date = "0000-00-00 00:00", AmountMoney = int.Parse(lines[0]), Operation = "in" };
            for (int i = 1; i < lines.Length; i++)
            {
                data[i] = new Message();

                data[i].Date = lines[i].Split(" | ")[0];

                if (lines[i].Split(" | ").Length > 2)
                {
                    data[i].AmountMoney = int.Parse(lines[i].Split(" | ")[1]);
                    data[i].Operation = lines[i].Split(" | ")[2];
                }
                else
                {
                    data[i].AmountMoney = 0;
                    data[i].Operation = "revert";
                }
            }

            if (GetAmountMoney(lines[lines.Length - 1].Split(" | ")[0]) >= 0)
                Console.WriteLine("Данные верны.");
            else
                Console.WriteLine("Данные не верны.");

            Console.WriteLine("Введите дату в формате XXXX.XX.XX XX:XX");
            string userInput = Console.ReadLine();

            if (userInput.Length > 0)
            {
                Console.WriteLine(GetAmountMoney(userInput));
            }
        }
    }
}