﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Visitor.PluralSight.AfterRef
{

    public interface IVisitor
    {
        void Visit(RealEstate realEstate);
        void Visit(BankAccount bankAccount);
        void Visit(Loan loan);
    }



    public class IncomeVisitor : IVisitor
    {
        public double Amount;
        public void Visit(RealEstate realEstate)
        {
            Amount += realEstate.MonthlyRent;
        }

        public void Visit(BankAccount bankAccount)
        {
            Amount += bankAccount.Amount * bankAccount.MonthlyInterest;
        }

        public void Visit(Loan loan)
        {
            Amount -= loan.MonthlyPayment;
        }
    }

    public class NetworthVisitor : IVisitor
    {
        public int Total { get; set; }

        public void Visit(RealEstate realEstate)
        {
            Total += realEstate.EstimatedValue;
        }

        public void Visit(BankAccount bankAccount)
        {
            Total += bankAccount.Amount;
        }

        public void Visit(Loan loan)
        {
            Total -= loan.Owed;
        }
    }
    public interface IAsset
    {
        void Accept(IVisitor visitor);
    }




    public class Person : IAsset
    {
        // instead of having 3 lists

        //public List<RealEstate> RealEstates = new List<RealEstate>();
        //public List<BankAccount> BankAccounts = new List<BankAccount>();
        //public List<Loan> Loans = new List<Loan>();

        // we'll have one list
        public List<IAsset> Assets = new List<IAsset>();

        public void Accept(IVisitor visitor)
        {
            foreach (var asset in Assets)
            {
               asset.Accept(visitor);
            }
        }
    }

    public class Loan : IAsset
    {
        public int Owed { get; set; }
        public int MonthlyPayment { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class BankAccount : IAsset
    {
        public int Amount { get; set; }
        public double MonthlyInterest { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class RealEstate : IAsset
    {
        public int EstimatedValue { get; set; }
        public int MonthlyRent { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
