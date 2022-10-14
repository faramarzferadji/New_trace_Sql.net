using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Book_SQL_Trace.Business;
using Book_SQL_Trace.DataAccess;
using MySqlConnector;

namespace Book_SQL_Trace.GUI
{
    public partial class book_form : Form
    {
        MySqlCommand cmd;
        MySqlConnection con;
        List<Book> listB = new List<Book>();
        public book_form()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Block = comboBoxblock.Text;
            book.Name = textBoxname.Text;
            book.Titel = comboBoxbookname.Text;
            book.BookID = Convert.ToInt32(comboBoxnumber.Text);
            book.Date_out = Convert.ToDateTime(dateTimePickerout.Value.ToString());
            book.Date_Due = Convert.ToDateTime(dateTimePickerdue.Value.ToString());
            BookIO.SaveRecord(book);

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult ans = MessageBox.Show("Are you sure to Exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ans == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonlist_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Block = comboBoxblock.Text;
            book.Name = textBoxname.Text;
            book.Titel = comboBoxbookname.Text;
            book.BookID = Convert.ToInt32(comboBoxnumber.Text);
            book.Date_out = Convert.ToDateTime(dateTimePickerout.Value.ToString());
            book.Date_Due = Convert.ToDateTime(dateTimePickerdue.Value.ToString());
            listB.Add(book);
            MessageBox.Show("You can see all record in file");
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
           
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            comboBoxblock.Text = "";
            textBoxname.Clear();
            comboBoxbookname.Text = "";
            comboBoxnumber.Text = "";
            dateTimePickerout.Text = String.Empty;
            dateTimePickerdue.Text = string.Empty;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            BookIO.Delete(textBoxname.Text, comboBoxbookname.ToString());
            MessageBox.Show(" Date has been deleted successfuly!");
        }

        private void comboBoxbookname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((comboBoxblock.SelectedItem).ToString()) == "Block 1")
            {


               

                comboBoxbookname.Items.Add("Book11123");

                comboBoxbookname.Items.Add("Book11124");
                comboBoxbookname.DataSource = null;



            }

            else if
                (((comboBoxblock.SelectedItem).ToString()) == "Block 2")
            {
                comboBoxbookname.Items.Add("Book22123");
                comboBoxbookname.Items.Add("Book22123");


            }
            else if
               (((comboBoxblock.SelectedItem).ToString()) == "Block 3")
            {
                comboBoxbookname.Items.Add("Book33123");
                comboBoxbookname.Items.Add("Book33123");


            }
            else
                comboBoxbookname.Items.Clear();
        }

        private void buttonTrack_Click(object sender, EventArgs e)
        {
            Book book = BookIO.search(textBoxname.Text.ToString());
        }

        private void buttonShow_Click_1(object sender, EventArgs e)
        {
            listViewBook.Items.Clear();
            BookIO.ListBook(listViewBook);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            con = new MySqlConnection(@"server=localhost;user id=root;database=book_trace; password = SYSTEM;");
            con.Open();
            cmd = new MySqlCommand("INSERT into book_trace.book_tr(block,name,titel,id,timeout,timedue) Values(@block,@name,@titel,@id,@timeout,@timedue)", con);
            cmd.Parameters.AddWithValue("@block", comboBoxblock.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@name", textBoxname.Text);
            cmd.Parameters.AddWithValue("@titel", comboBoxbookname.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@id", comboBoxnumber.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@timeout", dateTimePickerout.Value);
            cmd.Parameters.AddWithValue("@timedue",dateTimePickerdue.Value);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("All data has been stored");

        }

        private void buttondelet_Click(object sender, EventArgs e)
        {
            con = new MySqlConnection(@"server=localhost;user id=root;database=book_trace; password = SYSTEM;");
            con.Open();
            cmd = new MySqlCommand("Delete from book_trace.book_tr where name ='"+textBoxname.Text+"' ", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Data has been deleted successfully from database ");
            con.Close();

        }
    }
}
