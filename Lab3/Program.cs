using System;
using System.Data.Common;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Security;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вы можете ввести:\n1, чтобы увидеть информацию о клиентах\n2, чтобы увидеть информацию о заказах\n3, чтобы увидеть информацию о материалах\n4, чтобы увидеть информацию о поставщиках\n0, чтобы завершить программу");
            string userInput = Console.ReadLine();

            MySqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                Console.WriteLine("Открытие соединения ...");
                conn.Open();
                Console.WriteLine("Соединение установлено!");

                while (userInput != "0")
                {
                    if (userInput == "1")
                    {
                        ClientInformation(conn);
                    }
                    else if (userInput == "2")
                    {
                        ClientOrder(conn);
                    }
                    else if (userInput == "3")
                    {
                        MaterialsInformation(conn);
                    }
                    else if (userInput == "4")
                    {
                        ProducerInformation(conn);
                    }
                    else
                    {
                        Console.WriteLine("Неправильный ввод.");
                    }

                    Console.WriteLine("Введите число от 1 до 4, чтобы продолжить или 0, чтобы завершить программу:");
                    userInput = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

            Console.WriteLine("Программа завершена.");
            Console.Read();
        }

        private static void ClientInformation(MySqlConnection conn)
        {
            string id, name, address, phone;
            string sql = "Select client_id, client_name, address, phone_number from client";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["client_id"].ToString();
                        name = reader["client_name"].ToString();
                        address = reader["address"].ToString();
                        phone = reader["phone_number"].ToString();
                        Console.WriteLine("........................................");
                        Console.WriteLine("Код:" + id + "\nИмя:" + name + "\nАдрес:" + address + "\nТелефон:" + phone);
                        Console.WriteLine("........................................");
                    }
                }
            }
        }

        private static void ClientOrder(MySqlConnection conn)
        {
            string client_id, order_id, date;
            string sql = "Select client_id, client_order_id, order_date from client_order";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        client_id = reader["client_id"].ToString();
                        order_id = reader["client_order_id"].ToString();
                        date = reader["order_date"].ToString();
                        Console.WriteLine("........................................");
                        Console.WriteLine("Код клиента:" + client_id + "\nКод заказа:" + order_id + "\nДата заказа:" + date);
                        Console.WriteLine("........................................");
                    }
                }
            }
        }
        private static void MaterialsInformation(MySqlConnection conn)
        {
            string id, name, cost, pr_id, m_batch, exp_date;
            string sql = "Select material_id, material_name, producer_id, unit_cost, minimum_batch, expiration_date from materials";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["material_id"].ToString();
                        name = reader["material_name"].ToString();
                        pr_id = reader["producer_id"].ToString();
                        cost = reader["unit_cost"].ToString();
                        m_batch = reader["minimum_batch"].ToString();
                        exp_date = reader["expiration_date"].ToString();
                        Console.WriteLine("........................................");
                        Console.WriteLine("Код материала: " + id + "\nНазвание материала: " + name + "\nКод поставщика: " + pr_id + "\nЦена за единицу материала: " + cost + "\nMинимальный размер партии: " + m_batch + "\nСрок годности: " + exp_date);
                        Console.WriteLine("........................................");
                    }
                }
            }
        }
        private static void ProducerInformation(MySqlConnection conn)
        {
            string id, name, address, phone, head;
            string sql = "Select producer_id, producer_name, address, phone_number, last_name_HEAD from producer";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader["producer_id"].ToString();
                        name = reader["producer_name"].ToString();
                        address = reader["address"].ToString();
                        phone = reader["phone_number"].ToString();
                        head = reader["last_name_HEAD"].ToString();
                        
                        Console.WriteLine("........................................");
                        Console.WriteLine("Код поставщика: " + id + "\nНазвание поставщика: " + name + "\nАдрес: " + address + "\nТелефон: " + phone + "\nПредставитель: " + head);
                        Console.WriteLine("........................................");
                    }
                }
            }
        }
    }
}
