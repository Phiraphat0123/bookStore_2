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
    /// <summary>
    /// Interaction logic for BookManagementList.xaml
    /// </summary>
    public partial class BookManagementList : Page
    {
        Books books;
        Boolean DatabaseStatus;
        List<Object> bookList;

        public BookManagementList()
        {
            InitializeComponent();

            books = new Books(); // create instance obj
            bookList = books.GetData(); // receive data to obj list
            CreateElementList(bookList); //create element list  of data 
        }

        private void CreateElementList(List<Object> bookList)
        {
            
            // get data
            try
            {
                foreach (BookModel objData in bookList)
                {
                    //button for detail pop up
                    Button detailBTN = new Button { Name = $"book_{objData.ISBN}" };
                    //detailBTN.Content = ""; //not just a text perhap element too
                    detailBTN.HorizontalAlignment = HorizontalAlignment.Stretch;
                    detailBTN.VerticalAlignment = VerticalAlignment.Top;
                    detailBTN.Width = Double.NaN;
                    detailBTN.Height = Double.NaN;
                    detailBTN.Click += DeleteBook;
                    // detailBTN.Name = $"{objData.ISBN}";

                    // grid
                    Grid dataItem = new Grid(); // data item
                    dataItem.HorizontalAlignment = HorizontalAlignment.Stretch;
                    dataItem.VerticalAlignment = VerticalAlignment.Top;
                    dataItem.MinWidth = 500;
                    dataItem.Width = Double.NaN;
                    dataItem.Height = Double.NaN; //use this to make height auto
                    dataItem.Margin = new Thickness(0, 0, 0, 10);

                    // id
                    TextBlock txtId = new TextBlock();
                    txtId.Text = objData.ISBN.ToString();
                    txtId.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtId.VerticalAlignment = VerticalAlignment.Top;
                    txtId.Width = Double.NaN;
                    txtId.Height = Double.NaN;
                    txtId.TextAlignment = TextAlignment.Center;
                    //txtId.Width = 20;

                    // title
                    TextBlock txtTitle = new TextBlock();
                    txtTitle.Text = objData.title.ToString();
                    txtTitle.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtTitle.VerticalAlignment = VerticalAlignment.Top;
                    txtTitle.Height = Double.NaN;
                    txtTitle.Width = Double.NaN;
                    txtTitle.TextAlignment = TextAlignment.Left;
                    txtTitle.Padding = new Thickness(2);

                    // description
                    //TextBlock txtDesc = new TextBlock();
                    //txtDesc.Text = objData.description.ToString();
                    //txtDesc.HorizontalAlignment = HorizontalAlignment.Stretch;
                    //txtDesc.VerticalAlignment = VerticalAlignment.Top;
                    //txtDesc.Height = Double.NaN;
                    //txtDesc.Width = Double.NaN;
                    //txtDesc.Padding =new Thickness(2);

                    // price
                    TextBlock txtPrice = new TextBlock();
                    txtPrice.Text = objData.price.ToString();
                    txtPrice.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtPrice.VerticalAlignment = VerticalAlignment.Top;
                    txtPrice.Height = Double.NaN;
                    txtPrice.Width = Double.NaN;
                    txtPrice.Padding = new Thickness(2);
                    //txtPrice.Width = 20;

                    //delete-btn and edit-btn
                    Grid containerBTN = new Grid();


                    //define col to grid
                    ColumnDefinition col1 = new ColumnDefinition();
                    //col1.Width = new GridLength(50); // Fixed width;
                    col1.Width = GridLength.Auto;
                    col1.MinWidth = 50;
                    ColumnDefinition col2 = new ColumnDefinition();
                    col2.Width = GridLength.Auto;
                    col2.MinWidth = 100;
                    ColumnDefinition col3 = new ColumnDefinition();
                    col3.Width = GridLength.Auto; // Fixed width;
                    col3.MinWidth = 300;
                    ColumnDefinition col4 = new ColumnDefinition();
                    col4.Width = GridLength.Auto; // Fixed width;
                    col4.MinWidth = 50;

                    RowDefinition row1 = new RowDefinition();
                    row1.Height = GridLength.Auto;

                    // Add columns to the grid
                    dataItem.ColumnDefinitions.Add(col1);
                    dataItem.ColumnDefinitions.Add(col2);
                    //dataItem.ColumnDefinitions.Add(col3);
                    dataItem.ColumnDefinitions.Add(col4);
                    dataItem.RowDefinitions.Add(row1);

                    // Set the Grid.Column, Grid.Row, Grid.ColumnSpan, and Grid.RowSpan properties
                    Grid.SetRow(txtId, 0);
                    Grid.SetRow(txtTitle, 0);
                    //Grid.SetRow(txtDesc, 0);
                    Grid.SetRow(txtPrice, 0);

                    Grid.SetColumn(txtId, 0);
                    Grid.SetColumn(txtTitle, 1);
                    //Grid.SetColumn(txtDesc, 2);
                    Grid.SetColumn(txtPrice, 3);

                    dataItem.Children.Add(txtId);
                    dataItem.Children.Add(txtTitle);
                    //dataItem.Children.Add(txtDesc);
                    dataItem.Children.Add(txtPrice);

                    detailBTN.Content = dataItem;
                    dataContainer.Children.Add(detailBTN);// use this for connecting to parent element 
                    //MessageBox.Show($"id:{objData.ISBN}, title:{objData.title}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SearchBook(object sender, RoutedEventArgs e)
        {
            
            if (txtInputId.Text.Length != 0) {
                int dataInput = int.Parse(txtInputId.Text);
                try
                {
                    MessageBox.Show(dataInput.ToString());
                    dataContainer.Children.Clear(); //use this for remove all element and replace new with data
                    bookList = books.GetData(dataInput);

                    //Console.WriteLine(bookListFiltered);
                    //MessageBox.Show(string.Join("\n", bookListFiltered));
                    CreateElementList(bookList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                try
                {
                    
                    dataContainer.Children.Clear(); //use this for remove all element and replace new with data
                    bookList = books.GetData();

                    CreateElementList(bookList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
            
            
            
            //dataListContainer.Visibility = Visibility.Hidden;
        }
        private void DeleteBook(object sender, RoutedEventArgs e)
        {
            // Cast the sender to a Button
            Button clickedButton = sender as Button;
            string buttonName;

            if (clickedButton != null)
            {
                // Get the name of the button
                 buttonName = clickedButton.Name;

                // Get the content of the button
                //string buttonContent = clickedButton.Content.ToString();

                // Display the button's name and content
                //MessageBox.Show($"Button Name: {buttonName}\nButton Content: {buttonContent}");

                try
                {
                    //books.DeleteData();
                    MessageBox.Show(buttonName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            
        }

    }
}
