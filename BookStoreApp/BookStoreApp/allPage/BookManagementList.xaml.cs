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
        BookModel temporaryData;
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
                dataContainer.Children.Clear(); //use this for remove all element and replace new with data
                foreach (BookModel objData in bookList)
                {
                    //button for detail pop up
                    //Button detailBTN = new Button { Name = $"book_{objData.ISBN}" };
                    //detailBTN.Content = ""; //not just a text perhap element too
                    //detailBTN.HorizontalAlignment = HorizontalAlignment.Stretch;
                    //detailBTN.VerticalAlignment = VerticalAlignment.Top;
                    //detailBTN.Width = Double.NaN;
                    //detailBTN.Height = Double.NaN;
                    //detailBTN.Click += DeleteBook;
                    //detailBTN.Click += TestingBTN;
                    // detailBTN.Name = $"{objData.ISBN}";

                    // grid for data item
                    Grid dataItem = new Grid(); // data item
                    dataItem.HorizontalAlignment = HorizontalAlignment.Stretch;
                    dataItem.VerticalAlignment = VerticalAlignment.Center;
                    dataItem.MinWidth = 500;
                    dataItem.Width = Double.NaN;
                    dataItem.Height = Double.NaN; //use this to make height auto
                    dataItem.Margin = new Thickness(0, 0, 0, 10);

                    // data id
                    TextBlock txtId = new TextBlock();
                    txtId.Text = objData.ISBN.ToString();
                    txtId.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtId.VerticalAlignment = VerticalAlignment.Center;
                    txtId.Width = Double.NaN;
                    txtId.Height = Double.NaN;
                    txtId.TextAlignment = TextAlignment.Center;
                    //txtId.Width = 20;

                    // data title
                    TextBlock txtTitle = new TextBlock();
                    txtTitle.Text = objData.title.ToString();
                    txtTitle.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtTitle.VerticalAlignment = VerticalAlignment.Center;
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

                    // data price
                    TextBlock txtPrice = new TextBlock();
                    txtPrice.Text = objData.price.ToString();
                    txtPrice.HorizontalAlignment = HorizontalAlignment.Stretch;
                    txtPrice.VerticalAlignment = VerticalAlignment.Center;
                    txtPrice.Height = Double.NaN;
                    txtPrice.Width = Double.NaN;
                    txtPrice.Padding = new Thickness(2);
                    //txtPrice.Width = 20;

                    //container have: detail-btn, delete-btn and edit-btn
                    //grid for container
                    Grid containerBTN = new Grid();
                    containerBTN.HorizontalAlignment = HorizontalAlignment.Stretch;
                    containerBTN.VerticalAlignment = VerticalAlignment.Center;
                    containerBTN.MinWidth = 100;
                    containerBTN.Width = Double.NaN;
                    containerBTN.Height = Double.NaN;
                    ColumnDefinition colDetail = new ColumnDefinition { Width = GridLength.Auto };
                    ColumnDefinition colEdit = new ColumnDefinition { Width=GridLength.Auto};
                    ColumnDefinition colDelete = new ColumnDefinition{ Width=GridLength.Auto };
                    RowDefinition rowContainerBTN =new RowDefinition { Height= GridLength.Auto };
                    containerBTN.ColumnDefinitions.Add(colDetail);
                    containerBTN.ColumnDefinitions.Add(colEdit);
                    containerBTN.ColumnDefinitions.Add(colDelete);
                    containerBTN.RowDefinitions.Add(rowContainerBTN);
                    // image for show in button
                    Image detailImg = new Image { Source = ImageLoading.GetImage("../icon/book.png"), Width = 15, Height = 15 };
                    Image editImg = new Image{ Source= ImageLoading.GetImage("../icon/book.png"), Width = 15, Height = 15 };
                    Image deleteImg = new Image{ Source = ImageLoading.GetImage("../icon/book.png"), Width = 15, Height = 15 };

                    // button for click edit and delete data
                    //detail
                    Button detailBTN = new Button(); //edit button
                    detailBTN.Name = $"book_{objData.ISBN}"; //เพิ่ม String เพื่อให้ไไม่เกิดบัค
                    detailBTN.Click += ShowDetail; //เพิ่ม Method เข้าไป
                    detailBTN.Content = detailImg;
                    detailBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    detailBTN.VerticalAlignment = VerticalAlignment.Center;
                   
                    //edit
                    Button editBTN = new Button(); //edit button
                    editBTN.Name = $"book_{objData.ISBN}"; //เพิ่ม String เพื่อให้ไไม่เกิดบัค
                    editBTN.Click += EditBook; //เพิ่ม Method เข้าไป
                    editBTN.Content = editImg;
                    editBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    editBTN.VerticalAlignment = VerticalAlignment.Center;
                    editBTN.Margin = new Thickness(5,0,5,0);
                    //delete
                    Button deleteBTN = new Button();//delete button
                    deleteBTN.Name = $"book_{objData.ISBN}"; //เพิ่ม String เพื่อให้ไไม่เกิดบัค
                    deleteBTN.Click +=DeleteBook; //เพิ่ม Method เข้าไป
                    deleteBTN.Content = deleteImg;
                    deleteBTN.HorizontalAlignment = HorizontalAlignment.Center;
                    deleteBTN.VerticalAlignment = VerticalAlignment.Center;
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

                    // Set the Grid.Column, Grid.Row, Grid.ColumnSpan, and Grid.RowSpan properties
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


                    //detailBTN.Content = dataItem;
                    dataContainer.Children.Add(dataItem);// use this for connecting to parent element 
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

        private void EditBook(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button; 
            string buttonName;
            buttonName = clickedButton.Name; //get name of button

            //Navigation to edit page
            BookManagementEdit bookManagementEdit = new BookManagementEdit(buttonName);
            //BookManagementEdit bookManagementEdit = new BookManagementEdit("9999","this title", "this's a book", "120");
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
                
                // Get the content of the button
                //string buttonContent = clickedButton.Content.ToString();

                // Display the button's name and content
                //MessageBox.Show($"Button Name: {buttonName}\nButton Content: {buttonContent}");

                try
                {
                    // Get the name of the button
                    buttonName = clickedButton.Name;
                    //MessageBox.Show(buttonName.Substring(5));
                    //delete data
                    int bookId = int.Parse(buttonName.Substring(5));
                    books.DeleteData(bookId); //parse to int
                    MessageBox.Show($"Book id: {buttonName.Substring(5)} is deleted.");
                    bookList = books.GetData();
                    CreateElementList(bookList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            
        }

    }
}
