using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Video_Store
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        
        Rent  RentObj = new Rent();
        Video VideoObj = new Video();
        

        

        public Main()
        {
            InitializeComponent();
            dateissuetext.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = Firstnametext.Text;
            string LastName = lastnametext.Text;
            string Address = Addresstext.Text;
            string Phone = Phonetext.Text;
            int CustID = Convert.ToInt32(coustomeidtext.Text);
            RentObj.UpdateCust(CustID ,  FirstName, LastName, Address, Phone);
            
            Custdata.ItemsSource = RentObj .Loadcustomer().DefaultView;
            Firstnametext.Text = "";
            Phonetext.Text = "";
            Addresstext.Text = "";
            lastnametext.Text = "";
            Titletext.Text = "";
            Ratingtext.Text = "";
            Plottext.Text = "";
            Yeartext.Text = "";
            Genretext.Text = "";
            copiestext.Text = "";

        }

        private void cust_Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (Firstnametext.Text != "" && lastnametext.Text != "" && Addresstext.Text != "" && Phonetext.Text != "")
            {
                RentObj.Coustomer_add(Firstnametext.Text, lastnametext.Text, Addresstext.Text, Phonetext.Text);
                Custdata.ItemsSource = RentObj.Loadcustomer().DefaultView;
                Firstnametext.Text = "";
                Phonetext.Text = "";
                Addresstext.Text = "";
                lastnametext.Text = "";
                Titletext.Text = "";
                Ratingtext.Text = "";
                Plottext.Text = "";
                Yeartext.Text = "";
                Genretext.Text = "";
                copiestext.Text = "";


            }
        }

        private void CustDelClick(object sender, RoutedEventArgs e)
        {
            int Cust = Convert.ToInt32(coustomeidtext.Text);
           
            RentObj.CustomerDelete(Cust);
            Custdata.ItemsSource = RentObj.Loadcustomer().DefaultView;
            Firstnametext.Text = "";
            Addresstext.Text = "";
            lastnametext.Text = "";
            Phonetext.Text = "";
            
        }

        private void Customer_load(object sender, RoutedEventArgs e)
        {
           
            Custdata.ItemsSource = RentObj.Loadcustomer().DefaultView;
        }

        private void Select(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Custdata.SelectedItems[0];
            coustomeidtext.Text = Convert.ToString(row["CustID"]);
            Firstnametext.Text = Convert.ToString(row["FirstName"]);
            lastnametext.Text = Convert.ToString(row["Lastname"]);
            Addresstext.Text = Convert.ToString(row["Address"]);
            Phonetext.Text = Convert.ToString(row["Phone"]);

            Custdata.ItemsSource = RentObj.Loadcustomer().DefaultView;
        }

        private void AddMovies_Click(object sender, RoutedEventArgs e)
        {
            
            if (Ratingtext.Text != "" && Titletext.Text != "" && Yeartext.Text != "" &&  Plottext.Text != "" && Genretext .Text != "" && copiestext.Text != "")
            {
                int Year = Convert.ToInt32(Yeartext.Text);
                int cp = Convert.ToInt32(copiestext.Text);
                string Money;
                if (2019 - Year > 5)
                {
                    Money = "2";
                        
                }
                else
                {
                    Money = "5";
                }

                VideoObj.VideosInsert(Ratingtext.Text, Titletext.Text, Yeartext.Text, Money, Plottext.Text, Genretext.Text, cp);
                Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
                Firstnametext.Text = "";
                Phonetext.Text = "";
                Addresstext.Text = "";
                lastnametext.Text = "";
                Titletext.Text = "";
                Ratingtext.Text = "";
                Plottext.Text = "";
                Yeartext.Text = "";
                Genretext.Text = "";
                copiestext.Text = "";

            }
        }
        private void Movie_Edit(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Moviedata.SelectedItems[0];
            Titletext.Text = Convert.ToString(row["Title"]);
            Plottext.Text = Convert.ToString(row["Plot"]);
            Genretext.Text = Convert.ToString(row["Genre"]);
            Yeartext.Text = Convert.ToString(row["Year"]);
            Ratingtext.Text = Convert.ToString(row["Rating"]);
            Movieidtext.Text = Convert.ToString(row["MovieID"]);
            copiestext.Text = Convert.ToString(row["copies"]);

            Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
        }

        private void TabControl_SelectionChanged()
        {

        }

        private void Movieid_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Movieid_txt_Copy2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Returned_Click(object sender, RoutedEventArgs e)
        {
            int RMID = Convert.ToInt32(rmidtext.Text);
            int MoviedID = Convert.ToInt32(Movieidtext.Text);



            RentObj.Return(RMID, MoviedID, Convert.ToDateTime(dateissuetext.Text), DateTime.Now);

            Rentdata.ItemsSource = RentObj.ListRented().DefaultView;
            Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
            Rentdata.ItemsSource = RentObj.ListRented().DefaultView;
            Custdata.ItemsSource = RentObj.Loadcustomer().DefaultView;
            Firstnametext.Text = "";
            Phonetext.Text = "";
            Addresstext.Text = "";
            lastnametext.Text = "";
            Titletext.Text = "";
            Ratingtext.Text = "";
            Plottext.Text = "";
            Yeartext.Text = "";
            Genretext.Text = "";
            copiestext.Text = "";


        }



        private void Borrowed_Click(object sender, RoutedEventArgs e)
        {

            if (Movieidtext.Text != "" && coustomeidtext.Text != "" && dateissuetext.Text != "")
            {
                int MovieID = Convert.ToInt32(Movieidtext.Text);
                int Customerid = Convert.ToInt32(coustomeidtext.Text);
                dateissuetext.Text = DateTime.Today.ToString("dd-MM-yyyy");
                int copies = Convert.ToInt32(copiestext.Text);



                RentObj.issue(MovieID, Customerid, DateTime.Now);
                Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
                Rentdata.ItemsSource = RentObj.ListRented().DefaultView;
                Custdata.ItemsSource = RentObj.Loadcustomer().DefaultView;
                Firstnametext.Text = "";
                Phonetext.Text = "";
                Addresstext.Text = "";
                lastnametext.Text = "";
                Titletext.Text = "";
                Ratingtext.Text = "";
                Plottext.Text = "";
                Yeartext.Text = "";
                Genretext.Text = "";
                copiestext.Text = "";

            }




        }

        private void Rental_data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Rented(object sender, MouseButtonEventArgs e)
        {
            DataRowView row = (DataRowView)Rentdata.SelectedItems[0];
            Movieidtext.Text = Convert.ToString(row["MovieIDFK"]);
            coustomeidtext.Text = Convert.ToString(row["CustIDFK"]);
            rmidtext.Text = Convert.ToString(row["RMID"]);
            dateissuetext.Text = Convert.ToString(row["DateRented"]);
            dateretunedtext.Text = DateTime.Now.ToString("dd-MM-yyyy");



            Rentdata.ItemsSource = RentObj.ListRented().DefaultView;
        }

        private void MovieLoad(object sender, RoutedEventArgs e)
        {
            Rentdata.ItemsSource = RentObj.ListRented().DefaultView;

        }

        private void Rent(object sender, RoutedEventArgs e)
        {
            Rentdata.ItemsSource = RentObj.ListRented().DefaultView;
        }

        private void ReturnBack_Click(object sender, RoutedEventArgs e)
        {

            int RMID = Convert.ToInt32(rmidtext.Text);
            dateretunedtext.Text = DateTime.Today.ToString("dd-MM-yyyy");
            int MoviedID = Convert.ToInt32(Movieidtext.Text);



            RentObj.Return(RMID, MoviedID, Convert.ToDateTime(dateissuetext.Text), DateTime.Now);
            Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
            Rentdata.ItemsSource = RentObj.ListRented().DefaultView;
            Custdata.ItemsSource = RentObj.Loadcustomer().DefaultView;
            Firstnametext.Text = "";
            Phonetext.Text = "";
            Addresstext.Text = "";
            lastnametext.Text = "";
            Titletext.Text = "";
            Ratingtext.Text = "";
            Plottext.Text = "";

            Yeartext.Text = "";
            Genretext.Text = "";
            copiestext.Text = "";


        }

        private void UpdateMovies_Click(object sender, RoutedEventArgs e)
        {
            int MovID = Convert.ToInt32(Movieidtext.Text);
            int copies = Convert.ToInt32(copiestext.Text);


            string Title = Titletext.Text;
            string Rating = Ratingtext.Text;
            string Plot = Plottext.Text;
            string Genre = Genretext.Text;
            int Year = Convert.ToInt32(Yeartext.Text);
            VideoObj .VideosUpdat( MovID, Rating, Title, Year, Plot, Genre, copies);
           
            Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
            Firstnametext.Text = "";
            Phonetext.Text = "";
            Addresstext.Text = "";
            lastnametext.Text = "";
            Titletext.Text = "";
            Ratingtext.Text = "";
            Plottext.Text = "";
            Yeartext.Text = "";
            Genretext.Text = "";
            copiestext.Text = "";
        }

        private void DeleteMovie(object sender, RoutedEventArgs e)
        {
            
                int mov = Convert.ToInt32(Movieidtext.Text);



                VideoObj .DeleteVideo( mov);
            Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
            Firstnametext.Text = "";
            Phonetext.Text = "";
            Addresstext.Text = "";
            lastnametext.Text = "";
            Titletext.Text = "";
            Ratingtext.Text = "";
            Plottext.Text = "";
            Yeartext.Text = "";
            Genretext.Text = "";
            copiestext.Text = "";





        }

        private void Video_loaded(object sender, RoutedEventArgs e)
        {
            Moviedata.ItemsSource = VideoObj.VideosLoad().DefaultView;
        }

        

      
    }
}
