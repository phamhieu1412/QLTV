﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTN_QLTV.DAL
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        // Trung
        //private string str = @"Data Source=DESKTOP-LAOT6MD\GNOS02;Initial Catalog=TTN_QLTV;Integrated Security=True";
        // Nam
        //private string str = @"Data Source=DESKTOP-CTR1TPG;Initial Catalog=TTN_QLTV;Integrated Security=True";
        // Dung
        //private string str = @"Data Source=;Initial Catalog=TTN_QLTV;Integrated Security=True";
        // Vu
        //private string str = @"Data Source=nguyenvanvu563a\sqlexpress;Initial Catalog=TTN_QLTV;Integrated Security=True";
        // Hieu
        private string str = @"Data Source=DESKTOP-HKOJN4O;Initial Catalog=TTN_QLTV;Integrated Security=True";
        public DataTable ExecuteQuery(string query)
        {
            Trace.WriteLine(query);
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(str))
            {
                
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(data);

                conn.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                data = command.ExecuteNonQuery();

                conn.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(SqlCommand query)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                query.Connection = conn;

                data = query.ExecuteNonQuery();

                conn.Close();
            }
            return data;
        }

        public object ExecuteScalar(string query)
        {
            object data;

            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();

                SqlCommand command = new SqlCommand(query, conn);

                data = command.ExecuteScalar();

                conn.Close();
            }
            return data;
        }
    }
}

