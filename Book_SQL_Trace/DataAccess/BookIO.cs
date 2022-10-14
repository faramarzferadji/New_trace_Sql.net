using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Book_SQL_Trace.Business;

namespace Book_SQL_Trace.DataAccess
{
   public class BookIO
    {
        private static string filepath = Application.StartupPath + @"\Book.dat";
        private static string filetemp = Application.StartupPath + @"\temp.dat";

        public static void SaveRecord(Book book)
        {
            StreamWriter streamWriter = new StreamWriter(filepath, true);
            streamWriter.WriteLine(book.Block + "," + book.Name + "," + book.Titel +
                "," + book.BookID + "," + book.Date_out + "," + book.Date_Due);
            streamWriter.Close();
            MessageBox.Show("Data has been save successfully!");

        }
        public static void ListBook(ListView listViewBook)
        {
            StreamReader streamReader = new StreamReader(filepath);
            listViewBook.Items.Clear();
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] fildes = line.Split(',');
                ListViewItem item = new ListViewItem(fildes[0]);
                item.SubItems.Add(fildes[1]);
                item.SubItems.Add(fildes[2]);
                item.SubItems.Add(fildes[3]);
                item.SubItems.Add(fildes[4]);
                item.SubItems.Add(fildes[5]);
                listViewBook.Items.Add(item);
                line = streamReader.ReadLine();

            }
            streamReader.Close();
        }
        public static List<Book> listbook()
        {
            List<Book> listB = new List<Book>();
            StreamReader streamReader = new StreamReader(filepath);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] fildes = line.Split(',');
                Book book = new Book();
                book.Block = fildes[0];
                book.Name = fildes[1];
                book.Titel = fildes[2];
                book.BookID = Convert.ToInt32(fildes[3]);
                book.Date_out = Convert.ToDateTime(fildes[4]);
                book.Date_Due = Convert.ToDateTime(fildes[5]);
                listB.Add(book);
                line = streamReader.ReadLine();

            }
            streamReader.Close();
            return listB;
        }

        public static Book search(string name)
        {
            Book book = new Book();
            StreamReader streamReader = new StreamReader(filepath);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] fields = line.Split(',');
                if (name == fields[1])
                {
                    book.Block = fields[0];
                    book.Name = fields[1];
                    book.Titel = fields[2];
                    book.BookID = Convert.ToInt32(fields[3]);
                    book.Date_out = Convert.ToDateTime(fields[4]);
                    book.Date_Due = Convert.ToDateTime(fields[5]);
                    MessageBox.Show("Attention     " + fields[1] + " from " + fields[0] + " took " + fields[2] +
                        " Book ID is " + fields[3] + " has taken in " + fields[4] + " has to be returned " + fields[5]);

                }
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            return null;
        }
        public static void Delete(string name, string title)
        {
            StreamWriter streamWriter = new StreamWriter(filetemp);
            StreamReader streamReader = new StreamReader(filepath);
            string line = streamReader.ReadLine();
            while (line != null)
            {
                string[] fildes = line.Split(',');

                if ((fildes[1] != name) && (fildes[2] != title))
                {


                    streamWriter.WriteLine(fildes[0] + "," + fildes[1] + "," + fildes[2] +
                        "," + fildes[3] + "," + fildes[4] + "," + fildes[5]);


                }
                line = streamReader.ReadLine();
            }
            streamReader.Close();
            streamWriter.Close();
            File.Delete(filepath);
            File.Move(filetemp, filepath);
            MessageBox.Show("Are you sur to delete these information");

        }
    }
}
