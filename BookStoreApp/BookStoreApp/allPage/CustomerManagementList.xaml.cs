using BookStoreApp.Model;
using BookStoreApp.SQLite;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookStoreApp.allPage
{
    public partial class CustomerManagementList : Page
    {
        Customers customers;
        List<Object> customerList;
        public CustomerManagementList()
        {
            InitializeComponent();
            customers = new Customers();
            customerList = customers.GetData();
            CreateElementList(customerList);
        }

        private void CreateElementList(List<Object> customerList)
        {
            try
            {
                dataContainer.Children.Clear(); //use this for remove all element and replace new with data

                foreach (CustomerModel objData in customerList)
                {

                    // grid for data item
                    Grid dataItem = new Grid(); 
                    dataItem.HorizontalAlignment = HorizontalAlignment.Stretch;
                    dataItem.VerticalAlignment = VerticalAlignment.Center;
                    dataItem.MinWidth = 500;
                    dataItem.Width = Double.NaN;
                    dataItem.Height = Double.NaN; //use this to make height auto
                    dataItem.Margin = new Thickness(0, 10, 0, 10);

                    // data id
                    TextBlock txtId = new TextBlock();
                    txtId.Text = objData.customerId.ToString();
                    txtId.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtId.VerticalAlignment = VerticalAlignment.Center;
                    txtId.Width = Double.NaN;
                    txtId.Height = Double.NaN;
                    txtId.TextAlignment = TextAlignment.Center;

                    // customer name
                    TextBlock txtCustomerName = new TextBlock();
                    txtCustomerName.Text = objData.customerName.ToString();
                    txtCustomerName.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtCustomerName.VerticalAlignment = VerticalAlignment.Center;
                    txtCustomerName.Height = Double.NaN;
                    txtCustomerName.Width = Double.NaN;
                    txtCustomerName.TextAlignment = TextAlignment.Left;
                    txtCustomerName.Padding = new Thickness(2);

                    // email
                    TextBlock txtEmail = new TextBlock();
                    txtEmail.Text = objData.email.ToString();
                    txtEmail.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtEmail.VerticalAlignment = VerticalAlignment.Center;
                    txtEmail.Height = Double.NaN;
                    txtEmail.Width = Double.NaN;
                    txtEmail.Padding = new Thickness(2);

                    //grid container have: detail-btn, delete-btn and edit-btn
                    Grid containerBTN = new Grid();
                    containerBTN.HorizontalAlignment = HorizontalAlignment.Stretch;
                    containerBTN.VerticalAlignment = VerticalAlignment.Center;
                    containerBTN.MinWidth = 100;
                    containerBTN.Width = Double.NaN;
                    containerBTN.Height = Double.NaN;

                    ColumnDefinition colDetail = new ColumnDefinition { Width = GridLength.Auto };
                    ColumnDefinition colEdit = new ColumnDefinition { Width = GridLength.Auto };
                    ColumnDefinition colDelete = new ColumnDefinition { Width = GridLength.Auto };
                    RowDefinition rowContainerBTN = new RowDefinition { Height = GridLength.Auto };
                   
                    containerBTN.ColumnDefinitions.Add(colDetail);
                    containerBTN.ColumnDefinitions.Add(colEdit);
                    containerBTN.ColumnDefinitions.Add(colDelete);
                    containerBTN.RowDefinitions.Add(rowContainerBTN);

                    // image for show in button
                    Image detailImg = new Image { Source = ImageLoading.GetImage("../icon/detail.png"), Width = 15, Height = 15 };
                    Image editImg = new Image { Source = ImageLoading.GetImage("../icon/edit.png"), Width = 15, Height = 15 };
                    Image deleteImg = new Image { Source = ImageLoading.GetImage("../icon/bin.png"), Width = 15, Height = 15 };

                    // button for click edit and delete data
                      //detail
                    Button detailBTN = new Button();  
                    detailBTN.Name = $"customer_{objData.customerId}"; 
                    detailBTN.Click += ShowDetail;  
                    detailBTN.Content = detailImg;
                    detailBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    detailBTN.VerticalAlignment = VerticalAlignment.Center;
                    detailBTN.Cursor = Cursors.Hand;
                    detailBTN.BorderThickness = new Thickness(0);
                    detailBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));

                    //edit
                    Button editBTN = new Button();  
                    editBTN.Name = $"customer_{objData.customerId}";  
                    editBTN.Click += EditCustomer;  
                    editBTN.Content = editImg;
                    editBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    editBTN.VerticalAlignment = VerticalAlignment.Center;
                    editBTN.Margin = new Thickness(5, 0, 5, 0);
                    editBTN.Cursor =Cursors.Hand;
                    editBTN.BorderThickness = new Thickness(0);
                    editBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));

                    //delete
                    Button deleteBTN = new Button(); 
                    deleteBTN.Name = $"customer_{objData.customerId}";  
                    deleteBTN.Click += DeleteCustomer;  
                    deleteBTN.Content = deleteImg;
                    deleteBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    deleteBTN.VerticalAlignment = VerticalAlignment.Center;
                    deleteBTN.Cursor = Cursors.Hand;
                    deleteBTN.BorderThickness = new Thickness(0);
                    deleteBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));

                    //set column and row for button
                    Grid.SetColumn(detailBTN, 0);//set column 0
                    Grid.SetColumn(editBTN, 1);//set column 1
                    Grid.SetColumn(deleteBTN, 2);//set column 2
                    Grid.SetRow(detailBTN, 0);
                    Grid.SetRow(editBTN, 0);
                    Grid.SetRow(deleteBTN, 0);
                    //connect button to grid container
                    containerBTN.Children.Add(detailBTN);
                    containerBTN.Children.Add(editBTN);
                    containerBTN.Children.Add(deleteBTN);

                    //define col to grid
                    ColumnDefinition col1 = new ColumnDefinition(); //id
                    col1.Width = new GridLength(100);
                    ColumnDefinition col2 = new ColumnDefinition();//customer name
                    col2.Width = new GridLength(200);
                    ColumnDefinition col3 = new ColumnDefinition();// email
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

                    // Set the Grid.Column, Grid.Row, Grid.ColumnSpan, and Grid.RowSpan properties
                    Grid.SetRow(txtId, 0);
                    Grid.SetRow(txtCustomerName, 0);
                    Grid.SetRow(txtEmail, 0);
                    Grid.SetRow(containerBTN, 0);

                    Grid.SetColumn(txtId, 0);
                    Grid.SetColumn(txtCustomerName, 1);
                    Grid.SetColumn(txtEmail, 2);
                    Grid.SetColumn(containerBTN, 4);

                    dataItem.Children.Add(txtId);
                    dataItem.Children.Add(txtCustomerName);
                    //dataItem.Children.Add(txtDesc);
                    dataItem.Children.Add(txtEmail);
                    dataItem.Children.Add(containerBTN);

                    dataContainer.Children.Add(dataItem);// use this for connecting to parent element 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement();
            NavigationService.Navigate(customerManagement);
        }

        private void DeleteCustomer(object sender, RoutedEventArgs e)
        {
            Button deleteBTN = sender as Button;
            String buttonName = deleteBTN.Name;
            try
            {
                if (buttonName != null) {
                    
                    Boolean status = customers.DeleteData(int.Parse(buttonName.Substring(9)));
                    if (status)
                    {
                        MessageBox.Show($"Customer id: {buttonName.Substring(9)} is deleted.");
                        customerList = customers.GetData();
                        CreateElementList(customerList);
                    }
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show($"Cannot delete Customer id: {buttonName.Substring(9)}");
            }
        }

        private void EditCustomer(object sender, RoutedEventArgs e)
        {
            Button editBTN = sender as Button;
            String buttonName = editBTN.Name;
            try
            {
                if (buttonName != null)
                {
                    
                        CustomerManagementEdit customerManagementEdit = new CustomerManagementEdit(buttonName);
                        NavigationService.Navigate(customerManagementEdit);
                
                }
            }catch (Exception ex)
                {
                MessageBox.Show(ex.Message);
            }
        }
        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            try
            {
                Button detailBTN = sender as Button;
                string buttonName = detailBTN.Name;
                if (buttonName != null) 
                {
                    CustomerManagementDetail customerManagementDetail = new CustomerManagementDetail(buttonName);
                    NavigationService.Navigate(customerManagementDetail);
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void SearchCustomer(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtInputId.Text.Length != 0)
                {
                    int dataInput = int.Parse(txtInputId.Text);
                    
                    
                        customerList = customers.GetData(dataInput);
                        CreateElementList(customerList);
                
                }
                else
                {
                    customerList = customers.GetData();
                    CreateElementList(customerList);
                    
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




    }
}
