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
    class Rent
    {
        SqlConnection ConnRent = new SqlConnection("Data Source=LAPTOP-9A6RU4RG;Initial Catalog=VSR_System;Integrated Security=True");

        SqlCommand CMDrent = new SqlCommand();

        SqlDataReader ReaderRent;

        
       String money;

        

        public IEnumerable DefaultView { get; internal set; }
        public string strr { get; private set; }

        public DataTable Loadcustomer()
        {
            DataTable data = new DataTable();
            try
            {
                CMDrent.Connection = ConnRent;
                money = "Select * from Coustmer";

                CMDrent.CommandText = money;
                ConnRent.Open();

                ReaderRent = CMDrent.ExecuteReader();

                if (ReaderRent.HasRows)
                {
                    data.Load(ReaderRent);
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
                if (ReaderRent != null)
                {
                    ReaderRent.Close();
                }

                if (ConnRent != null)
                {
                    ConnRent.Close();
                }
            }

        }



        public void Coustomer_add(string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                CMDrent.Parameters.Clear();
                CMDrent.Connection = ConnRent;



                money = "Insert into Coustmer(FirstName, LastName, Address, Phone) Values( @FirstName, @LastName, @Address, @Phone)";


                CMDrent.Parameters.AddWithValue("@FirstName", FirstName);
                CMDrent.Parameters.AddWithValue("@LastName", LastName);
                CMDrent.Parameters.AddWithValue("@Address", Address);
                CMDrent.Parameters.AddWithValue("@Phone", Phone);

                CMDrent.CommandText = money;

                ConnRent.Open();

                CMDrent.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnRent != null)
                {
                    ConnRent.Close();
                }
            }
        }

        public void CustomerDelete(Int32 CustID)
        {
            try
            {
                CMDrent.Parameters.Clear();
                CMDrent.Connection = this.ConnRent;


                String Strr = "";
                SqlParameter[] parameterArray = new SqlParameter[] { new SqlParameter("@CustID", CustID) };
                CMDrent.Parameters.Add(parameterArray[0]);

                ConnRent.Open();
                int count = Convert.ToInt32(CMDrent.ExecuteScalar());
               
                    Strr = "Delete from Coustmer where CustID like @CustID";
                    CMDrent.CommandText = Strr;
                    CMDrent.ExecuteNonQuery();
                    MessageBox.Show("User Deleted");
                
               
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception" + exception.Message);
            }
            finally
            {
                if (this.ConnRent != null)
                {
                    this.ConnRent.Close();
                }
            }
        }


        public void issue(int MovieIDFK, int CustIDFK, DateTime DateRented)
        {
            try
            {
                CMDrent.Parameters.Clear();
                CMDrent.Connection = ConnRent;



                money = "Insert into RentedMovies(MovieIDFK, CustIDFK, DateRented ) Values( @MovieIDFk, @CustIDFK, @DateRented)";

                CMDrent.Parameters.AddWithValue("@MovieIDFK", MovieIDFK);
                CMDrent.Parameters.AddWithValue("@CustIDFK", CustIDFK);
                CMDrent.Parameters.AddWithValue("@DateRented", DateRented);


                CMDrent.CommandText = money;

                ConnRent.Open();

                CMDrent.ExecuteNonQuery();

                money = "Update Movies set copies = copies-1 where MovieID = @MovieIDFK";
                CMDrent.CommandText = money;
                CMDrent.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnRent != null)
                {
                    ConnRent.Close();
                }
            }
        }


        public void Return(int RMID, int MovID, DateTime Date_Rent, DateTime Date_Returned)
        {
            try
            {
                CMDrent.Parameters.Clear();
                CMDrent.Connection = ConnRent;
                int Amount = 0, RT = 0;
                double days = (Date_Returned - Date_Rent).TotalDays;

                string make = "Select Rental_Cost from Movies where MovieID = @MovieIDFK";
                CMDrent.Parameters.AddWithValue("@MovieIDFK", MovID);

                CMDrent.CommandText = make;
                ConnRent.Open();
                Amount = Convert.ToInt32(CMDrent.ExecuteScalar());

                if (Convert.ToInt32(days) == 0)
                {
                    RT = Amount;
                }
                else
                {
                    RT = Amount * Convert.ToInt32(days);
                }


                strr = "Update RentedMovies Set DateReturned='" + Date_Returned + "' where RMID = @RMID";
                CMDrent.Parameters.AddWithValue("@DateReturned", Date_Returned);
                CMDrent.Parameters.AddWithValue("@RMID", RMID);

                CMDrent.CommandText = strr;

                CMDrent.ExecuteNonQuery();


                strr = "Update Movies set Copies = Copies+1 where MovieID = @MovieIDFK";
                this.CMDrent.CommandText = this.strr;

                this.CMDrent.ExecuteNonQuery();



                MessageBox.Show("The Rent is " + RT);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Database Exception " + exception.Message);
            }
            finally
            {
                if (ConnRent != null)
                {
                    ConnRent.Close();
                }
            }


        }
        public void UpdateCust(int CustID, string FirstName, string LastName, string Address, string Phone)
        {
            try
            {
                CMDrent.Parameters.Clear();
                CMDrent.Connection = ConnRent;
                money = "Update Coustmer Set FirstName = @FirstName, LastName = @LastName, Address = @Address, Phone = @Phone where CustID = @CustID";


                CMDrent.Parameters.AddWithValue("@CustID", CustID);
                CMDrent.Parameters.AddWithValue("@FirstName", FirstName);
                CMDrent.Parameters.AddWithValue("@LastName", LastName);
                CMDrent.Parameters.AddWithValue("@Address", Address);
                CMDrent.Parameters.AddWithValue("@Phone", Phone);

                CMDrent.CommandText = money;

                ConnRent.Open();

                CMDrent.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Exception" + ex.Message);
            }
            finally
            {
                if (ConnRent != null)
                {
                    ConnRent.Close();
                }
            }
        }
        public DataTable ListRented()
        {
            DataTable data = new DataTable();
            try
            {
                CMDrent.Connection = ConnRent;
                money = "Select * from RentedMovies";

                CMDrent.CommandText = money;
                ConnRent.Open();

                ReaderRent = CMDrent.ExecuteReader();

                if (ReaderRent.HasRows)
                {
                    data.Load(ReaderRent);
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
                if (ReaderRent != null)
                {
                    ReaderRent.Close();
                }

                if (ConnRent != null)
                {
                    ConnRent.Close();
                }
            }

        }



       

       


        
    }
}
