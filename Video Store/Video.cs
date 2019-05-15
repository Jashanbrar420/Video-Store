using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Video_Store
{
    class Video
    {
        SqlConnection ConnVideo = new SqlConnection("Data Source=LAPTOP-9A6RU4RG;Initial Catalog=VSR_System;Integrated Security=True");

        SqlCommand CmdVideo = new SqlCommand();

        SqlDataReader VideoReader;

        String video;

        public IEnumerable DefaultView { get; internal set; }



        public void VideosInsert(string Rating, string Title, string Year, string Rental_Cost, string Plot, string Genre, int copies)
        {
            try
            {
                CmdVideo.Parameters.Clear();
                CmdVideo.Connection = ConnVideo;



                video = "Insert into Movies(Rating, Title, Year, Rental_Cost, Plot, Genre, copies) Values( @Rating, @Title, @Year, @Rental_Cost, @Plot, @Genre, @copies)";


                CmdVideo.Parameters.AddWithValue("@Rating", Rating);
                CmdVideo.Parameters.AddWithValue("@Title", Title);
                CmdVideo.Parameters.AddWithValue("@Year", Year);
                CmdVideo.Parameters.AddWithValue("@Rental_Cost", Rental_Cost);
                CmdVideo.Parameters.AddWithValue("@Plot", Plot);
                CmdVideo.Parameters.AddWithValue("@Genre", Genre);
                CmdVideo.Parameters.AddWithValue("@copies", copies);

                CmdVideo.CommandText = video;

                ConnVideo.Open();

                CmdVideo.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnVideo != null)
                {
                    ConnVideo.Close();
                }
            }
        }

        public void DeleteVideo(int MovieID)
        {
            try
            {
                CmdVideo.Parameters.Clear();
                CmdVideo.Connection = this.ConnVideo;


                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@MovieID", MovieID) };
                CmdVideo.Parameters.Add(parameterArray[0]);
                String k;
                ConnVideo.Open();

                k = "Delete from Movies where MovieID like @MovieID";
                CmdVideo.CommandText = k;
                CmdVideo.ExecuteNonQuery();
                MessageBox.Show("Movie Deleted");


            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.ConnVideo != null)
                {
                    this.ConnVideo.Close();
                }

            }
        }



        public void VideosUpdat(int MovieID, string Rating, string Title, int Year, string Plot, string Genre, int copies)
        {
            try
            {
                CmdVideo.Parameters.Clear();
                CmdVideo.Connection = ConnVideo;
                video = "Update Movies Set Rating = @Rating, Title = @Title, Year = @Year,  Plot = @Plot, Genre = @Genre, copies = @copies where MovieID like @MovieID";


                CmdVideo.Parameters.AddWithValue("@MovieID", MovieID);
                CmdVideo.Parameters.AddWithValue("@Rating", Rating);
                CmdVideo.Parameters.AddWithValue("@Title", Title);
                CmdVideo.Parameters.AddWithValue("@Year", Year);
                CmdVideo.Parameters.AddWithValue("@Plot", Plot);
                CmdVideo.Parameters.AddWithValue("@Genre", Genre);
                CmdVideo.Parameters.AddWithValue("@copies", copies);


                CmdVideo.CommandText = video;

                ConnVideo.Open();

                CmdVideo.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnVideo != null)
                {
                    ConnVideo.Close();
                }
            }
        }
        public DataTable VideosLoad()
        {
            DataTable data = new DataTable();
            try
            {
                CmdVideo.Connection = ConnVideo;
                video = "Select * from Movies";

                CmdVideo.CommandText = video;
                ConnVideo.Open();

                VideoReader = CmdVideo.ExecuteReader();

                if (VideoReader.HasRows)
                {
                    data.Load(VideoReader);
                }
                return data;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
                return null;
            }
            finally
            {
                if (VideoReader != null)
                {
                    VideoReader.Close();
                }

                if (ConnVideo != null)
                {
                    ConnVideo.Close();
                }
            }

        }



        
       
        
    }
}
