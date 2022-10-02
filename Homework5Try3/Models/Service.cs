using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Homework5Try3.Models
{
    public class Service
    {
        public static List<BooksVM> BooksVM = null;
        private SqlConnection currConnection;


        public bool openConnection()
        {
            bool status = true;
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                currConnection = new SqlConnection(conString);
                currConnection.Open();
            }
            catch
            {
                status = false;
            }
            return status;
        }

        public bool closeConnection()
        {
            if (currConnection != null)
            {
                currConnection.Close();
            }
            return true;

        }

        //--------------------------------------------GET ALL BOOKS----------------------------------------------------------------------

        public List<books> getAllBooks()
        {
            List<books> books = new List<books>();

            try
            {
                openConnection();
                SqlCommand command = new SqlCommand("SELECT books.bookId, books.name, authors.surname, types.name, books.pagecount, books.point from books INNER JOIN authors ON authors.authorId = books.authorId INNER JOIN types ON books.typeId = types.typeId", currConnection);
                using (SqlDataReader reader = command.ExecuteReader()) //lees van databasisse gebruik ExcecuteRader, NA databasis stuur ExcecuteNonQuery
                {
                    while (reader.Read())
                    {
                        books tmpDest = new books();
                        tmpDest.bookId = Convert.ToInt32(reader[0]);
                        tmpDest.name = Convert.ToString(reader[1]);
                        tmpDest.author = Convert.ToString(reader[2]);
                        tmpDest.type = Convert.ToString(reader[3]);
                        tmpDest.pagecount = Convert.ToInt32(reader[4]);
                        tmpDest.point = Convert.ToInt32(reader[5]);

                        books.Add(tmpDest);
                    }
                }
                closeConnection();
            }
            catch
            {
            }

            return books;
        }
        //--------------------------------------------GET ALL BORROWS----------------------------------------------------------------------
        public List<borrows> getAllBorrows(int id)
        {
            List<borrows> borrows = new List<borrows>();

            try
            {
                openConnection();
                SqlCommand command = new SqlCommand("SELECT borrows.borrowId, borrows.takenDate, borrows.broughtDate, students.name from borrows INNER JOIN students ON students.studentId = borrows.studentId INNER JOIN books ON books.bookId = borrows.bookId WHERE books.bookId = '" + id + "'", currConnection);
                using (SqlDataReader reader = command.ExecuteReader()) //lees van databasisse gebruik ExcecuteRader, NA databasis stuur ExcecuteNonQuery
                {
                    while (reader.Read())
                    {
                        borrows tmpDest = new borrows();
                        tmpDest.borrowId = Convert.ToInt32(reader[0]);
                        tmpDest.takenDate = (DateTime)reader[1];
                        tmpDest.broughtDate = (DateTime)reader[2];
                        tmpDest.student = Convert.ToString(reader[3]);
                        borrows.Add(tmpDest);
                    }
                }
                closeConnection();
            }
            catch
            {
            }

            return borrows;
        }
        //--------------------------------------------GET ALL STUDENTS----------------------------------------------------------------------
        public List<students> getAllStudents()
        {
            List<students> students = new List<students>();

            try
            {
                openConnection();
                SqlCommand command = new SqlCommand("SELECT students.studentId, students.name, students.surname, students.class, students.point from students", currConnection);
                using (SqlDataReader reader = command.ExecuteReader()) //lees van databasisse gebruik ExcecuteRader, NA databasis stuur ExcecuteNonQuery
                {
                    while (reader.Read())
                    {
                        students tmpDest = new students();
                        tmpDest.studentId = Convert.ToInt32(reader[0]);
                        tmpDest.name = Convert.ToString(reader[1]);
                        tmpDest.surname = Convert.ToString(reader[2]);
                        tmpDest.classs = Convert.ToString(reader[3]);
                        tmpDest.point = Convert.ToInt32(reader[4]);
                        students.Add(tmpDest);
                    }
                }
                closeConnection();
            }
            catch
            {
            }

            return students;
        }
        //-------------------------------------BORROW AND RETURN FUNCTIONS----------------------------------------------------------------------
        public List<BooksVM> BorrowBook(int bookId)
        {
            List<BooksVM> booksVM = new List<BooksVM>();
            return booksVM;
        }

        public List<BooksVM> ReturnBook(int bookId)
        {
            List<BooksVM> booksVM = new List<BooksVM>();
            return booksVM;
        }

    }
}
