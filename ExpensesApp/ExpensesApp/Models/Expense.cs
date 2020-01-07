using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpensesApp.Models
{
    public class Expense
    {
        public Expense()
        {

        }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Ammount { get; set; }
        [MaxLength(25)]
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public static int InsertExpense(Expense expense)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Insert(expense);
            }
        }

        public static List<Expense> GetExpenses()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().ToList();
            }
        }
        public static List<Expense> GetExpenses(string category)
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Where(expence => expence.Category == category).ToList();
            }
        }
        public static decimal GetTotalExpensesAmmount()
        {
            using (SQLite.SQLiteConnection conn = new SQLiteConnection(App.DatabasePath))
            {
                conn.CreateTable<Expense>();
                return conn.Table<Expense>().Sum(expence => expence.Ammount);
            }
        }
    }
}
