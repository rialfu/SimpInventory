using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.IO;

namespace inven
{
    
    public class Koneksi
    {
        public MySqlConnection kon;
        public Koneksi()
        {
            this.kon = new MySqlConnection(String.Format("server={0};user id={1};password={2};database=inventory", "localhost", "root", ""));
        }
        public MySqlDataReader user()
        {
            
            MySqlCommand command = new MySqlCommand("select*from users", this.kon);
            this.kon.Open();
            
            MySqlDataReader data = command.ExecuteReader();
            return data;
            
        }
        public MySqlDataReader daftar_barang()
        { 
            MySqlCommand command = new MySqlCommand(" select barang.id as id, nama, ifnull(sum(case when masuk=0 then riwayat.jumlah*-1 else riwayat.jumlah end),0) as jumlah from barang left join riwayat on barang.id=riwayat.barang_id group by barang.id", this.kon);
            //MySqlCommand command = new MySqlCommand("select bar.nama as nama, bar.jumlah as jumlah,users.username as user from barang as bar inner join users on bar.user_id=users.id", this.kon);
            //select nama, sum(case when masuk = 0 then riwayat.jumlah * -1 else riwayat.jumlah end) as jumlah,users.username from riwayat inner join barang on barang.id = riwayat.barang_id inner join users on users.id = barang.user_id group by barang_id
            this.kon.Open();
            MySqlDataReader data = command.ExecuteReader();
            return data;

        }
        
        public MySqlDataReader riwayat_barang()
        {
            MySqlCommand command = new MySqlCommand("select nama, username, " +
                "case when masuk=0 then riwayat.jumlah*-1 else riwayat.jumlah end as jumlah, " +
                "tanggal from riwayat " +
                "inner join barang on barang.id=riwayat.barang_id inner join users on users.id=riwayat.user_id order by tanggal desc", this.kon);
            this.kon.Open();
            MySqlDataReader data = command.ExecuteReader();
            return data;
        }
        public String[] login(string user, string password)
        {
            String[] val = new String[2];
            try
            {
                String query = String.Format("select * from users where username='{0}' and password='{1}'", MySqlHelper.EscapeString(user), MySqlHelper.EscapeString(password));
                //String query = String.Format("select * from users where username='{0}' and password='{1}'", user, password);
                MySqlCommand command = new MySqlCommand(query, this.kon);
                this.kon.Open();
                MySqlDataReader data = command.ExecuteReader();
                
                if (data.HasRows)
                {
                    while (data.Read())
                    {
                        val[0] = "a";
                        val[1]=data[0].ToString();
                        this.kon.Close();
                        return val;
                    }
                }  
                this.kon.Close();
                val[0] = "";
                val[1] = "Username atau Password anda salah";
                return val;
                
            }catch(Exception e)
            {
                this.Error(e.ToString());
                val[0] = "";
                val[1] = "Terjadi Masalah";
                return val;
            }
            
        }
        public bool newItem(String nama)
        {
            try
            {
                this.kon.Open();
                //String query = String.Format("insert into barang(nama,jumlah,user_id)values('{0}','{1}','{2}')", MySqlHelper.EscapeString(nama), jumlah, user);
                using (MySqlCommand cmd = new MySqlCommand("", this.kon))
                {
                    cmd.CommandText = "insert into barang(nama)values(@nama)";
                    cmd.Parameters.AddWithValue("@nama", nama);
                    //cmd.Parameters.AddWithValue("@jumlah", jumlah);
                    //cmd.Parameters.AddWithValue("@user", user);
                    cmd.ExecuteNonQuery();
                    this.kon.Close();
                    return true;
                }

            } catch(Exception e)
            {
                this.Error(e.ToString());
                return false;
            }
            
        }
        public bool AddQuantity(int jumlah, String user,int id=0,int masuk=1)
        {
            try
            {
                if (id == 0)
                {
                    this.kon.Open();
                    MySqlCommand command = new MySqlCommand("Select id from barang order by id desc limit 1", this.kon);
                    MySqlDataReader data = command.ExecuteReader();
                    while (data.Read())
                    {
                        id = data.GetInt16(0);
                        this.kon.Close();
                        break;
                    }
                }
                this.kon.Open();
                using (MySqlCommand cmd = new MySqlCommand("", this.kon))
                {
                    cmd.CommandText = "insert into riwayat(barang_id,jumlah,user_id,masuk)values(@id,@jumlah,@user,@masuk)";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@jumlah", jumlah);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@masuk", masuk);
                    cmd.ExecuteNonQuery();
                    this.kon.Close();
                    return true;
                };
            }catch(Exception ex)
            {
                this.Error(ex.ToString());
                return false;
            }
            
        }
        private void Error(String err)
        {
            String fileName = @"C:\Users\Rema\Documents\c#\error\data.txt";
            //String fileName = @"D:\data.txt";
            StreamWriter sw = new StreamWriter(fileName, true);

            //Write a line of text
            sw.WriteLine("Error Message: " + err);
            //Close the file
            sw.Close();
        }
       

    }
}