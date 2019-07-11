using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Books
{
    internal class DBAccess
    {
        public DBAccess()
        {
        }

        internal DataSet GetLookup()
        {

            DataSet ds = null;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_GetLookUp"))
                {
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ds = LoadDatatSet(cmd);
                }

                cn.Close();
            }
            return ds;
        }


        internal int SetTitle(string title, ref string msg)
        {
            int titleId = 0;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_SetTitle";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Title", SqlDbType.VarChar).Value = title;
                cmd.Parameters.Add("@TitleID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                titleId = (int)cmd.Parameters["@TitleID"].Value;
                cn.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return titleId;
        }

        public int SetBook(string action, ref string msg, int ? genreID = null, int ? authorID = null, int ? titleID = null, string dateCreated = null, int ? ID = null)
        {

            int bookID = 0;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_SetBook";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Action", SqlDbType.VarChar).Value = action;
                cmd.Parameters.Add("@GenreID", SqlDbType.VarChar).Value = genreID;
                cmd.Parameters.Add("@AuthorID", SqlDbType.VarChar).Value = authorID;
                cmd.Parameters.Add("@TitleID", SqlDbType.VarChar).Value = titleID;
                cmd.Parameters.Add("@DateCreated", SqlDbType.Date).Value = dateCreated;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                cmd.Parameters.Add("@BookID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                bookID = Convert.ToInt32(cmd.Parameters["@BookID"].Value);
                cn.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return bookID;
        }
    
        private string GetConnectionStr()
        {
            string strCon = ConfigurationManager.ConnectionStrings["Sql_Connection"].ConnectionString;
            return strCon;
        }
    
        internal DataSet GetTitle(int?  authorId = null, int? genreId = null)
        {
            DataSet dt = null;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_GetTitle"))
                {
                    cmd.Connection = cn;
                    cmd.Parameters.Add("@GenreID", SqlDbType.Int).Value = genreId;
                    cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Value = authorId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    dt = LoadDatatSet(cmd);
                }

                cn.Close();
            }
            return dt;
        }
        internal DataSet GetBook( int? bookId = null)
        {
            DataSet dt = null;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_GetBook"))
                {
                    cmd.Connection = cn;
                    cmd.Parameters.Add("@BookID", SqlDbType.Int).Value = bookId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    dt = LoadDatatSet(cmd);
                }

                cn.Close();
            }
            return dt;
        }

        internal DataSet GetAuthor(int ? genreId = null)
        {

            DataSet ds = null;

            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                using (SqlCommand cmd = new SqlCommand("P_GetAuthor"))
                {
                    cmd.Connection = cn;
                    cmd.Parameters.Add("@GenreId", SqlDbType.Int).Value = genreId;
                    cmd.CommandType = CommandType.StoredProcedure;
                    ds = LoadDatatSet(cmd);
                }

                cn.Close();
            }
            return ds;
        }

        public int SetAuthor(string fName, string lName, ref string msg)
        {
            int authorId = 0;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_SetAuthor";
                cmd.Connection = cn;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = fName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = lName;
                cmd.Parameters.Add("@AuthorID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                authorId = (int)cmd.Parameters["@AuthorID"].Value;
                cn.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return authorId;
        }

        private DataSet LoadDatatSet(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
            return ds;
        }

        public int SetGenre(string genre, ref string msg)
        {
            int genreId = 0;
            SqlConnection cn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                cn.ConnectionString = GetConnectionStr();
                cn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "P_SetGenre";
                cmd.Connection = cn;
                cmd.Parameters.Add("@Genre", SqlDbType.VarChar).Value = genre;
                cmd.Parameters.Add("@GenreID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                genreId = (int)cmd.Parameters["@GenreID"].Value;
                cn.Close();
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return genreId;
        }
    }
}