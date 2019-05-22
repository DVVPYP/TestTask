using System;
using System.Data.SqlClient;
using System.Data;

namespace Test1
{
    class Books
    {
        static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data.mdf;Integrated Security=True");
        static SqlCommand com;

        public Books()
        {

        }

        public void Create()
        {
            Console.Clear();
            con.Open();
            com = new SqlCommand("Insert into books ([Название книги],[Год]) values (@nam,@year)", con);
            Console.Write("Название книги: ");
            string name= Console.ReadLine();
            while (name.Length > 30)
            {
                Console.WriteLine("Название содержит более 30 символов повторите попытку: ");
                name = Console.ReadLine();
            }
            com.Parameters.Add("@nam", SqlDbType.NVarChar).Value = name;
            Console.Write("Год: ");
            com.Parameters.Add("@year", SqlDbType.NVarChar).Value = Console.ReadLine();
            com.ExecuteNonQuery();
            con.Close();
            con.Open();
            com = new SqlCommand("select [id] from books where [Название книги]=@nam", con);
            com.Parameters.Add("@nam", SqlDbType.NVarChar).Value = name;
            dynamic id = com.ExecuteScalar();
            con.Close();
            con.Open();
            com = new SqlCommand("Insert into [avtor] ([Автор],[idb]) values (@name,@idb)", con);
            Console.Write("Автор: ");
            string av = "";
            av = Console.ReadLine();
            while (av.Length>20)
            {
                Console.WriteLine("Имя содержит более 20 символов повторите попытку: ");
                av = Console.ReadLine();
            }
            com.Parameters.Add("@name", SqlDbType.NVarChar).Value = av;
            com.Parameters.Add("@idb", SqlDbType.NVarChar).Value = id;
            com.ExecuteNonQuery();
            Console.WriteLine("Добавить еще автора?\n 1.yes\n 2.no");
            while (Console.ReadLine() == "1")
            {
                Console.Clear();
                com = new SqlCommand("Insert into avtor ([Автор],[idb]) values (@name,@idb)", con);
                Console.Write("Автор: ");
                av = Console.ReadLine();
                while (av.Length > 20)
                {
                    Console.WriteLine("Имя содержит более 20 символов повторите попытку: ");
                    av = Console.ReadLine();
                }
                com.Parameters.Add("@name", SqlDbType.NVarChar).Value = av;
                com.Parameters.Add("@idb", SqlDbType.NVarChar).Value = id;
                com.ExecuteNonQuery();
                Console.WriteLine("Добавить еще автора?\n 1.yes\n 2.no");
            }                 
            con.Close();
            
        }

        public void Autor()
        {
            Console.Clear();
            con.Open();
            com = new SqlCommand("select [Id],[Автор] from avtor", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Console.WriteLine(String.Format("{0}. {1}", read[0],read[1]));
            }
            con.Close();
        }

        public void Book()
        {
            Console.Clear();
            con.Open();
            com = new SqlCommand("select [Id],[Название книги] from books", con);
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Console.WriteLine(String.Format("{0}. {1}", read[0],read[1]));
            }
            con.Close();
        }

        public void Select()
        {
            Console.Clear();
            con.Open();
            Console.Write("Введите номер книги для поиска её авторов: ");
            com = new SqlCommand("select [Id],[Автор] from avtor where [idb]=@id", con);
            com.Parameters.Add("@id", SqlDbType.NVarChar).Value = Console.ReadLine();
            SqlDataReader read = com.ExecuteReader();
            while (read.Read())
            {
                Console.WriteLine(String.Format("{0}. {1}", read[0],read[1]));
            }
            con.Close();
        }

        public void Delete()
        {
            Console.Clear();
            con.Open();
            com = new SqlCommand("delete from books where [Id]=@id", con);
            Console.Write("Введите номер книги для удаления: ");
            com.Parameters.Add("@id", SqlDbType.NVarChar).Value = Console.ReadLine();
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
