﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Visitor.PluralSight.AfterRef
{
    class Program
    {
        static void Main1(string[] args)
        {
            var person = new Person();
            //person.BankAccounts.Add(new BankAccount { Amount = 1000, MonthlyInterest = 0.01 });
            //person.BankAccounts.Add(new BankAccount { Amount = 2000, MonthlyInterest = 0.02 });
            //person.RealEstates.Add(new RealEstate { EstimatedValue = 79000, MonthlyRent = 500 });

            person.Assets.Add(new BankAccount { Amount = 1000, MonthlyInterest = 0.01 });
            person.Assets.Add(new BankAccount { Amount = 2000, MonthlyInterest = 0.02 });
            person.Assets.Add(new RealEstate { EstimatedValue = 79000, MonthlyRent = 500 });
            person.Assets.Add(new Loan { Owed = 40000, MonthlyPayment = 40 });

            // Networth Visitor

            var networthVisitor = new NetworthVisitor();
            person.Accept(networthVisitor);
            Console.WriteLine(networthVisitor.Total);
            Console.ReadKey();

            // Income Visitor
            var incomeVisitor = new IncomeVisitor();
            person.Accept(incomeVisitor);
            Console.WriteLine(incomeVisitor.Amount);

            //int netWorth = 0;
            //foreach (var bankAccount in person.BankAccounts)
            //    netWorth += bankAccount.Amount;

            //foreach (var realEstate in person.RealEstates)
            //    netWorth += realEstate.EstimatedValue;

            //foreach (var loan in person.Loans)
            //    netWorth -= loan.Owed;

            //Console.WriteLine(netWorth);
            //Console.ReadLine();
        }
    }
}
