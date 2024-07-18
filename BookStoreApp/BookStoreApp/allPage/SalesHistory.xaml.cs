using BookStoreApp.Model;
using BookStoreApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStoreApp.allPage
{
    /// <summary>
    /// Interaction logic for SalesHistory.xaml
    /// </summary>
    public partial class SalesHistory : Page
    {
        Sales sales;
        List<object> transactionList;
        public SalesHistory()
        {
            InitializeComponent();
            try
            {
                sales = new Sales();
                transactionList = sales.GetData();
                if (transactionList.Count != 0)
                {
                    CreateElementList(transactionList);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message); 
            }
            
        }

        private void CreateElementList(List<Object>  list)
        {
            // get data
            try
            {
                
                dataContainer.Children.Clear(); //use this for remove all element and replace new with data

                foreach (SalesModel objData in list)
                {

                    // grid for data item
                    Grid dataItem = new Grid();  
                    dataItem.HorizontalAlignment = HorizontalAlignment.Stretch;
                    dataItem.VerticalAlignment = VerticalAlignment.Center;
                    dataItem.MinWidth = 500;
                    dataItem.Width = Double.NaN;
                    dataItem.Height = Double.NaN; //use this to make height auto
                    dataItem.Margin = new Thickness(0, 10, 0, 10);

                    // transaction id
                    TextBlock txtId = new TextBlock();
                    txtId.Text = objData.salesId.ToString();
                    txtId.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtId.VerticalAlignment = VerticalAlignment.Center;
                    txtId.Width = Double.NaN;
                    txtId.Height = Double.NaN;
                    txtId.TextAlignment = TextAlignment.Center;

                    // book id
                    TextBlock txtISBN = new TextBlock();
                    txtISBN.Text = objData.ISBN.ToString();
                    txtISBN.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtISBN.VerticalAlignment = VerticalAlignment.Center;
                    txtISBN.Height = Double.NaN;
                    txtISBN.Width = Double.NaN;
                    txtISBN.TextAlignment = TextAlignment.Left;
                    txtISBN.Padding = new Thickness(2);

                    // customer id
                    TextBlock txtCustomerId = new TextBlock();
                    txtCustomerId.Text = objData.customerId.ToString();
                    txtCustomerId.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtCustomerId.VerticalAlignment = VerticalAlignment.Center;
                    txtCustomerId.Height = Double.NaN;
                    txtCustomerId.Width = Double.NaN;
                    txtCustomerId.Padding = new Thickness(2);

                    //grid container have: detail-btn, delete-btn and edit-btn
                    Grid containerBTN = new Grid();
                    containerBTN.HorizontalAlignment = HorizontalAlignment.Stretch;
                    containerBTN.VerticalAlignment = VerticalAlignment.Center;
                    containerBTN.MinWidth = 100;
                    containerBTN.Width = Double.NaN;
                    containerBTN.Height = Double.NaN;
                    ColumnDefinition colDetail = new ColumnDefinition { Width = GridLength.Auto };
                    ColumnDefinition colDelete = new ColumnDefinition { Width = GridLength.Auto };
                    RowDefinition rowContainerBTN = new RowDefinition { Height = GridLength.Auto };
                    containerBTN.ColumnDefinitions.Add(colDetail);
                    containerBTN.ColumnDefinitions.Add(colDelete);
                    containerBTN.RowDefinitions.Add(rowContainerBTN);

                    // image for show in button
                    Image detailImg = new Image { Source = ImageLoading.GetImage("../icon/detail.png"), Width = 15, Height = 15 };
                    Image deleteImg = new Image { Source = ImageLoading.GetImage("../icon/bin.png"), Width = 15, Height = 15 };

                    // button for click edit and delete data
                        //detail
                    Button detailBTN = new Button(); 
                    detailBTN.Name = $"transaction_{objData.salesId}";
                    detailBTN.Click += ShowDetail; 
                    detailBTN.Content = detailImg;
                    detailBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    detailBTN.VerticalAlignment = VerticalAlignment.Center;
                    detailBTN.BorderThickness = new Thickness(0);
                    detailBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));

                    //delete
                    Button deleteBTN = new Button();
                    deleteBTN.Name = $"transaction_{objData.salesId}"; 
                    deleteBTN.Click += DeleteCustomer; 
                    deleteBTN.Content = deleteImg;
                    deleteBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    deleteBTN.VerticalAlignment = VerticalAlignment.Center;
                    deleteBTN.Margin = new Thickness(10, 0, 0, 0);
                    deleteBTN.BorderThickness = new Thickness(0);
                    deleteBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));

                    //set column and row for button
                    Grid.SetColumn(detailBTN, 0);//set column 0
                    Grid.SetColumn(deleteBTN, 2);//set column 2
                    Grid.SetRow(detailBTN, 0);
                    Grid.SetRow(deleteBTN, 0);
                    //connect button to grid container
                    containerBTN.Children.Add(detailBTN);
                    containerBTN.Children.Add(deleteBTN);

                    //define col to grid
                    ColumnDefinition col1 = new ColumnDefinition(); //transaction id
                    col1.Width = new GridLength(100);
                    ColumnDefinition col2 = new ColumnDefinition();//ISBN
                    col2.Width = new GridLength(200);
                    ColumnDefinition col3 = new ColumnDefinition();//customer id
                    col3.Width = new GridLength(200);
                    ColumnDefinition col4 = new ColumnDefinition();// btn container
                    col4.Width = new GridLength(100);

                    RowDefinition row1 = new RowDefinition();
                    row1.Height = GridLength.Auto;

                    // Add columns to the grid
                    dataItem.ColumnDefinitions.Add(col1);
                    dataItem.ColumnDefinitions.Add(col2);
                    dataItem.ColumnDefinitions.Add(col3);
                    dataItem.ColumnDefinitions.Add(col4);
                    dataItem.RowDefinitions.Add(row1);

                    // Set the Grid.Column, Grid.Row properties
                    Grid.SetRow(txtId, 0);
                    Grid.SetRow(txtISBN, 0);
                    Grid.SetRow(txtCustomerId, 0);
                    Grid.SetRow(containerBTN, 0);

                    Grid.SetColumn(txtId, 0);
                    Grid.SetColumn(txtISBN, 1);
                    Grid.SetColumn(txtCustomerId, 2);
                    Grid.SetColumn(containerBTN, 4);

                    dataItem.Children.Add(txtId);
                    dataItem.Children.Add(txtISBN);
                    dataItem.Children.Add(txtCustomerId);
                    dataItem.Children.Add(containerBTN);

                    dataContainer.Children.Add(dataItem);// use this for connecting to parent element 
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            try
            {
                Button deleteBTN = sender as Button;
                string buttonName = deleteBTN.Name;
                SalesHistoryDetail detail = new SalesHistoryDetail(buttonName);
                NavigationService.Navigate(detail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                Button deleteBTN = sender as Button;
                string buttonName = deleteBTN.Name;
                int transactionId = int.Parse(buttonName.Substring(12));

                Boolean statu = sales.DeleteData(transactionId);
                if (statu) 
                {
                    MessageBox.Show($"Transaction id: {transactionId} is deleted.");
                    
                    transactionList = sales.GetData();
                    CreateElementList(transactionList);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GoBack(object sender, RoutedEventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            NavigationService.Navigate(mainMenu);
        }

        private void SearchTransaction(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtInputId.Text.Length != 0)
                {
                    transactionList = sales.GetData(int.Parse(txtInputId.Text));
                    CreateElementList(transactionList);
                }
                else
                {
                    transactionList = sales.GetData();
                    CreateElementList(transactionList);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
