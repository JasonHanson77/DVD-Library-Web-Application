using DVDLibraryDBWEB.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibraryDBWEB.Models.Tables;
using System.Data.SqlClient;
using System.Data;

namespace DVDLibraryDBWEB.Data.ADO
{
    public class DVDRepositoryADO : IDVDRepository
    {
        static DVDRepositoryADO()
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                //Resetting database with ADO repo data and clearing out Entity data
                SqlCommand cmd = new SqlCommand("DbReset", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void DVDCreate(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDCreate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter sqlParameter = new SqlParameter("@DVDId", SqlDbType.Int);
                sqlParameter.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(sqlParameter);

                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

                //Getting value of newly generated primary key back from database 
                dvd.DVDId = (int)sqlParameter.Value;

            }
        }

        public void DVDDelete(int DVDId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDId", DVDId);


                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public void DVDUpdate(DVD dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDId", dvd.DVDId);
                cmd.Parameters.AddWithValue("@Title", dvd.Title);
                cmd.Parameters.AddWithValue("@Director", dvd.Director);
                cmd.Parameters.AddWithValue("@Rating", dvd.Rating);
                cmd.Parameters.AddWithValue("@ReleaseYear", dvd.ReleaseYear);
                cmd.Parameters.AddWithValue("@Notes", dvd.Notes);

                cn.Open();

                cmd.ExecuteNonQuery();

            }
        }

        public List<DVD> GetAllDVDs()
        {
            List<DVD> DVD = new List<DVD>();
            string conn = Settings.GetConnectionString();

            using (var cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectAll", cn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DVD currentRow = new DVD();

                        currentRow.DVDId = (int)dr["DVDId"];
                        currentRow.Title = dr["Title"].ToString();
                        if (dr["Director"] != DBNull.Value)
                        {
                            currentRow.Director = dr["Director"].ToString();
                        }
                        currentRow.Rating = dr["Rating"].ToString();
                        currentRow.ReleaseYear = dr["ReleaseYear"].ToString();
                        if (dr["Notes"] != DBNull.Value)
                        {

                            currentRow.Notes = dr["Notes"].ToString();
                        }

                        DVD.Add(currentRow);
                    }
                }
            }

            return DVD;
        }

        public DVD GetDVDById(int DVDId)
        {
            DVD dvd = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectById", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@DVDId", DVDId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd = new DVD();

                        dvd.DVDId = (int)dr["DVDId"];
                        dvd.Title = dr["Title"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                    }
                }
            }

            return dvd;
        }

        public List<DVD> GetDVDByTitle(string Title)
        {
            List<DVD> dvds = new List<DVD>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Title", Title);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        DVD dvd = new DVD();

                        dvd.DVDId = (int)dr["DVDId"];
                        dvd.Title = dr["Title"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<DVD> GetDVDByYear(string Year)
        {
            List<DVD> dvds = new List<DVD>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectByYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Year", Year);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        DVD dvd = new DVD();
                        dvd.DVDId = (int)dr["DVDId"];
                        dvd.Title = dr["Title"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<DVD> GetDVDByDirector(string Director)
        {
            List<DVD> dvds = new List<DVD>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Director", Director);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        DVD dvd = new DVD();
                        dvd.DVDId = (int)dr["DVDId"];
                        dvd.Title = dr["Title"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }

        public List<DVD> GetDVDByRating(string Rating)
        {
            List<DVD> dvds = new List<DVD>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DVDSelectByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Rating", Rating);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    
                    while (dr.Read())
                    {
                        DVD dvd = new DVD();

                        dvd.DVDId = (int)dr["DVDId"];
                        dvd.Title = dr["Title"].ToString();

                        if (dr["Director"] != DBNull.Value)
                        {
                            dvd.Director = dr["Director"].ToString();
                        }
                        dvd.Rating = dr["Rating"].ToString();
                        dvd.ReleaseYear = dr["ReleaseYear"].ToString();

                        if (dr["Notes"] != DBNull.Value)
                        {
                            dvd.Notes = dr["Notes"].ToString();
                        }
                        dvds.Add(dvd);
                    }
                }
            }

            return dvds;
        }
    }
}

