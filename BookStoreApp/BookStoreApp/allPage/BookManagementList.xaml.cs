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
using System.Xml.Linq;

namespace BookStoreApp.allPage
{
    public partial class BookManagementList : Page
    {
        Books books;
        List<Object> bookList;
        public BookManagementList()
        {
            InitializeComponent();
            books = new Books(); // create instance obj
            bookList = books.GetData(); // get data list
            CreateElementList(bookList); //create element item for each data
            
        }

        private void CreateElementList(List<Object> bookList)
        {
            try
            {
                dataContainer.Children.Clear(); //clear all element
                
                foreach (BookModel objData in bookList)
                {
                    
                    // grid for data item
                    Grid dataItem = new Grid(); // element for showing data
                    dataItem.HorizontalAlignment = HorizontalAlignment.Stretch;
                    dataItem.VerticalAlignment = VerticalAlignment.Center;
                    dataItem.MinWidth = 500;
                    dataItem.Width = Double.NaN; //use double.NaN to make auto width
                    dataItem.Height = Double.NaN; 
                    dataItem.Margin = new Thickness(0, 10, 0, 10);

                    // book id
                    TextBlock txtId = new TextBlock();
                    txtId.Text = objData.ISBN.ToString();
                    txtId.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtId.VerticalAlignment = VerticalAlignment.Center;
                    txtId.Width = Double.NaN;
                    txtId.Height = Double.NaN;
                    txtId.TextAlignment = TextAlignment.Center;

                    // book title
                    TextBlock txtTitle = new TextBlock();
                    txtTitle.Text = objData.title.ToString();
                    txtTitle.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtTitle.VerticalAlignment = VerticalAlignment.Center;
                    txtTitle.Height = Double.NaN;
                    txtTitle.Width = Double.NaN;
                    txtTitle.TextAlignment = TextAlignment.Left;
                    txtTitle.Padding = new Thickness(2);

                    // book price
                    TextBlock txtPrice = new TextBlock();
                    txtPrice.Text = objData.price.ToString();
                    txtPrice.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtPrice.VerticalAlignment = VerticalAlignment.Center;
                    txtPrice.Height = Double.NaN;
                    txtPrice.Width = Double.NaN;
                    txtPrice.Padding = new Thickness(2);

                    //grid container for detail-btn, delete-btn and edit-btn
                    Grid containerBTN = new Grid();
                    containerBTN.HorizontalAlignment = HorizontalAlignment.Stretch;
                    containerBTN.VerticalAlignment = VerticalAlignment.Center;
                    containerBTN.MinWidth = 100;
                    containerBTN.Width = Double.NaN;
                    containerBTN.Height = Double.NaN;

                    //declare col and row for child element (detail-btn, delete-btn and edit-btn)
                    ColumnDefinition colDetail = new ColumnDefinition { Width = GridLength.Auto };
                    ColumnDefinition colEdit = new ColumnDefinition { Width=GridLength.Auto};
                    ColumnDefinition colDelete = new ColumnDefinition{ Width=GridLength.Auto };
                    RowDefinition rowContainerBTN =new RowDefinition { Height= GridLength.Auto };
                    containerBTN.ColumnDefinitions.Add(colDetail);
                    containerBTN.ColumnDefinitions.Add(colEdit);
                    containerBTN.ColumnDefinitions.Add(colDelete);
                    containerBTN.RowDefinitions.Add(rowContainerBTN);

                    // image for button
                    Image detailImg = new Image { Source = ImageLoading.GetImage("../icon/detail.png"), Width = 15, Height = 15 };
                    Image editImg = new Image{ Source= ImageLoading.GetImage("../icon/edit.png"), Width = 15, Height = 15 };
                    Image deleteImg = new Image{ Source = ImageLoading.GetImage("../icon/bin.png"), Width = 15, Height = 15 };

                    // button for click edit and delete data
                       //detail
                    Button detailBTN = new Button();
                    detailBTN.Name = $"book_{objData.ISBN}"; // add name for btn
                    detailBTN.Click += ShowDetail; //add method for btn
                    detailBTN.Content = detailImg;
                    detailBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    detailBTN.VerticalAlignment = VerticalAlignment.Center;
                    detailBTN.Cursor=Cursors.Hand;
                    detailBTN.BorderThickness = new Thickness(0);
                    detailBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));
                   
                    //edit
                    Button editBTN = new Button(); 
                    editBTN.Name = $"book_{objData.ISBN}";
                    editBTN.Click += EditBook;
                    editBTN.Content = editImg;
                    editBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    editBTN.VerticalAlignment = VerticalAlignment.Center;
                    editBTN.Margin = new Thickness(5,0,5,0);
                    editBTN.Cursor = Cursors.Hand;
                    editBTN.BorderThickness = new Thickness(0);
                    editBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));

                    //delete
                    Button deleteBTN = new Button(); 
                    deleteBTN.Name = $"book_{objData.ISBN}";  
                    deleteBTN.Click +=DeleteBook; 
                    deleteBTN.Content = deleteImg;
                    deleteBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    deleteBTN.VerticalAlignment = VerticalAlignment.Center;
                    deleteBTN.Cursor = Cursors.Hand;
                    deleteBTN.BorderThickness = new Thickness(0);
                    deleteBTN.Background = new SolidColorBrush(Color.FromRgb(255, 205, 178));

                    //set column and row for button
                    Grid.SetColumn(detailBTN, 0); 
                    Grid.SetColumn(editBTN, 1); 
                    Grid.SetColumn(deleteBTN, 2); 
                    Grid.SetRow(detailBTN, 0);
                    Grid.SetRow(editBTN, 0);
                    Grid.SetRow(deleteBTN, 0);
                    //connect button to grid container
                    containerBTN.Children.Add(detailBTN);
                    containerBTN.Children.Add(editBTN);
                    containerBTN.Children.Add(deleteBTN);

                    //define col to grid
                    ColumnDefinition col1 = new ColumnDefinition(); //id
                    //col1.Width = new GridLength(50); // Fixed width;
                    col1.Width = new GridLength(100);
                    //col1.MinWidth = 100;
                    ColumnDefinition col2 = new ColumnDefinition();//title
                    col2.Width = new GridLength(300);
                    //col2.MinWidth = 300;
                    ColumnDefinition col3 = new ColumnDefinition();// price
                    col3.Width = new GridLength(100); 
                    //col3.MinWidth = 100;
                    ColumnDefinition col4 = new ColumnDefinition();// btn container
                    col4.Width = new GridLength(100); 
                    //col4.MinWidth = 100;

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
                    Grid.SetRow(txtTitle, 0);
                    //Grid.SetRow(txtDesc, 0);
                    Grid.SetRow(txtPrice, 0);
                    Grid.SetRow(containerBTN, 0);

                    Grid.SetColumn(txtId, 0);
                    Grid.SetColumn(txtTitle, 1);
                    //Grid.SetColumn(txtDesc, 2);
                    Grid.SetColumn(txtPrice, 2);
                    Grid.SetColumn(containerBTN, 4);

                    dataItem.Children.Add(txtId);
                    dataItem.Children.Add(txtTitle);
                    //dataItem.Children.Add(txtDesc);
                    dataItem.Children.Add(txtPrice);
                    dataItem.Children.Add(containerBTN);

                    dataContainer.Children.Add(dataItem);// use this for connecting to parent element 
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            BookManagement bookManagement = new BookManagement();
            NavigationService.Navigate(bookManagement);
        }

        private void SearchBook(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtInputId.Text.Length != 0)
                {
                    bookList = books.GetData(int.Parse(txtInputId.Text));
                    CreateElementList(bookList);
                }
                else
                {
                    bookList = books.GetData();
                    CreateElementList(bookList);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EditBook(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button; 
            string buttonName;
            buttonName = clickedButton.Name; //get name of button

            //Navigation to edit page
            BookManagementEdit bookManagementEdit = new BookManagementEdit(buttonName);
            NavigationService.Navigate(bookManagementEdit);
        }

        private void ShowDetail(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            string buttonName;
            buttonName = clickedButton.Name; //get name of button

            //Navigation to edit page
            BookManagementDetail bookManagementDetail = new BookManagementDetail(buttonName.ToString());
            NavigationService.Navigate(bookManagementDetail);
        }

        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            // Cast the sender to a Button
            Button clickedButton = sender as Button;
            string buttonName;

            if (clickedButton != null)
            {
                buttonName = clickedButton.Name;
                try
                {
                    
                    //delete data
                    int bookId = int.Parse(buttonName.Substring(5));
                    Boolean status =books.DeleteData(bookId); //parse to int
                    if (status) 
                    {
                        MessageBox.Show($"Book id: {bookId} is deleted.");
                        bookList = books.GetData();
                        CreateElementList(bookList);
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show($"Cannot delete Book id: {buttonName.Substring(5)}");

                }
            }
            
        }

    }
}
